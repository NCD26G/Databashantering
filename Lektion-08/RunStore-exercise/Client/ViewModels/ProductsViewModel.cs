using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    // private readonly IProductService<Product>? _productService;
    private readonly IProductRepository? _productRepo;
    private readonly MainWindowViewModel? _mainWindowViewModel;
    private string _productId = string.Empty;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    [ObservableProperty]
    public partial ObservableCollection<Entities.Product> Products { get; set; } = [];
    // public partial ObservableCollection<Product> Products { get; set; } = [];

    public ProductsViewModel()
    {
        PageTitle = "Våra produkter";
        Init();
    }

    public ProductsViewModel(IProductRepository repo, MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _productRepo = repo;
        PageTitle = "Våra produkter";

        Init();
    }
    // public ProductsViewModel(IProductService<Product> productService, MainWindowViewModel mainWindowViewModel)
    // {
    //     _productService = productService;
    //     _mainWindowViewModel = mainWindowViewModel;
    //     PageTitle = "Våra produkter";

    //     Init();
    // }

    [RelayCommand]
    private async Task Delete(string id)
    {
        try
        {
            _productId = id;
            _mainWindowViewModel!.IsBusy = true;
            ShowDialog = true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    [RelayCommand]
    private async Task Confirm()
    {
        ShowDialog = false;
        _mainWindowViewModel!.IsBusy = false;
    }

    [RelayCommand]
    private void Cancel()
    {
        Console.WriteLine("Jasååå, du ångrar dig, fegis!");
        ShowDialog = false;
        _mainWindowViewModel!.IsBusy = false;
    }

    private async void Init()
    {
        await LoadProducts();
    }

    private async Task LoadProducts()
    {
        try
        {
            _mainWindowViewModel!.IsBusy = true;
            if (_productRepo is not null)
            {
                Products = new ObservableCollection<Entities.Product>(await _productRepo.ListAllAsync());
            }
            // if (_productService is not null)
            // {
            //     Products = new ObservableCollection<Product>(await _productService.ListAll());
            // }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            _mainWindowViewModel!.IsBusy = false;
        }
    }
}





