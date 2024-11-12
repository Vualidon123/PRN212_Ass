using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class WaterMonitorDAO
    {

        public static List<WaterMonitor> GetWaterMonitors(int pondId)
        {
            var list = new List<WaterMonitor>();
            try
            {
                using var context = new TestyContext();
                list = context.WaterMonitors
                    .Where(wm => wm.PondId == pondId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        
        public static WaterMonitor GetWaterMonitorById(int id)
        {


            using var context = new TestyContext();
            return context.WaterMonitors.FirstOrDefault(x => x.Id == id);

        }
        public static void CreateWaterMonitor(WaterMonitor water)
        {
            try
            {
                using var context = new TestyContext();
                context.WaterMonitors.Add(water);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteWaterMonitor(WaterMonitor water)
        {
            try
            {
                using var context = new TestyContext();
                var p1 = context.WaterMonitors.SingleOrDefault(x => x.Id == water.Id);
                context.Remove(p1);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void UpdateWaterMonitor(WaterMonitor water)
        {
            try
            {
                using var context = new TestyContext();
                context.Entry<WaterMonitor>(water).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
