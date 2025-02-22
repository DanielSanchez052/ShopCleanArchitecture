﻿namespace Shop.Infrastructure.Customer.ViewModel;

public class AddressViewModel
{
    public int Id { get; set; }
    public string? RawValue { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? ZipCode { get; set; }
    public string? HouseNumber { get; set; }
    public bool IsDefault { get; set; }
    public bool IsActive { get; set; }
}
