﻿using NtierArchitecture.Entities.Abstractions;
using System.ComponentModel;

namespace NtierArchitecture.Entities.Models;


public sealed class Product : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }
}
