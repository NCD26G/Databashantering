using System;
using Microsoft.Extensions.Configuration;

namespace Client.Services;


public class BaseService
{
    protected string ConnectionString { get; private set; }

    public BaseService()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        ConnectionString = config.GetConnectionString("pgsql")
            ?? throw new InvalidOperationException("Finns ingen appsettings eller anslutningsträngen är felaktig");
    }
}
