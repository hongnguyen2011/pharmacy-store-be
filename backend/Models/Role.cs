using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Role
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
