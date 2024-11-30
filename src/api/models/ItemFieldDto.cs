namespace Museum.WebApi.Models;

public class ItemFieldDto
{
    public int ItemFieldId { get; set; }
    public int ItemId { get; set; }
    public int TypeFieldId { get; set; }
    public required string Value { get; set; }
}