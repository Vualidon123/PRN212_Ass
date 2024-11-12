using BO;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WaterMonitorRepo : IWaterMonitorRepo
    {
        public void CreateWaterMonitor(WaterMonitor water)=>WaterMonitorDAO.CreateWaterMonitor(water);
       

        public void DeleteWaterMonitor(WaterMonitor water) => WaterMonitorDAO.DeleteWaterMonitor(water);


        public WaterMonitor GetWaterMonitorById(int id) => WaterMonitorDAO.GetWaterMonitorById(id);


        public List<WaterMonitor> GetWaterMonitors(int pondid) => WaterMonitorDAO.GetWaterMonitors(pondid);


        public void UpdateWaterMonitor(WaterMonitor water) => WaterMonitorDAO.UpdateWaterMonitor(water);

    }
}
