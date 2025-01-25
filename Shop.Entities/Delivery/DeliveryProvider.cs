using Shop.Entities.Catalog;

namespace Shop.Entities.Delivery;

public class DeliveryProvider
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public DeliveryProviderConfig? Config { get; private set; }
    public bool IsActive { get; private set; }
    private readonly List<ProgramProduct> _programProducts = new List<ProgramProduct>();
    public virtual IReadOnlyCollection<ProgramProduct> ProgramProducts => _programProducts;

}
