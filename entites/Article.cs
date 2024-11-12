using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.entites
{
    public class Article
    {
        public int Id { get; set; }

        public string Libelle { get; set; }
        public string Reference { get; set; }
        public int QteStock { get; set; }
        public double Prix { get; set; }


        public Client Client { get; set; }


        private static int nbr;

        //public List<Detail> Detail { get; set; } = new List<Detail>();

        public Article()
        {
            this.Id = ++nbr;
        }

        public void SetQuantite(int quantite)
        {
            this.QteStock = quantite;
        }

        public void SetPrixVente(double prixVente)
        {
            this.Prix = prixVente;
        }
    }
}
