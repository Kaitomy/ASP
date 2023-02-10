using System;
using System.Collections.Generic;

namespace Test_Web_Proj.Models;

public partial class Role
{
    public int IdRoles { get; set; }

    public string RolesName { get; set; } = null!;

    public virtual ICollection<UsersInfo> UsersInfos { get; } = new List<UsersInfo>();
}
