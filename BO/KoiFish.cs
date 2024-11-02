using System;
using System.Collections.Generic;

namespace BO;

public partial class KoiFish
{
    public int KoiFishId { get; set; }

    public int? Age { get; set; }

    public string? Breeder { get; set; }

    public byte[]? Image { get; set; }

    public DateOnly? InPondSince { get; set; }

    public string? Name { get; set; }

    public double? Length { get; set; }

    public string? Origin { get; set; }

    public string? Physique { get; set; }

    public decimal? Price { get; set; }

    public string? Sex { get; set; }

    public string? Variety { get; set; }

    public double? Weight { get; set; }

    public int? PondId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<GrowthRecord> GrowthRecords { get; set; } = new List<GrowthRecord>();

    public virtual Pond? Pond { get; set; }

    public virtual User? User { get; set; }
}
