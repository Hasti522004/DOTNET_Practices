﻿using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach_EF.Models;

public partial class Role
{
    public short RoleId { get; set; }

    public string RoleDesc { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
