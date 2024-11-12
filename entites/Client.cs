using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.entites
{
    public class Client
    {
      

        public long Id { get; set; }
        public string Surnom { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public List<Dette> Dettes { get; } = new List<Dette>();
        public List<Article> Articles { get; } = new List<Article>(); 

        
        public void AddDette(Dette dette)
        {
           
            Dettes.Add(dette);
            dette.Id = Dettes.Count;
            
            dette.Client = this;
        }

       
        public void AddArticle(Article article)
        {
            
            Articles.Add(article);
            article.Id = Articles.Count;
            
            article.Client = this;
        }

        public override string ToString()
        {
            string clientInfo = $"Client[id={Id}, surnom='{Surnom}', telephone='{Telephone}', adresse='{Adresse}']";
         
            if (Articles.Count > 0)
            {
                clientInfo += "\nArticles:\n";
                foreach (var article in Articles)
                {
                    clientInfo += article.ToString() + "\n";
                }
            }
            return clientInfo;
        }

        public bool Equals(Client other)
        {
            if (this == other) return true;
            if (other == null) return false;
            Client client = (Client)other;
            return Id == client.Id &&
                    Object.Equals(Surnom, client.Surnom) &&
                    Object.Equals(Telephone, client.Telephone) &&
                    Object.Equals(Adresse, client.Adresse);
        }
    }
}
