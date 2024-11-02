using System;
using System.Collections.Generic;

namespace BO;

public partial class GrowthRecord
{
    public DateOnly Date { get; set; }

    public double? Length { get; set; }

    public double? LengthRate { get; set; }

    public string? Physique { get; set; }

    public DateTime? UpdateAt { get; set; }

    public double? Weight { get; set; }

    public double? WeightRate { get; set; }

    public int KoiFishKoiFishId { get; set; }

    public virtual KoiFish KoiFishKoiFish { get; set; } = null!;
}
