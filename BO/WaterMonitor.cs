using System;
using System.Collections.Generic;

namespace BO;

public partial class WaterMonitor
{
    public long Id { get; set; }

    public float Co2 { get; set; }

    public float Ammonium { get; set; }

    public float AmountFed { get; set; }

    public float CarbonHardnesskh { get; set; }

    public DateTime? DateTime { get; set; }

    public float Hardnessgh { get; set; }

    public float Nitrate { get; set; }

    public float Nitrite { get; set; }

    public int OutdoorTemperature { get; set; }

    public float Oxygen { get; set; }

    public float Ph { get; set; }

    public float Phosphate { get; set; }

    public float Salt { get; set; }

    public int Temperature { get; set; }

    public float TotalChlorine { get; set; }

    public int PondId { get; set; }

    public virtual Pond Pond { get; set; } = null!;
}
