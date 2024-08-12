using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Category
{
    public Guid Id { get; set; }

    public string? Slug { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
