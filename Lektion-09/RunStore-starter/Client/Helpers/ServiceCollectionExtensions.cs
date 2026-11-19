using System;
using Client.Data;
using Client.Enums;
using Client.Factories;
using Client.Interfaces;
using Client.Repositories;
using Client.Services;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddDbContext<RunStoreDbContext>();
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<PageViewFactory>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<ProductsViewModel>();
        collection.AddTransient(typeof(IProductService<>), typeof(ProductServices<>));
        collection.AddScoped<IProductRepository, ProductRepository>();

        collection.AddSingleton<Func<PageViewsEnum, ViewModelBase>>(c => name => name switch
        {
            PageViewsEnum.Home => c.GetRequiredService<HomeViewModel>(),
            PageViewsEnum.Products => c.GetRequiredService<ProductsViewModel>(),
            _ => throw new InvalidOperationException()
        });
    }
}
