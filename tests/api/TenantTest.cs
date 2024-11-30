﻿using Museum.Data;
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
    [Trait("Category", "Integration")]
    public async Task Establish_Tenant()
    {
        // Arrange

        // Act
        var command = new EstablishTenantCommand(_databaseFixture.Broker);
        var tenant = new TenantDto { Name = "Test" };
        await command.ExecuteAsync(tenant);

        // Assert
        Assert.True(tenant.TenantId > 0);
        Assert.Equal("Test", tenant.Name);

        // Assert that the CreatedAt and UpdatedAt properties are set to reasonable values
        Assert.True(tenant.CreatedAt < DateTime.UtcNow);
        Assert.True(tenant.UpdatedAt < DateTime.UtcNow);
        Assert.True(tenant.CreatedAt == tenant.UpdatedAt);
        Assert.True(tenant.IsEnabled);

        // This is going to be flaky if the test pauses for some reason during execution
        Assert.True(tenant.CreatedAt > DateTime.UtcNow.AddMinutes(-1));
    }
}
