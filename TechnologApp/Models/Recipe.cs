using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class Recipe
{
    public int IdRecipe { get; set; }

    public int IdProduct { get; set; }

    public int VersionNumber { get; set; }

    public string? Status { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

}
