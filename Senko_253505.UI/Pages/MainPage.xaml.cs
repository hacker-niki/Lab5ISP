using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace Senko_253505.UI.Pages;

public partial class MainPage : ContentPage
{
    [RelayCommand]
    async void ShowDetails() => await GotoDetailsPage();

    public MainPage()
    {
        InitializeComponent();
    }

    private async Task GotoDetailsPage()
    {
        await Shell.Current.GoToAsync(nameof(CarDetailsPage));
    }
}