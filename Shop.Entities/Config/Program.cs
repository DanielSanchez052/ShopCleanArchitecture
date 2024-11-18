using Shop.Entities.Catalog;

namespace Shop.Entities.Config;

public class Program
{
    public Program(int id, string name, bool isActive, string? config, DateTime startDate, DateTime endDate, DateTime createDate)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
        Config = config;
        StartDate = startDate;
        EndDate = endDate;
        CreateDate = createDate;
    }

    public Program()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsActive { get; set; }
    public string? Config { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreateDate { get; set; }

    private readonly List<ProgramProduct> _programProducts = new List<ProgramProduct>();
    public virtual IReadOnlyCollection<ProgramProduct> ProgramProducts => _programProducts;

    private readonly List<Category> _categories = new List<Category>();
    public virtual IReadOnlyCollection<Category> Categories => _categories;
}
