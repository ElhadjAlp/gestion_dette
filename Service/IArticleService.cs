using Gestion_Dette.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Service
{
    public interface IArticleService
    {
        void Insert(Article article);               
        List<Article> FindAll();                    
        Article FindById(int id);                   
        Article FindByArticle(string reference);
        void Update(Article article);
    }
}
