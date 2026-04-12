using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class Department
{
    public int IdDepartment { get; set; }

    public string NameDepartment { get; set; } = null!;

    public int? IdParentDepartment { get; set; }

}
