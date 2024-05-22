using Senko_253505.UI.ViewModels;

namespace Senko_253505.UI.Pages;

public partial class CompaniesPage : ContentPage
{
    public CompaniesPage(CompaniesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}