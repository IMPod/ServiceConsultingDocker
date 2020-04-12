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
    public class ConsultationRepository : IRepository<Consultation>
    {
        private string connectionString;
        public ConsultationRepository(IConfiguration configuration)
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

        public void Add(Consultation item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(@$"INSERT INTO Consultation (""RecState"", ""CreationDateTime"", ""PatientSymptoms"",""UserId"") VALUES({RecordState.Active},{DateTime.Now},@PatientSymptoms,@UserId)", item);
            }

        }

        public IEnumerable<Consultation> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Consultation>("SELECT * FROM Consultation");
            }
        }

        public Consultation FindByID(long id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Consultation>("SELECT * FROM Consultation WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(long id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Consultation WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(Consultation item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Consultation SET RecState = @RecState, PatientSymptoms= @PatientSymptoms WHERE id = @Id", item);
            }
        }
    }
}
