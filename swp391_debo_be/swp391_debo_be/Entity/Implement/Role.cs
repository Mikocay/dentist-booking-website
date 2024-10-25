using System;
using System.Collections.Generic;

namespace swp391_debo_be.Entity.Implement;

public partial class Role
{
    public int RoleId { get; set; }

    public string? Role1 { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
