namespace Shop.Entities.Delivery;

public class DeliveryType
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DeliveryTypeConfig? Config { get; set; }
    public bool IsActive { get; set; }
}
