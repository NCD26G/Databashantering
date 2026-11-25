using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    private readonly IGenericRepository<Customer> _repo;

    [ObservableProperty]
    public partial ObservableCollection<Customer> Customers { get; set; } = [];

    public CustomersViewModel()
    {
        PageTitle = "Kunder";
    }

    public CustomersViewModel(IGenericRepository<Customer> repo)
    {
        PageTitle = "Kunder";
        _repo = repo;
        Init();
    }

    private async void Init()
    {
        await LoadCustomers();
    }
    private async Task LoadCustomers()
    {
        try
        {
            if (_repo is not null)
            {
                var customers = await _repo.ListAllAsync();
                Customers = new ObservableCollection<Customer>(customers);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
