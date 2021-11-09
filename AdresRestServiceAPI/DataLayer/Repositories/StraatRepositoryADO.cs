using BusinessLayer.Interfaces;
using BusinessLayer.Model;
using DataLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class StraatRepositoryADO : IStraatRepository
    {
        private string connectionString;

        public StraatRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public List<Straat> GeefStratenGemeente(int gemeenteId)
        {
            string query = "SELECT t1.*,t2.gemeentenaam FROM dbo.straat t1 "
                + " INNER JOIN dbo.gemeente t2 on t1.NIScode=t2.NIScode WHERE t1.NIScode=@NIScode";
            SqlConnection conn = getConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    List<Straat> straten = new List<Straat>();
                    conn.Open();
                    command.Parameters.AddWithValue("@NIScode", gemeenteId);
                    IDataReader dataReader = command.ExecuteReader();
                    Gemeente g = null;
                    while (dataReader.Read())
                    {
                        if (g == null) g = new Gemeente((int)dataReader["NIScode"], (string)dataReader["gemeentenaam"]);
                        Straat s = new Straat((int)dataReader["id"], (string)dataReader["straatnaam"], g);
                        straten.Add(s);
                    }
                    dataReader.Close();
                    return straten;
                }
                catch (Exception ex)
                {
                    throw new StraatRepositoryException("GeefStraten niet gelukt", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public Straat GeefStraat(int id)
        {
            string query = "SELECT t1.*,t2.gemeentenaam FROM dbo.straat t1 "
                + " INNER JOIN dbo.gemeente t2 on t1.NIScode=t2.NIScode WHERE t1.id=@id";
            SqlConnection conn = getConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@id", id);
                    IDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    Gemeente g = new Gemeente((int)dataReader["NIScode"], (string)dataReader["gemeentenaam"]);
                    Straat s = new Straat(id, (string)dataReader["straatnaam"], g);
                    dataReader.Close();
                    return s;
                }
                catch (Exception ex)
                {
                    throw new StraatRepositoryException("GeefStraat niet gelukt", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
