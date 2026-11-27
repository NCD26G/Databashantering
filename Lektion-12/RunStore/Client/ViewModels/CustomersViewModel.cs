using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Client.DTOs;
using CommunityToolkit.Mvvm.ComponentModel;
using Core.Interfaces;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    private readonly ICustomerRepository? _repo;

    [ObservableProperty]
    public partial ObservableCollection<CustomersListDto> Customers { get; set; } = [];

    public CustomersViewModel()
    {
        PageTitle = "Kunder";
    }

    public CustomersViewModel(ICustomerRepository repo)
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
                // Entity typer
                var entities = await _repo.ListAllAsync();
                // Projicering...
                var customers = entities.Select(c => new CustomersListDto
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Phone = c.Phone ?? "Saknas",
                    Address = c.Addresses.First().AddressLine,
                    PostalCode = c.Addresses.First().PostalCode.Code,
                    City = c.Addresses.First().PostalCode.City.Name
                });

                Customers = new ObservableCollection<CustomersListDto>(customers);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
