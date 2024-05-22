using Senko_253505.UI.Pages;
using Senko_253505.UI.ViewModels;

namespace Senko_253505.UI;

public static class ServiceExtension
{
    public static IServiceCollection RegisterPages(this IServiceCollection services)
    {
        services
            .AddSingleton<CompaniesPage>()
            .AddSingleton<CarDetailsPage>()
            .AddTransient<AddOrUpdateCarPage>()
            .AddTransient<AddOrUpdateCompanyPage>();

        return services;
    }

    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services
            .AddSingleton<CompaniesViewModel>()
            .AddTransient<CarDetailsViewModel>()
            .AddTransient<AddOrUpdateCarViewModel>()
            .AddTransient<AddOrUpdateCompanyViewModel>();
        return services;
    }

    public static IServiceCollection CreateImageFolders(this IServiceCollection services)
    {
        var imagesDir = Path.Combine(FileSystem.AppDataDirectory, "Images");
        var carImagesDir = Path.Combine(FileSystem.AppDataDirectory, "Images", "Cars");
        var companyImagesDir = Path.Combine(FileSystem.AppDataDirectory, "Images", "Companies");
        Directory.CreateDirectory(imagesDir);
        Directory.CreateDirectory(carImagesDir);
        Directory.CreateDirectory(companyImagesDir);
        return services;
    }
}