using System;
using System.Collections.Generic;

namespace EFCoreScaffoldexample.Models;

public partial class Role
{
    public int IdRoles { get; set; }

    public string RolesName { get; set; } = null!;

    public virtual ICollection<UsersInfo> UsersInfos { get; } = new List<UsersInfo>();
}
