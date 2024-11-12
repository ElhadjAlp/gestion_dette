using Gestion_Dette.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Repository.Impl
{
    public class ArticleRepositoryListImpl : IArticleRepository
    {
        private readonly List<Article> articles = new List<Article>();

        public Article SelectById(int id)
        {
            foreach (var article in articles)
            {
                if (article.Id == id)
                    return article;
            }
            return null; 
        }

        public Article FindByArticle(string reference)
        {
            return articles.Find(cl => cl.Reference.ToLower() == reference.ToLower());
        }

        public void Insert(Article article)
        {
            articles.Add(article);
        }

        public List<Article> SelectAll()
        {
            return articles;
        }

        public void Update(Article article)
        {

                int position = articles.FindIndex(cl => cl.Id == article.Id);
                if (position != -1)
                    articles[position] = article;
            
        }

    }
}
