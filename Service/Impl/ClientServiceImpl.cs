﻿using Gestion_Dette.entites;
using Gestion_Dette.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Service.Impl
{
    public class ClientServiceImpl : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientServiceImpl(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public List<Client> FindAll()
        {
            return clientRepository.SelectAll();
        }

        public Client FindById(long id)
        {
            return clientRepository.SelectById(id);
        }

        public void Save(Client client)
        {
            clientRepository.Insert(client);
        }

        public void Delete(long id)
        {
            clientRepository.Delete(id);
        }

        public void Update(Client client)
        {
            clientRepository.Update(client);
        }

        public Client FindBySurname(string surnom)
        {
            return clientRepository.FindBySurname(surnom);
        }

    }
}
