using Senko_253505.UI.ViewModels;

namespace Senko_253505.UI.Pages;

public partial class AddOrUpdateCarPage : ContentPage
{
    public AddOrUpdateCarPage(AddOrUpdateCarViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}