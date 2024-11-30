using Dapper;

namespace Museum.WebApi.Models;

public record TenantDto(int TenantId, string Name, DateTime CreatedAt, DateTime UpdatedAt, bool IsEnabled)
{
    [ExplicitConstructor]
    public TenantDto(string Name)
        : this(0, Name, DateTime.UtcNow, DateTime.UtcNow, true)
    { }
}