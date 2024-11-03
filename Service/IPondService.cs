using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPondService
    {
        public void CreatePond(Pond pond);
        public void UpdatePond(Pond pond);
        public void DeletePond(Pond pond);
        public List<Pond> GetAllPond();
        Pond GetPondById(int id);
    }
}
