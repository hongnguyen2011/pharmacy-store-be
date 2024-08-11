using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Imageproduct
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid IdProduct { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;
}
