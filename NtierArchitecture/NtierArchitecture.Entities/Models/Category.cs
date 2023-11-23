using NtierArchitecture.Entities.Abstractions;

namespace NtierArchitecture.Entities.Models;

public sealed class Category : Entity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set;}
}