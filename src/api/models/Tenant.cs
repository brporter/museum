namespace Museum.WebApi.Models;

public class Tenant
{
    private int _tenantId;

    public required string Name { get; set; }
    public List<Item>? Items { get; set; }
    public List<Type>? Types { get; set; }
}