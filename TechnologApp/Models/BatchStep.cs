using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class BatchStep
{
    public int IdExecution { get; set; }

    public int IdProductionBatch { get; set; }

    public int IdStep { get; set; }

    public string? Status { get; set; }

    public int? StartedBy { get; set; }

    public DateTime? StartedAt { get; set; }

    public int? FinishedBy { get; set; }

    public DateTime? FinishedAt { get; set; }

    public string? Comment { get; set; }

}
