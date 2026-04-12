using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plants.API;

public partial class ProductionBatch
{
    public int IdBatch { get; set; }

    public string BatchNumber { get; set; } = null!;

    public int IdProduct { get; set; }

    public int IdRecipe { get; set; }

    public int IdMap { get; set; }

    public int? IdEquipment { get; set; }

    public decimal PlannedQuantity { get; set; }

    public decimal? ActualQuantity { get; set; }

    public string? Status { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

}
