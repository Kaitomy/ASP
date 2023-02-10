using System;
using System.Collections.Generic;

namespace Test_Web_Proj.Models;

public partial class User
{
    public int IdUsers { get; set; }

    public string UsersLogin { get; set; } = null!;

    public string UsersPassword { get; set; } = null!;

    public string UsersEmail { get; set; } = null!;

    public string UsersStatus { get; set; } = null!;

    public virtual UsersInfo? UsersInfo { get; set; }
}
