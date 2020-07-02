using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PracticeNotebook.Data.Repository
{
    public class DBHelper
    {
        /*
         * This class aims to abstract the query.
         * For example, ExecuteDMLStatement(string cmd, Dictionary<string, obj> params)
         * todo [stored-procedure practice]
         */
        public int ExecuteDMLStatement(String cmd, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            // install ConfigurationManager from Nuget
            SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["Demo"].ConnectionString);
            int res = 0;
            SqlCommand command = new SqlCommand(cmd, connection);
            command.CommandType = cmdType;
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            try
            {
                connection.Open();
                res = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose(); // becuase database connection is not under the control of garbage collection.
            }
            return res;
        }

        public DataTable GetData(string cmd, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            // Need to put the result to the DataTable because the reader will be closed when the connection is closed.
            DataTable dt = new DataTable();
            SqlConnection connection =
                new SqlConnection(ConfigurationManager.ConnectionStrings["Demo"].ConnectionString);
            SqlCommand command = new SqlCommand(cmd, connection);
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose(); // Alternatively, `using` method will automatically call dispose method
            }

            return dt;
        }
    }
}