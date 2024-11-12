using Gestion_Dette.entites;
using Gestion_Dette.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.View
{
    public abstract class ArticleView 
    {
        public static void ListArticles(List<Article> articles)
        {
            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }
        }
        public static Article CreateArticle()
        {
            Article article = new Article();

            Console.Write("Entrez le libellé : ");
            article.Libelle = Console.ReadLine();

            Console.Write("Entrez la référence : ");
            article.Reference = Console.ReadLine();

            Console.Write("Entrez la quantité en stock : ");
            article.QteStock = Convert.ToInt32(Console.ReadLine());

            Console.Write("Entrez le prix : ");
            article.Prix = Convert.ToDouble(Console.ReadLine());

            return article;
        }

        // Met à jour un article existant
        public static void UpdateArticle(Article article)
        {
            Console.Write("Nouveau libellé : ");
            article.Libelle = Console.ReadLine();

            Console.Write("Nouvelle référence : ");
            article.Reference = Console.ReadLine();

            Console.Write("Nouvelle quantité en stock : ");
            article.QteStock = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nouveau prix : ");
            article.Prix = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Article mis à jour !");
        }

        // Demande à l'utilisateur si un article doit être supprimé
        public static int DeleteArticle()
        {
            Console.Write("Voulez-vous supprimer un article ? (o/n) ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "o")
            {
                Console.Write("Id de l'article à supprimer : ");
                return Convert.ToInt32(Console.ReadLine());
            }
            return 0;
        }

        // Saisie de l'ID de l'article
        public static int SaisirId()
        {
            Console.WriteLine("Id de l'article ?");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Saisie d'un article via le service (selon l'interface)
        public Article Saisir(IArticleService articleService)
        {
            Article article = new Article();

            Console.Write("Entrez le libellé : ");
            article.Libelle = Console.ReadLine();

            Console.Write("Entrez la référence : ");
            article.Reference = Console.ReadLine();

            Console.Write("Entrez la quantité en stock : ");
            article.QteStock = Convert.ToInt32(Console.ReadLine());

            Console.Write("Entrez le prix : ");
            article.Prix = Convert.ToDouble(Console.ReadLine());

            return article;
        }
    }
}
