using Gestion_Dette.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Service
{
    public interface IDetteService
    {
        List<Dette> FindAll();
        Dette FindById(long id);
        void Save(Dette dette);
        void Delete(long id);
        void Update(Dette dette);



    }
}
