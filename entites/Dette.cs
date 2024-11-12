using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.entites
{
    public class Dette
    {
        

        public DateTime Date { get; set; } = DateTime.Now; 
        public float Montant { get; set; }
        public long Id { get; set; }

        
        public Client Client { get; set; }


        public override string ToString()
        {
            return $"Dette n°{Id}, du {Date:dd/MM/yyyy} pour {Montant}";
        }


    }
}
