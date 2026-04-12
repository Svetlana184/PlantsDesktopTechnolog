using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class StepParameter
{
    public int IdParam { get; set; }

    public int IdStep { get; set; }

    public string NameParam { get; set; } = null!;

    public decimal TargetValue { get; set; }

    public decimal MinValue { get; set; }

    public decimal MaxValue { get; set; }

    public string? Unit { get; set; }

}
