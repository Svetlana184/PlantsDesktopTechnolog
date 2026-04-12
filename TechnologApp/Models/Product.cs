using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Code { get; set; } = null!;

    public string NameProduct { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Form { get; set; } = null!;

    public string? Status { get; set; }

}
