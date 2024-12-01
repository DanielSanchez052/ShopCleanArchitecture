using Shop.Application.Primitives;

namespace Shop.Application.Catalog;

public partial class Errors
{
    public static class ProgramProduct
    {
        public static Error AlreadyExists = new Error("ProgramProduct.AlreadyExists", "Product already exists in program");
        public static Error NotFound = new Error("ProgramProduct.NotFound", "Product specified not found in program");
        public static Error CouldNotSave = new Error("ProgramProduct.CouldNotSave", "Product could not be saved");
    }

    public static class Product
    {
        public static Error NotFound = new Error("Product.NotFound", "Product specified not found");
        public static Error CouldNotSave = new Error("Product.CouldNotSave", "Product could not be saved");
    }
    public static class ProductType
    {
        public static Error NotFound = new Error("ProductType.NotFound", "Product type not found.");
    }

    public static class ProductReference
    {
        public static Error CouldNotSave = new Error("ProductReference.CouldNotSave", "Product referencecould not be saved.");
    }
}
