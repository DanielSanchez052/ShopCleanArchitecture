using Shop.Application.Primitives;

namespace Shop.Application.Account;

public static class Errors
{
    public static class Account
    {
        public static Error NotFound = new Error("Account.NotFound", "Account specified not found");
        public static Error CouldNotSave = new Error("Account.CouldNotSave", "Account could not be saved");
    }

    public static class Address
    {
        public static Error NotFound = new Error("Address.NotFound", "Address specified not found");
        public static Error CouldNotSave = new Error("Address.CouldNotSave", "Address could not be saved");
        public static Error Empty = new Error("Address.Empty", "Address cannot be empty");
    }
}
