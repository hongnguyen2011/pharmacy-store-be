using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Detailorder
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public Guid? IdOrder { get; set; }

    public Guid? IdProduct { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
