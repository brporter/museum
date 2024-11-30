namespace Museum.WebApi.Models;

public class TenantDto
{
    public int TenantId { get; set; }
    
    public required string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsEnabled { get; set; }

}