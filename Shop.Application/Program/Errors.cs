using Shop.Application.Primitives;

namespace Shop.Application.Program;

public partial class Errors
{
    public static class Program
    {
        public static Error NotFound = new Error("Program.NotFound", "program specified was not found");
    }
}
