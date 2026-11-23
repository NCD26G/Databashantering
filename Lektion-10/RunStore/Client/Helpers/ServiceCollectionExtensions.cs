using System;
using Client.Enums;
using Client.Factories;
using Client.ViewModels;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<PageViewFactory>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<ProductsViewModel>();
        collection.AddScoped<IProductRepository, ProductRepository>();

        collection.AddSingleton<Func<PageViewsEnum, ViewModelBase>>(c => name => name switch
        {
            PageViewsEnum.Home => c.GetRequiredService<HomeViewModel>(),
            PageViewsEnum.Products => c.GetRequiredService<ProductsViewModel>(),
            _ => throw new InvalidOperationException()
        });
    }
}
