using BO;
using Microsoft.EntityFrameworkCore;
namespace DataAccessLayer
{
    public class KoiDAO
    {
        public static List<KoiFish> GetKois()
        {
           
          using var context = new TestyContext();
          return context.KoiFishes.ToList();        
           
        }
    
    public static void CreatKoi(KoiFish koi)
    {
        try
        {
            using var context = new TestyContext();
            context.KoiFishes.Add(koi);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
        public static void UpdateKoi(KoiFish koi)
        {
            try
            {
                using var context = new TestyContext();
                context.Entry<KoiFish>(koi).State
                    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
       public static void DeleteKoi(KoiFish koi)
       {
            try
            {
                using var context = new TestyContext();
                var p1=context.KoiFishes.SingleOrDefault(k=>k.KoiFishId==koi.KoiFishId );    
                context.KoiFishes.Remove(p1);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
       }
        public static KoiFish GetKoiFishById(int id)
        {
            using var context = new TestyContext();
            return context.KoiFishes.SingleOrDefault(c => c.KoiFishId == id);
        }
    }
}