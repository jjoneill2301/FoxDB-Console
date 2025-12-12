using System;
using System.Collections.Generic;

namespace FoxDB.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public double UnitPrice { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
