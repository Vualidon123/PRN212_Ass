using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IWaterMonitorService
    {
        public List<WaterMonitor> GetWaterMonitors();

        public WaterMonitor GetWaterMonitorById(int id);

        public void CreateWaterMonitor(WaterMonitor water);

        public void DeleteWaterMonitor(WaterMonitor water);

        public void UpdateWaterMonitor(WaterMonitor water);
    }
}
