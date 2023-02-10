using System;
using System.Collections.Generic;

namespace EFCoreScaffoldexample.Models;

public partial class UsersTest
{
    public int IdUsersTest { get; set; }

    public int? UsersIdTest { get; set; }

    public virtual UsersInfo? UsersIdTestNavigation { get; set; }
}
