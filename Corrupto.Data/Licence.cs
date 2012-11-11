using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrupto.Data
{
    public class Licence
    {
        string _connectionString;

        public Licence(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<String> GetLicense(string nom, string nom2)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(nom2))
                throw new InvalidOperationException("Specify values for values Nom and/or Nom2!");

            // Provide the query string with a parameter placeholder.
            string queryString = "Select TOP 3 * from License where Nom like @Nom or Nom2 like @Nom2";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.CommandTimeout = 5;
                command.Parameters.AddWithValue("@Nom", '%'+nom+'%');
                command.Parameters.AddWithValue("@Nom2", '%'+nom2+'%');
                Console.WriteLine(command.CommandText);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string row = string.Format("{0} {1} pour la license {2} révoquée jusqu'au {3}", reader[0], reader[1],  reader[2], ((DateTime)reader[3]).ToShortDateString());
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
