namespace Museum.WebApi.Models;

public class Item
{
    private int _itemId;
    private int _tenantId;

    public int ItemId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public required Tenant Tenant { get; set; }
    public int TypeId { get; set; }
}