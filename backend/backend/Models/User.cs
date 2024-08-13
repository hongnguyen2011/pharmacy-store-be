using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Name { get; set; }

    public string Password { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? PathImg { get; set; }

    public Guid? IdRole { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
