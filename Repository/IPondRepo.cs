using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPondRepo
    {
        public void CreatePond(Pond pond);
        public void UpdatePond(Pond pond);
        public void DeletePond(Pond pond);
        public List<Pond> GetAllPond();
        Pond GetPondById(int id);
    }
}
