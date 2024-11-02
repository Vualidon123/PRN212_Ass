using BO;
using DataAccessLayer;

namespace Repository
{
    public class KoiRepository : IKoiRepository
    {
        public void CreateKoi(KoiFish koi)=>KoiDAO.CreatKoi(koi);
        public void DeleteKoi(KoiFish koi) => KoiDAO.DeleteKoi(koi);
        public KoiFish GetKoi(int id)=>KoiDAO.GetKoiFishById(id);        
        public List<KoiFish> GetKois()=>KoiDAO.GetKois();     
        public void UpdateKoi(KoiFish koi) => KoiDAO.UpdateKoi(koi);

    }
}
