using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class LabTest
{
    public int IdTest { get; set; }

    public string TestNumber { get; set; } = null!;

    public int? IdRawMaterialBatch { get; set; }

    public int? IdProductionBatch { get; set; }

    public string? Status { get; set; }

    public int? AssignedTo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public string? Conclusion { get; set; }

    public string? Comment { get; set; }

}
