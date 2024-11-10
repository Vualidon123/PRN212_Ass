using System;
using System.Collections.Generic;

namespace BO;

public partial class Pond
{
    public int PondId { get; set; }

    public double? Depth { get; set; }

    public int? Drain { get; set; }

    public string? Location { get; set; }

    public int? NumberOfFish { get; set; }

    public byte[]? Picture { get; set; }

    public string? Name { get; set; }

    public int? PumpingCapacity { get; set; }

    public int? Skimmers { get; set; }

    public double? Volume { get; set; }

    public string? WaterSource { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<GrowthRecord> GrowthRecords { get; set; } = new List<GrowthRecord>();

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();

    public virtual User? User { get; set; }

    public virtual ICollection<WaterMonitor> WaterMonitors { get; set; } = new List<WaterMonitor>();
}
