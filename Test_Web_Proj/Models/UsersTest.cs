using System;
using System.Collections.Generic;

namespace Test_Web_Proj.Models;

public partial class UsersTest
{
    public int IdUsersTest { get; set; }

    public int? UsersIdTest { get; set; }

    public virtual UsersInfo? UsersIdTestNavigation { get; set; }
}
