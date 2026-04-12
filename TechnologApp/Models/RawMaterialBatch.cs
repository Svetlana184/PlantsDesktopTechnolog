using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class RawMaterialBatch
{
    public int IdBatch { get; set; }

    public string BatchNumber { get; set; } = null!;

    public int IdRawMaterial { get; set; }

    public decimal Quantity { get; set; }

    public string? Status { get; set; }

}
