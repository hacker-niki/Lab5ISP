using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senko_253505.UI.ViewModels;

namespace Senko_253505.UI.Pages;

public partial class CarDetailsPage : ContentPage
{
    public CarDetailsPage(CarDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}