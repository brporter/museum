using Museum.Data;
using Museum.WebApi.Models;
using Museum.Data.Commands;
using Microsoft.Data.SqlClient;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace Museum.Tests.Api;

public class DatabaseFixture 
    : IDisposable
{
    public DatabaseFixture()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

        ConfigurationBuilder builder = new();
        builder.AddJsonFile("appsettings.json");
        builder.AddJsonFile("appsettings.Development.json");
        var configuration = builder.Build() ?? throw new InvalidOperationException("Configuration is null");

        Broker = new ConnectionBroker(
            Microsoft.Data.SqlClient.SqlClientFactory.Instance, 
            configuration.GetConnectionString("DefaultConnection") ?? string.Empty
        );
    }

    public void Dispose()
    { }

    public IConnectionBroker Broker { get; private set; }
}