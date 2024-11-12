using Gestion_Dette.Core;
using Gestion_Dette.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Repository
{
    public interface IClientRepository : IRepository<Client>
    {
        Client FindBySurname(String surnom);
    }
}
