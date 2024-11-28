public class Tenant
{
    private int _tenantId;

    public string Name { get; set; }
    public List<Item> Items { get; set; }
    public List<Type> Types { get; set; }
}