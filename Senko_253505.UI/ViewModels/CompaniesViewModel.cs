using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Senko_253505.Application.CarsUseCases.Commands;
using Senko_253505.Application.CarsUseCases.Queries;
using Senko_253505.Application.TransportCompanyUseCases.Commands;
using Senko_253505.Application.TransportCompanyUseCases.Queries;
using Senko_253505.UI.Pages;

namespace Senko_253505.UI.ViewModels;

public partial class CompaniesViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    [ObservableProperty] private int carsCount;
    [ObservableProperty] private string errorText;
    [ObservableProperty] private Car selectedCar = new();

    [ObservableProperty] private TransportCompany? selectedTransportCompany;

    public CompaniesViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public ObservableCollection<TransportCompany> TransportCompanies { get; set; } = new();
    public ObservableCollection<Car> Cars { get; set; } = new();

    [RelayCommand]
    private async Task UpdateTransportCompanyList()
    {
        await GetTransportCompanies();
    }

    [RelayCommand]
    private async Task UpdateCarsList()
    {
        await GetCars();
    }

    [RelayCommand]
    async Task ShowDetails(Car car) => await GotoDetailsPage(car);

    private async Task GotoDetailsPage(Car car)
    {
        IDictionary<string, object> parameters =
            new Dictionary<string, object>()
            {
                { nameof(Car), car }
            };
        await Shell.Current.GoToAsync(nameof(CarDetailsPage), parameters);
    }

    [RelayCommand]
    private async Task AddTransportCompany()
    {
        await GotoAddOrUpdatePage(nameof(AddOrUpdateCompanyPage),
            new AddCompanyCommand() { Company = new TransportCompany() });
    }

    [RelayCommand]
    private async Task UpdateTransportCompany()
    {
        if (SelectedTransportCompany is null)
            return;
        await GotoAddOrUpdatePage(nameof(AddOrUpdateCompanyPage),
            new UpdateCompanyCommand() { Company = SelectedTransportCompany });
    }


    [RelayCommand]
    private async Task AddCar()
    {
        if (SelectedTransportCompany is null)
            return;
        await GotoAddOrUpdatePage(nameof(AddOrUpdateCarPage), new AddCarCommand() { Car = new Car() });
    }

    private async Task GotoAddOrUpdatePage(string route, IRequest request)
    {
        IDictionary<string, object> parameters =
            new Dictionary<string, object>()
            {
                { "Request", request },
                { "TransportCompany", SelectedTransportCompany }
            };
        await Shell.Current
            .GoToAsync(route, parameters);
    }
    
    [RelayCommand]
    private async Task DeleteTransportCompany()
    {
        if (SelectedTransportCompany is null)
            return;
        await DeleteTransportCompanyAction();
    }
    
    private async Task DeleteTransportCompanyAction() //TODO: Update page
    {
        await _mediator.Send(new DeleteCompanyCommand(SelectedTransportCompany));
        await GetTransportCompanies();
    }

    public async Task GetTransportCompanies()
    {
        var transportCompanies = await _mediator.Send(new GetCompaniesQuery());
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            TransportCompanies.Clear();
            foreach (var transportCompany in transportCompanies)
                TransportCompanies.Add(transportCompany);
        });
    }

    public async Task GetCars()
    {
        if (SelectedTransportCompany is null)
        {
            Cars.Clear();
            return;
        }

        var tmpCars = await _mediator.Send(new GetCarsByCompanyIdQuery(SelectedTransportCompany.Id));
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Trace.WriteLine("GETTING");
            Cars.Clear();
            foreach (var car in tmpCars)
            {
                Trace.WriteLine(car.Id);
                var tmp = tmpCars;
                Cars.Add(car);
            }

            CarsCount = Cars.Count;

        });
    }
}