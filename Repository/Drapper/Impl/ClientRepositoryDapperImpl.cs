using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Gestion_Dette.entites;
using MySql.Data.MySqlClient;

namespace Gestion_Dette.Repository.Drapper.Impl
{
    public class ClientRepositoryDapperImpl : IClientRepository
    {
        private readonly string _connectionString;

        public ClientRepositoryDapperImpl(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
        
        public void Insert(Client client)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("INSERT INTO Clients (Surnom, Telephone, Adresse) VALUES (@Surnom, @Telephone, @Adresse)", client);
            }
        }

        public Client SelectById(long id)
        {
            using (var connection = GetConnection())
            {
                return connection.QuerySingleOrDefault<Client>("SELECT * FROM Clients WHERE Id = @Id", new { Id = id });
            }
        }

        public List<Client> SelectAll()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Client>("SELECT * FROM Clients").ToList();
            }
        }

        public void Update(Client client)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("UPDATE Clients SET Surnom = @Surnom, Telephone = @Telephone, Adresse = @Adresse WHERE Id = @Id", client);
            }
        }

        public void Delete(long id)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("DELETE FROM Clients WHERE Id = @Id", new { Id = id });
            }
        }

        public Client FindBySurname(string surnom)
        {
            using (var connection = GetConnection())
            {
                
                return connection.QuerySingleOrDefault<Client>("SELECT * FROM Clients WHERE Surnom = @Surnom", new { Surname = surnom });
            }
        }
    }
}
