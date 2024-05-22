using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Senko_253505.Application.TransportCompanyUseCases.Commands;
using Senko_253505.Application.TransportCompanyUseCases.Queries;

namespace Senko_253505.UI.ViewModels;

[QueryProperty(nameof(TransportCompany), "Company")]
public partial class AddOrUpdateCompanyViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMediator _mediator;

    public AddOrUpdateCompanyViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty] string errText;
    [ObservableProperty] string imageSrc;
    TransportCompany _Company;
    [ObservableProperty] TransportCompany company = new();

    [ObservableProperty] FileResult image;
    [ObservableProperty] IAddOrUpdateCompanyRequest request;
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
    async Task AddOrUpdateCompany()
    {
        await Task.Delay(1);
        if (
            Request.Company.Name == string.Empty ||
            Request.Company.Owner == string.Empty
        )
        {
            return;
        }

        await _mediator.Send(Request);


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
            foreach (var company in Companies)
                Companies.Add(company);
        });
        Company = _Company;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Request = query["Request"] as IAddOrUpdateCompanyRequest;
        if (query.ContainsKey("Company"))
        {
            _Company = query["Company"] as TransportCompany;
        }

        Request.Company = new TransportCompany();
    }
}