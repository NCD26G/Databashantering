using System;
using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Client.Helpers;
using Client.ViewModels;
using Client.Views;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Client;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        collection.AddServices();

        // Här ska vi hämta anslutningssträngen och skicka den till RunStoreDbContext
        // 1. Skapa en dotnet applicationbuilder instans
        var builder = Host.CreateApplicationBuilder();
        // 2. Lägg till stöd för UserSecrets
        builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());

        // 3. Hämta anslutningssträngen😁
        var connectionString = builder.Configuration.GetConnectionString("pgsql");

        // 4. Lägg till vårt RunStoreDbContext som en singleton
        collection.AddDbContext<RunStoreDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.LogTo(Console.WriteLine, LogLevel.Information);
        });

        var serviceProvider = collection.BuildServiceProvider();
        var vm = serviceProvider.GetRequiredService<MainWindowViewModel>();

        // var context = serviceProvider.GetRequiredService<RunStoreDbContext>();

        // try
        // {
        //     context.Database.Migrate();
        //     SeedData.AddData(context);
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        //     throw;
        // }


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow()
            {
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}