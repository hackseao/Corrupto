using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Data
{
    public class DonsProvincial
    {
        string _connectionString;

        public DonsProvincial(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<String> GetTop3Dons(string codepostal)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrEmpty(codepostal) || string.IsNullOrEmpty(codepostal))
                throw new InvalidOperationException("Specify values for Codepostal");

            string queryString = "Select TOP 3 * from Contribution where codepostal like @CodePostal order by montant_total desc";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.CommandTimeout = 5;
                command.Parameters.AddWithValue("@CodePostal", '%' + codepostal + '%');
            
                Console.WriteLine(command.CommandText);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string row = string.Format("{0}: {2} {1} don de {3} au partie {4} "+Environment.NewLine, reader[10], reader[4], reader[5], reader[6], reader[8]);
                        result.Add(row);
                        Console.WriteLine(row);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
    }
}
