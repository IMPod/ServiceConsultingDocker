using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DataBase.Data;
using DataBase.Data.Enum;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ServiceConsulting.Repository
{
    public class UserRepository  : IRepository<User>
    {
        private string connectionString;
        public UserRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(User item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(@$"INSERT INTO User (""RecState"", ""CreationDateTime"",""FirstName"", ""SecondName"", ""MiddleName"", ""BirthDay"", ""Sex"", ""Snils"") VALUES({RecordState.Active},{DateTime.Now},@FirstName,@SecondName,@MiddleName,@BirthDay,@Sex,@Snils)", item);
            }

        }

        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM User");
            }
        }

        public User FindByID(long id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM User WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(long id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM User WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(User item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE User SET RecState = @RecState,  FirstName  = @FirstName, SecondName= @SecondName, MiddleName= @MiddleName, BirthDay= @BirthDay, Sex= @Sex, Snils= @Snils  WHERE id = @Id", item);
            }
        }
    }
}
