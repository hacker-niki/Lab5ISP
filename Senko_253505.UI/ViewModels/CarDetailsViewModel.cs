using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Senko_253505.Application.CarsUseCases.Commands;
using Senko_253505.Application.CarsUseCases.Queries;
using Senko_253505.UI.Pages;

namespace Senko_253505.UI.ViewModels;

[QueryProperty(nameof(Car), "Car")]
public partial class CarDetailsViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public CarDetailsViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty] Car car;

    [ObservableProperty] string name;
    [ObservableProperty] DateOnly date;
    [ObservableProperty] Vehicle characteristic;
    [ObservableProperty] int carId;

    [RelayCommand]
    async Task GetCarById()
    {
        Car = await _mediator.Send(new GetCarByIdQuery(Car.Id));
        if (Car is null)
            return;
        Name = Car.Name;
        Date = Car.Date;
        Characteristic = Car.Characteristic;
        CarId = Car.Id;
    }

    [RelayCommand]
    async Task UpdateCar() =>
        await GotoAddOrUpdatePage<AddOrUpdateCarPage>(new UpdateCarCommand() { Car = Car });

    private async Task GotoAddOrUpdatePage<Page>(IAddOrUpdateCarCommand request)
        where Page : ContentPage
    {
        IDictionary<string, object> parameters =
            new Dictionary<string, object>()
            {
                { "Request", request },
                { "Car", request.Car }
            };
        await Shell.Current
            .GoToAsync(nameof(AddOrUpdateCarPage), parameters);
    }

    [RelayCommand]
    async Task DeleteCar() =>
        await RemoveCar(car);

    private async Task RemoveCar(Car Car)
    {
        await _mediator.Send(new DeleteCarCommand(Car));
        await Shell.Current.GoToAsync("..");
    }
}