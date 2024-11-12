using Gestion_Dette.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Service
{
    public interface IClientService
    {
        List<Client> FindAll();
        Client FindById(long id);
        void Save(Client client);
        void Delete(long id);
        void Update(Client client);

        Client FindBySurname(string surnom);

        //

    }
}
