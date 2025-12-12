using System;
using System.Collections.Generic;

namespace FoxDB.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerIdFk { get; set; }

    public int? ProductIdFk { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public DateOnly? OrderDate { get; set; }

    public virtual Customer? CustomerIdFkNavigation { get; set; }

    public virtual Product? ProductIdFkNavigation { get; set; }
}
