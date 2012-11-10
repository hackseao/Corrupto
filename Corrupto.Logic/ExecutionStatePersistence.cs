using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Corrupto.Logic
{
    // This is not the right place for this but... hey, it's a *HACK*athon
    public class ExecutionStatePersistence
    {
        private const string connectionStringName = "CorruptoDB";
       
        public static ExecutionState Get()
        {
            var state = new ExecutionState();

            using(SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT LastMentionStatusId, LastDirectMessageStatusId FROM LastExecutionState WHERE Id = 1", cn);
                
                cn.Open();
                
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                reader.Read();
                state.LastMentionStatusId = Convert.ToDecimal(reader["LastMentionStatusId"]);
                state.LastDirectMessageStatusId = Convert.ToDecimal(reader["LastDirectMessageStatusId"]);

                reader.Close();
                cn.Close();
            }

            return state;
        }

        public static void Set(ExecutionState state)
        {
            using(SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE LastExecutionState SET LastMentionStatusId = @LastMentionStatusId, LastDirectMessageStatusId = @LastDirectMessageStatusId WHERE Id = 1", cn);
                cmd.Parameters.AddWithValue("@LastMentionStatusId", state.LastMentionStatusId.ToString());
                cmd.Parameters.AddWithValue("@LastDirectMessageStatusId", state.LastDirectMessageStatusId.ToString());

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
