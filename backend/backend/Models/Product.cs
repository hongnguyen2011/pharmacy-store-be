using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Detail { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public string Type { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public Guid? IdUser { get; set; }

    public Guid? IdCategory { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Imageproduct> Imageproducts { get; set; } = new List<Imageproduct>();
}
