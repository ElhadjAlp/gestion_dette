using Gestion_Dette.entites;
using Gestion_Dette.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Service.Impl
{
    public class ArticleServiceImpl : IArticleService
    {
        private readonly IArticleRepository articleRepository;

        public ArticleServiceImpl(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public void Insert(Article article)
        {
            articleRepository.Insert(article);
        }

        public List<Article> FindAll()
        {
            return articleRepository.SelectAll();
        }

        public Article FindById(int id)
        {
            return articleRepository.SelectById(id);
        }

        public Article FindByArticle(string reference)
        {
            return articleRepository.FindByArticle(reference);
        }


        public void Update(Article article)
        {
            articleRepository.Update(article);
        }
    }
}
