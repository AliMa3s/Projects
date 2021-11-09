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
    public class AdresRepositoryADO : IAdresRepository
    {
        private string connectionString;

        public AdresRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        public IEnumerable<Adres> GeefAdressenStraat(int straatid)
        {
            string query = "SELECT t1.*,t2.straatnaam,t2.NIScode,t3.gemeentenaam FROM dbo.adres t1 "
                + " INNER JOIN dbo.straat t2 on t1.straatid=t2.id "
                + " INNER JOIN dbo.gemeente t3 on t3.NIScode=t2.NIScode WHERE t1.straatid=@straatid";
            SqlConnection conn = getConnection();
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                try
                {
                    List<Adres> adressen = new List<Adres>();
                    Gemeente g = null;
                    Straat s = null;
                    conn.Open();
                    command.Parameters.AddWithValue("@straatid", straatid);
                    IDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (g == null) g = new Gemeente((int)dataReader["NIScode"], (string)dataReader["gemeentenaam"]);
                        if (s == null) s = new Straat(straatid, (string)dataReader["straatnaam"], g);
                        Adreslocatie l = new Adreslocatie((double)dataReader["xcoord"], (double)dataReader["ycoord"]);
                        string appnr;
                        string busnr;
                        if (dataReader.IsDBNull(dataReader.GetOrdinal("appartementnummer")))
                            appnr = null; else appnr = (string)dataReader["appartementnummer"];
                        if (dataReader.IsDBNull(dataReader.GetOrdinal("busnummer")))
                            busnr = null;
                        else busnr = (string)dataReader["busnummer"];
                        Adres a = new Adres((int)dataReader["id"], s, (string)dataReader["huisnummer"], appnr
                            , busnr, (int)dataReader["postcode"], l);
                        adressen.Add(a);
                    }
                    dataReader.Close();
                    return adressen;
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
