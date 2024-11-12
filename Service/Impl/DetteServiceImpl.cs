using Gestion_Dette.entites;
using Gestion_Dette.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Service.Impl
{
    public class DetteServiceImpl : IDetteService
    {
        private readonly IDetteRepository detteRepository;

        public DetteServiceImpl(IDetteRepository detteRepository)
        {
            this.detteRepository = detteRepository;
        }

        public List<Dette> FindAll()
        {
            return detteRepository.SelectAll();
        }

        public Dette FindById(long id)
        {
            return detteRepository.SelectById(id);
        }

        public void Save(Dette dette)
        {
            detteRepository.Insert(dette);
        }

        public void Delete(long id)
        {
            detteRepository.Delete(id);
        }

        public void Update(Dette dette)
        {
            detteRepository.Update(dette);
        }

    }
}
