using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Core.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Interfaces;
using System.Linq;
using Client.DTOs;

namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    private readonly IProductRepository? _productRepo;
    private readonly MainWindowViewModel? _mainWindowViewModel;
    private string _productId = string.Empty;

    [ObservableProperty]
    public partial bool ShowDialog { get; set; }

    [ObservableProperty]
    public partial string SearchValue { get; set; } = string.Empty;

    [ObservableProperty]
    public partial ObservableCollection<ProductListDto> Products { get; set; } = [];

    public ProductsViewModel()
    {
        PageTitle = "Våra produkter";
    }

    public ProductsViewModel(IProductRepository repo, MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _productRepo = repo;
        PageTitle = "Våra produkter";
        Init();
    }

    [RelayCommand]
    private async Task Search()
    {
        Console.WriteLine(SearchValue);
        await LoadProducts();
    }

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

    [RelayCommand]
    private async Task Edit(int id)
    {
        var product = await _productRepo!.FindByIdAsync(id);
        if (product is not null)
        {
            Console.WriteLine(product.Name);
        }
        else
        {
            Console.WriteLine("Hittade inget!!!");
        }
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
                if (string.IsNullOrWhiteSpace(SearchValue))
                {
                    var entities = await _productRepo.ListAllAsync();
                    var products = entities.Select(c => new ProductListDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Price = c.Price,
                        ItemNumber = c.ItemNumber,
                        Supplier = c.Supplier.Name
                    });
                    Products = new ObservableCollection<ProductListDto>(products);
                }
                else
                {
                    Console.WriteLine("Söker efter: " + SearchValue);
                    var entities = await _productRepo.FindByNameAsync(SearchValue);

                    var products = entities.Select(c => new ProductListDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Price = c.Price,
                        ItemNumber = c.ItemNumber,
                        Supplier = c.Supplier.Name
                    });

                    Products = new ObservableCollection<ProductListDto>(products);
                }

            }
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





