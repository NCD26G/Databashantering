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
        collection.AddTransient<CustomersViewModel>();
        collection.AddScoped<IProductRepository, ProductRepository>();
        collection.AddScoped<ICustomerRepository, CustomerRepository>();
        collection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        collection.AddSingleton<Func<PageViewsEnum, ViewModelBase>>(c => name => name switch
        {
            PageViewsEnum.Home => c.GetRequiredService<HomeViewModel>(),
            PageViewsEnum.Products => c.GetRequiredService<ProductsViewModel>(),
            PageViewsEnum.Customers => c.GetRequiredService<CustomersViewModel>(),
            _ => throw new InvalidOperationException()
        });
    }
}
