using BO;
using Repository;

namespace Service
{
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _repository;
        public void CreateKoi(KoiFish koi)
        {
            _repository.CreateKoi(koi);
        }

        public void DeleteKoi(KoiFish koi)
        {
            _repository.DeleteKoi(koi);
        }

        public KoiFish GetKoi(int id)
        {
            return _repository.GetKoi(id);
        }

        public List<KoiFish> GetKois()
        {
           return _repository.GetKois();   
        }

        public void UpdateKoi(KoiFish koi)
        {
            _repository.UpdateKoi(koi);
        }
    }
}
