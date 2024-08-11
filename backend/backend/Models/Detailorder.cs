using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Detailorder
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public Guid IdOrder { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
