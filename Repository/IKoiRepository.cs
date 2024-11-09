using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace Repository
{
    public interface IKoiRepository
    {
        public void CreateKoi(KoiFish koi);
        public void UpdateKoi(KoiFish koi);
        public void DeleteKoi(KoiFish koi);
        public List<KoiFish> GetKois();
        public KoiFish GetKoi(int id);
    }
}
