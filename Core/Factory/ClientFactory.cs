using Gestion_Dette.Enum;
using Gestion_Dette.Repository.BD.Impl;
using Gestion_Dette.Repository.Impl;
using Gestion_Dette.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_Dette.Repository.Drapper.Impl;

namespace Gestion_Dette.Core.Factory
{
    public static class ClientFactory
    {
        public static IClientRepository createClientRepository(Persistence type)
        {
            IClientRepository clientRepository;
            switch (type)
            {
                case Persistence.DATABASE:
                    clientRepository = new ClientRepositoryBdImpl(new DataBaseConnection());
                    break;
                case Persistence.LIST:
                    clientRepository = new ClientRepositoryListImpl();
                    break;
                case Persistence.DAPPER:
                    clientRepository = new ClientRepositoryDapperImpl("Server=localhost;Port=3306;Database=gestion_dette_csharp;User ID=root;Password=;");
                    break;
                default:
                    clientRepository = null;
                    break;
            }
            return clientRepository;
        }
    }
}
