using System;
using System.Collections.Generic;

namespace Test_Web_Proj.Models;

public partial class UsersInfo
{
    public string UsersInfoFio { get; set; } = null!;

    public string UsersInfoLastName { get; set; } = null!;

    public string UsersInfoName { get; set; } = null!;

    public string? UsersInfoMiddleName { get; set; }

    public DateTime UsersInfoDateBirthday { get; set; }

    public DateTime UsersInfoDateStartWork { get; set; }

    public DateTime UsersInfoDateStartWorkMpt { get; set; }

    public DateTime UsersInfoDateStartWorkTeacher { get; set; }

    public int UsersSId { get; set; }

    public int RolesId { get; set; }

    public virtual Role Roles { get; set; } = null!;

    public virtual User UsersS { get; set; } = null!;

    public virtual ICollection<UsersTest> UsersTests { get; } = new List<UsersTest>();
}
