using Senko_253505.UI.Pages;
using Senko_253505.UI.ViewModels;

namespace Senko_253505.UI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(CarDetailsPage), typeof(CarDetailsPage));
        Routing.RegisterRoute(nameof(AddOrUpdateCarPage), typeof(AddOrUpdateCarPage));
        Routing.RegisterRoute(nameof(AddOrUpdateCompanyPage), typeof(AddOrUpdateCompanyPage));
    }
}