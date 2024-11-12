using Gestion_Dette.Core;
using Gestion_Dette.entites;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Repository.BD.Impl
{
    public class ClientRepositoryBdImpl : IClientRepository
    {
        private readonly IDataAcess dataAcess;
        public ClientRepositoryBdImpl(IDataAcess dataAcess)
        {
            this.dataAcess = dataAcess;
        }

        public void Delete(long id)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "DELETE FROM client WHERE client.id = @id;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Client deleted successfully.");
                }
            }
        }

        public Client FindBySurname(string surnom)
        {
            Client client = null;
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM client WHERE surnom = @surnom";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@surnom", surnom);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            client = new Client()
                            {
                                Id = reader.GetInt64("id"),  
                                Surnom = reader.GetString("surnom"),
                                Telephone = reader.GetString("telephone"),
                                Adresse = reader.GetString("adresse")
                            };
                        }
                    }
                }
            }
            return client;
        }

        public void Insert(Client entity)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "INSERT INTO client (surnom, telephone, adresse, create_at, update_at) VALUES (@surnom, @telephone, @adresse, @createAt, @updateAt)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@surnom", entity.Surnom);
                    cmd.Parameters.AddWithValue("@telephone", entity.Telephone);
                    cmd.Parameters.AddWithValue("@adresse", entity.Adresse);
                    cmd.Parameters.AddWithValue("@createAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    entity.Id = (long)cmd.LastInsertedId;
                    Console.WriteLine("Client added successfully.");
                }
            }
        }

        public List<Client> SelectAll()
        {
            List<Client> clients = new List<Client>();
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM client";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client()
                            {
                                Id = reader.GetInt64("id"),  
                                Surnom = reader.GetString("surnom"),
                                Telephone = reader.GetString("telephone"),
                                Adresse = reader.GetString("adresse")
                            });
                        }
                    }
                }
            }
            return clients;
        }

        public Client SelectById(long id)
        {
            Client client = null;
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM client WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            client = new Client()
                            {
                                Id = reader.GetInt64("id"),  
                                Surnom = reader.GetString("surnom"),
                                Telephone = reader.GetString("telephone"),
                                Adresse = reader.GetString("adresse")
                            };
                        }
                    }
                }
            }
            return client;
        }

        public void Update(Client entity)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "UPDATE client SET adresse = @adresse, surnom = @surnom, telephone = @telephone WHERE client.id = @id;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", (Int64)entity.Id);
                    cmd.Parameters.AddWithValue("@surnom", entity.Surnom);
                    cmd.Parameters.AddWithValue("@telephone", entity.Telephone);
                    cmd.Parameters.AddWithValue("@adresse", entity.Adresse);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Client updated successfully.");
                }
            }
        }
    }
}
