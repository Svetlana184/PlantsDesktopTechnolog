using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class User
{
    public int IdUser { get; set; }

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string LastName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int IdDepartment { get; set; }

}
