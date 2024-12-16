namespace Shop.Infrastructure.Config;

public class ProgramContext
{
    public ProgramContext(int id, string name, string slug, DateTime startDate, DateTime endDate)
    {
        Id = id;
        Slug = slug;
        StartDate = startDate;
        EndDate = endDate;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
