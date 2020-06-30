using System;
using System.Collections.Generic;
using System.Data;
using PracticeNotebook.Model;
using System.Data.SqlClient;

namespace PracticeNotebook.Data.Repository
{
    public class StuRepository : IRepository<Student>
    {
        private DBHelper _dbHelper;

        public StuRepository()
        {
            _dbHelper = new DBHelper();
        }
        /*
         * todo [review-6/29/2020]
         * connect to sql server: server name + authentication + database name = connection string
         * open the connection
         * sql command
         * connect the command with the server
         * execute the query
         * close the connection
         */
        /*
         * Model: DTO (data transfer object)
         * Repository: interaction with database
         * Service: logic
         */
        public int Insert(Student obj)
        {
            string cmd = "INSERT INTO Student VALUES (@name, @mobile)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", obj.SName);
            parameters.Add("@mobile", obj.Mobile);
            return _dbHelper.ExecuteDMLStatement(cmd, parameters);
        }

        public int Update(Student obj)
        {
            string cmd = "UPDATE Student SET SName=@name, Mobile=@mobile WHERE Id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", obj.Id);
            parameters.Add("@name", obj.SName);
            parameters.Add("@mobile", obj.Mobile);
            return _dbHelper.ExecuteDMLStatement(cmd, parameters);
        }

        public int Delete(int id)
        {
            string cmd = "DELETE Student WHERE Id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return _dbHelper.ExecuteDMLStatement(cmd, parameters);
        }

        // todo futher optimization
        public Student GetById(int id)
        {
            string cmd = "SELECT Id,SName,Mobile FROM Student WHERE Id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable table = _dbHelper.GetData(cmd, parameters);
            Student student = new Student();
            foreach (DataRow row in table.Rows)
            {
                student.Id = Convert.ToInt32(row["Id"]);
                student.SName = Convert.ToString(row["SName"]);
                student.Mobile = Convert.ToString(row["Mobile"]);
            }

            return student;
        }

        /*
         * The reason why we use IEnumerable because it is faster and secure because the data cannot be changed. 
         */
        public IEnumerable<Student> GetAll()
        {
            List<Student> collection = new List<Student>();
            String cmd = "SELECT Id, SName, Mobile FROM Student";
            DataTable table = _dbHelper.GetData(cmd, null);
            foreach (DataRow row in table.Rows)
            {
                collection.Add(new Student
                {
                    Id = Convert.ToInt32(row["Id"]),
                    SName = Convert.ToString(row["Sname"]),
                    Mobile = Convert.ToString(row["Mobile"])
                });
            }

            return collection;
        }
        /*
         deprecated!!
        public int Insert(Student obj)
        {
            // view - server explorer - add connection - add the database
            SqlConnection connection =
                new SqlConnection("Server=127.0.0.1,1433;Database=Demo;User=sa;Password=MSSQLserver$666;");
            int res = 0;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Student VALUES(@name, @mobile)");
                // todo BUG without parameter write
                cmd.Parameters.AddWithValue("@name", obj.SName);
                cmd.Parameters.AddWithValue("@mobile", obj.Mobile);
                cmd.Connection = connection;
                // ExecuteNonQuery() only supports for update, delete and insert operations because these DML statement return number of row effected
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return res;
        }

        public int Update(Student obj)
        {
            SqlConnection connection = new SqlConnection("Server=127.0.0.1,1433;Database=Demo;User=sa;Password=MSSQLserver$666;");
            SqlCommand command = new SqlCommand("UPDATE Student SET SName=@name, Mobile=@mobile WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@name", obj.SName);
            command.Parameters.AddWithValue("@mobile", obj.Mobile);
            command.Parameters.AddWithValue("@id", obj.Id);
            int res = 0;
            try
            {
                connection.Open();
                res = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally{connection.Close();}

            return res;
        }

        public int Delete(int id)
        {
            SqlConnection connection = new SqlConnection("Server=127.0.0.1,1433;Database=Demo;User=sa;Password=MSSQLserver$666;");
            SqlCommand command = new SqlCommand("DELETE FROM Student WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            int res = 0;
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
            }
            return res;
        }

        public Student GetById(int id)
        {
            SqlConnection connection = new SqlConnection("Server=127.0.0.1,1433;Database=Demo;User=sa;Password=MSSQLserver$666;");
            SqlCommand command = new SqlCommand("SELECT Id, Sname, Mobile FROM Student WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            Student student = new Student();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.SName = Convert.ToString(reader["SName"]);
                    student.Mobile = Convert.ToString(reader["Mobile"]);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            List<Student> collection = new List<Student>();
            SqlConnection connection =
                new SqlConnection("Server=127.0.0.1,1433;Database=Demo;User=sa;Password=MSSQLserver$666;");
            
            SqlCommand cmd = new SqlCommand("SELECT Id, SName, Mobile FROM Student");
            try
            {
                connection.Open();
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader(); //connection oriented method
                while (reader.Read())
                {
                    Student s = new Student();
                    s.Id = Convert.ToInt32(reader["Id"]);
                    s.SName = Convert.ToString(reader["SName"]);
                    s.Mobile = Convert.ToString(reader["Mobile"]);
                    collection.Add(s);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            
            return collection;
        }
        */
    }
}