using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class Product
{
    public int idProduct { get; set; }

    public string code { get; set; } = null!;

    public string nameProduct { get; set; } = null!;

    public string type { get; set; } = null!;

    public string form { get; set; } = null!;

    public string? status { get; set; }

}
