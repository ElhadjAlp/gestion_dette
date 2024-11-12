using Gestion_Dette.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.View
{
    public abstract class ClientView
    {
        public static void ListClients(List<Client> clients)
        {
            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
        }

        public static void ListDetteClient(Client client)
        {
            foreach (var dette in client.Dettes)
            {
                Console.WriteLine(dette);
            }
        }

        public static void ListArticlesClient(Client client)
        {
            foreach (var article in client.Articles)
            {
                Console.WriteLine(article);
            }
        }

        public static Client CreateClient()
        {
            Console.Write("Surnom : ");
            string surnom = Console.ReadLine();
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine();
            Console.Write("Adresse : ");
            string adresse = Console.ReadLine();

            Client client = new Client
            {
                Surnom = surnom,
                Telephone = telephone,
                Adresse = adresse
            };

            AddDetteToClient(client);
            AddArticleToClient(client);

            return client;
        }

        public static void UpdateClient(Client client)
        {
            Console.Write("Nouveau surnom : ");
            string newSurnom = Console.ReadLine();
            Console.Write("Nouveau téléphone : ");
            string newTelephone = Console.ReadLine();
            Console.Write("Nouvelle adresse : ");
            string newAdresse = Console.ReadLine();
            client.Surnom = newSurnom;
            client.Telephone = newTelephone;
            client.Adresse = newAdresse;
            Console.WriteLine("Client modifié!");
        }

        public static int DeleteClient()
        {
            Console.Write("Voulez-vous supprimer un client ? (o/n) ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "o")
            {
                Console.Write("Id du client à supprimer : ");
                return Convert.ToInt32(Console.ReadLine());
            }
            return 0;
        }

        public static int SaisirId()
        {
            Console.WriteLine("Id du client ?");
            return Convert.ToInt32(Console.ReadLine());
        }

        private static void AddDetteToClient(Client client)
        {
            while (true)
            {
                Console.Write("Voulez-vous ajouter une dette à ce client ? (o/n) ");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "o")
                {
                    float montant = SaisirMontant();
                    Dette dette = new Dette { Montant = montant };
                    client.AddDette(dette);
                }
                else if (answer.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Option invalide. Veuillez saisir 'o' pour oui ou 'n' pour non.");
                }
            }
        }

        private static void AddArticleToClient(Client client)
        {
            while (true)
            {
                Console.Write("Voulez-vous ajouter un article à ce client ? (o/n) ");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "o")
                {
                    Article article = SaisirArticle();
                    client.AddArticle(article);
                }
                else if (answer.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Option invalide. Veuillez saisir 'o' pour oui ou 'n' pour non.");
                }
            }
        }

        private static float SaisirMontant()
        {
            float montant;
            while (true)
            {
                Console.Write("Montant de la dette : ");
                if (float.TryParse(Console.ReadLine(), out montant) && montant > 0)
                {
                    return montant;
                }
                Console.WriteLine("Montant invalide. Merci de saisir un montant positif.");
            }
        }

        public static Article SaisirArticle()
        {
            Console.Write("Libelle de l'article : ");
            string libelle = Console.ReadLine();
            Console.Write("Référence de l'article : ");
            string reference = Console.ReadLine();

            int qteStock;
            while (true)
            {
                Console.Write("Quantité en stock de l'article : ");
                if (int.TryParse(Console.ReadLine(), out qteStock) && qteStock >= 0)
                {
                    break;
                }
                Console.WriteLine("Quantité invalide. Veuillez entrer un nombre entier positif.");
            }

            double prix;
            while (true)
            {
                Console.Write("Prix de l'article : ");
                if (double.TryParse(Console.ReadLine(), out prix) && prix > 0)
                {
                    break;
                }
                Console.WriteLine("Prix invalide. Veuillez entrer un prix positif.");
            }

            Article article = new Article
            {
                Libelle = libelle,
                Reference = reference,
                QteStock = qteStock,
                Prix = prix
            };

            return article;
        }
    }
}