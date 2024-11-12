using Gestion_Dette.Core;
using Gestion_Dette.entites;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Gestion_Dette.Repository.BD.Impl
{
    public class DetteRepositoryBdImpl : IDetteRepository
    {
        private readonly IDataAcess dataAcess;

        public DetteRepositoryBdImpl(IDataAcess dataAcess)
        {
            this.dataAcess = dataAcess;
        }

        public void Delete(long id)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "DELETE FROM dette WHERE dette.id = @id;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Dette deleted successfully.");
                }
            }
        }

        public Dette SelectById(long id)
        {
            Dette dette = null;
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM dette WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dette = new Dette()
                            {
                                Id = reader.GetInt64("id"),
                                Date = reader.GetDateTime("date"),
                                Montant = reader.GetFloat("montant"),
                                Client = new Client()
                                {
                                    Id = reader.GetInt64("client_id"), 
                                    Surnom = reader.GetString("surnom"),
                                    Telephone = reader.GetString("telephone"),
                                    Adresse = reader.GetString("adresse")
                                }
                            };
                        }
                    }
                }
            }
            return dette;
        }

        public List<Dette> SelectAll()
        {
            List<Dette> dettes = new List<Dette>();
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM dette";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dettes.Add(new Dette()
                            {
                                Id = reader.GetInt64("id"),
                                Date = reader.GetDateTime("date"),
                                Montant = reader.GetFloat("montant"),
                               
                            });
                        }
                    }
                }
            }
            return dettes;
        }

        public void Insert(Dette entity)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "INSERT INTO dette (date, montant, client_id) VALUES (@date, @montant, @clientId)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", entity.Date);
                    cmd.Parameters.AddWithValue("@montant", entity.Montant);
                    cmd.Parameters.AddWithValue("@clientId", entity.Client.Id);
                    cmd.ExecuteNonQuery();
                    entity.Id = (long)cmd.LastInsertedId; 
                    Console.WriteLine("Dette added successfully.");
                }
            }
        }

        public void Update(Dette entity)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "UPDATE dette SET date = @date, montant = @montant, client_id = @clientId WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    cmd.Parameters.AddWithValue("@date", entity.Date);
                    cmd.Parameters.AddWithValue("@montant", entity.Montant);
                    cmd.Parameters.AddWithValue("@clientId", entity.Client.Id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Dette updated successfully.");
                }
            }
        }
    }
}
