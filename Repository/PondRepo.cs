using BO;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PondRepo : IPondRepo
    {
        public void CreatePond(Pond pond)
        => PondDAO.Addpond(pond);

        public void DeletePond(Pond pond)
        => PondDAO.DeletePond(pond);

        public List<Pond> GetAllPond()
        => PondDAO.GetPonds();

        public Pond GetPondById(int id)
        => PondDAO.GetPondById(id);

        public void UpdatePond(Pond pond)
        => PondDAO.Updatepond(pond);
    }
}
