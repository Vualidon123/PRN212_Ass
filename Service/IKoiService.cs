using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
namespace Service
{
    public interface IKoiService
    {
         void CreateKoi(KoiFish koi);
         void UpdateKoi(KoiFish koi);
         void DeleteKoi(KoiFish koi);
         List<KoiFish> GetKois();
         KoiFish GetKoi(int id);
    }
}
