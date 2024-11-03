using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PondDAO
    {
        public static List<Pond> GetPonds()
        {
            var PondList = new List<Pond>();
            try
            {
                using var context = new TestyContext();
                PondList = context.Ponds.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return PondList;
        }

        public static void Addpond(Pond pond)
        {
            try
            {
                using var context = new TestyContext();
                context.Ponds.Add(pond);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void DeletePond(Pond pond)
        {
            try
            {
                using var context = new TestyContext();
                var p = context.Ponds.SingleOrDefault(r => r.PondId == pond.PondId);
                context.Remove(p);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Updatepond(Pond pond)
        {
            try
            {
                using var context = new TestyContext();
                context.Entry<Pond>(pond).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static Pond GetPondById(int id)
        {
            using var context = new TestyContext();
            return context.Ponds.SingleOrDefault(c => c.PondId == id);
        }
    }
}
