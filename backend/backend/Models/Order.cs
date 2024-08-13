using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Order
{
    public Guid Id { get; set; }

    public int? Status { get; set; }

    public decimal? Total { get; set; }

    public DateTime CreateAt { get; set; }

    public Guid? IdUser { get; set; }

    public virtual ICollection<Detailorder> Detailorders { get; set; } = new List<Detailorder>();
}
