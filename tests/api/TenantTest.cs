using Museum.Data;
using Museum.WebApi.Models;
using Museum.Data.Commands;
using Microsoft.Extensions.Configuration;

namespace Museum.Tests.Api;

public class TenantTests
    : IClassFixture<DatabaseFixture>
{
    DatabaseFixture _databaseFixture;

    public TenantTests(DatabaseFixture fixture)
    {
        _databaseFixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    [Trait("Data", "Integration")]
    public async Task Establish_Tenant()
    {
        // Arrange

        // Act
        var command = new EstablishTenantCommand(_databaseFixture.Broker);
        var result = await command.ExecuteAsync(new TenantDto { Name = "Test" });

        // Assert
        Assert.True(result > 0);
    }
}
