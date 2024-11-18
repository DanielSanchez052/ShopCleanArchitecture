namespace Shop.Entities.Digital;

public class ExpirationType
{
    public ExpirationType(string name, string? config, bool isActive)
    {
        Name = name;
        Config = config;
        IsActive = isActive;
    }

    public ExpirationType()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Config { get; set; }
    public bool IsActive { get; set; }

    private readonly List<Code> _codes = new List<Code>();


    public virtual IReadOnlyCollection<Code> Codes => _codes;
}
