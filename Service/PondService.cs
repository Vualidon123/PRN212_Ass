using BO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PondService : IPondService
    {
        private readonly IPondRepo pondRepo;
        public void CreatePond(Pond pond)
        => pondRepo.CreatePond(pond);

        public void DeletePond(Pond pond)
        => pondRepo.DeletePond(pond);

        public List<Pond> GetAllPond()
        => pondRepo.GetAllPond();

        public Pond GetPondById(int id)
        => pondRepo.GetPondById(id);

        public void UpdatePond(Pond pond)
        => pondRepo.UpdatePond(pond);
    }
}
