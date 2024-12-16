using Shop.Entities.Config;
using System.Dynamic;

namespace Shop.Entities.Payment;

public class PaymentRules
{
    public PaymentRules()
    {
    }

    public PaymentRules(string name, decimal factor, bool autoCalulated, bool isActive)
    {
        Name = name;
        Factor = factor;
        AutoCalulated = autoCalulated;
        IsActive = isActive;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public decimal Factor { get; private set; }
    public bool AutoCalulated { get; private set; }
    public bool IsActive { get; private set; }
    public Program Program { get; set; }
    public int ProgramId { get; set; }

    public int GetPointValue(decimal amount) => (int)(Math.Floor(amount * Factor));
}
