using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Senko_253505.Application.CarsUseCases.Commands;
using Senko_253505.Application.TransportCompanyUseCases.Queries;
using Car = Senko_253505.Domain.Entities.Car;

namespace Senko_253505.UI.ViewModels;

[QueryProperty(nameof(Car), "Car")]
public partial class AddOrUpdateCarViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMediator _mediator;

    public AddOrUpdateCarViewModel(IMediator mediator)
    {
        _mediator = mediator;
        // Model = Request.Car.Characteristic.Model;
        // Year = Request.Car.Characteristic.Year;
        // Horsepower = Request.Car.Characteristic.Horsepower;
        // // Date = request.Car.Date;
    }

    [ObservableProperty] string errText;
    Car _car;

    private int companyId;

    [ObservableProperty] string imageSrc;
    [ObservableProperty] FileResult image;
    [ObservableProperty] IAddOrUpdateCarCommand request;
    [ObservableProperty] TransportCompany company;
    [ObservableProperty] DateTime date;
    [ObservableProperty] TransportCompany selectedCompany;
    public ObservableCollection<TransportCompany> Companies { get; set; } = new();


    [RelayCommand]
    async Task SelectImage()
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images
        });
        var fullPath = result?.FullPath;
        if (fullPath != null)
        {
            ImageSrc = fullPath;
        }
    }

    [RelayCommand]
    public async Task AddOrUpdateCar()
    {
        await Task.Delay(1);
        if (
            Request.Car.Characteristic.Horsepower <= 0 ||
            Request.Car.Characteristic.Model == string.Empty ||
            Request.Car.Characteristic.Year <= 1700
        )
        {
            return;
        }

        Request.Car.TransportCompanyId = Company.Id;
        Request.Car.Name = Request.Car.Characteristic.Model;
        Request.Car.Date = DateOnly.FromDateTime(Date);
        await _mediator.Send(Request);
        File.Delete($"{FileSystem.CacheDirectory}/{Request.Car.Id}");
        File.Copy(ImageSrc, $"{FileSystem.CacheDirectory}/{Request.Car.Id}");

        await Shell.Current.GoToAsync("..");
    }
    
    [RelayCommand]
    async Task UpdateCompaniesList() => await GetCompanies();

    public async Task GetCompanies()
    {
        var companies = await _mediator.Send(new GetCompaniesQuery());
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Companies.Clear();
            foreach (var company in companies)
                Companies.Add(company);
        });
        // Company = _company;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Request = query["Request"] as IAddOrUpdateCarCommand;
        if (query.ContainsKey("Car"))
        {
            _car = query["Car"] as Car;
            var comp = await _mediator.Send(new GetCompaniesQuery());
            foreach (var com in comp)
            {
                if (com.Id == _car.TransportCompanyId)
                {
                    Company = com;
                    return;
                }
            }
        }
        else
        {
            Company = query[nameof(TransportCompany)] as TransportCompany;
        }

        Request.Car = new Car
        {
            Characteristic = new Vehicle()
        };
    }
}