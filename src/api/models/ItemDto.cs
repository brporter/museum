namespace Museum.WebApi.Models;

public class ItemDto
{
    public int ItemId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int TypeId { get; set; }
    public int TenantId { get; set; }
}