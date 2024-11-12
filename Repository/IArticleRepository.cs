using Gestion_Dette.Core;
using Gestion_Dette.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Repository
{
    public interface IArticleRepository
    {
        Article SelectById(int id);            
        Article FindByArticle(string reference); 
        void Insert(Article article);          
        List<Article> SelectAll();              
        void Update(Article article);
    }
}
