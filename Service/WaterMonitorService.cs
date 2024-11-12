using BO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class WaterMonitorService : IWaterMonitorService
    {
        private readonly WaterMonitorRepo repo;
        public WaterMonitorService()
        {
            repo = new WaterMonitorRepo();
        }

        public void CreateWaterMonitor(WaterMonitor water)
        {
           repo.CreateWaterMonitor(water);
        }

        public void DeleteWaterMonitor(WaterMonitor water)
        {
            repo.DeleteWaterMonitor(water);
        }

        public WaterMonitor GetWaterMonitorById(int id)
        {
           return repo.GetWaterMonitorById(id);
        }

        public List<WaterMonitor> GetWaterMonitors()
        {
            return repo.GetWaterMonitors();
        }

        public void UpdateWaterMonitor(WaterMonitor water)
        {
            repo.UpdateWaterMonitor(water);
        }
    }
}
