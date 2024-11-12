using Gestion_Dette.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Repository.Impl
{
    public class DetteRepositoryListImpl : IDetteRepository
    {
        private readonly List<Dette> dettes = new List<Dette>();
        public void Delete(long id)
        {
            Dette detteToRemove = dettes.Find(d => d.Id == id);
            if (detteToRemove != null)
                dettes.Remove(detteToRemove);
        }

        public void Insert(Dette entity)
        {
            dettes.Add(entity);
        }

        public List<Dette> SelectAll()
        {
            return dettes;
        }

        public Dette SelectById(long id)
        {
            return dettes.Find(dette => dette.Id == id);
        }

        public void Update(Dette entity)
        {
            int position = dettes.FindIndex(cl => cl.Id == entity.Id);
            if (position != -1)
                dettes[position] = entity;
        }
    }
}
