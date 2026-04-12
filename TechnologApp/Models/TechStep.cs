using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class TechStep
{
    public int IdStep { get; set; }

    public int IdMap { get; set; }

    public int StepOrder { get; set; }

    public string NameStep { get; set; } = null!;

    public string? Description { get; set; }

    public bool? IsMandatory { get; set; }

}
