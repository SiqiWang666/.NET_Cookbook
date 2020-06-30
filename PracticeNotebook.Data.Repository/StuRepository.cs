using System;
using System.Collections.Generic;
using PracticeNotebook.Model;
using System.Data.SqlClient;

namespace PracticeNotebook.Data.Repository
{
    public class StuRepository : IRepository<Student>
    {
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
        
        /*
         * Stored Procedure
         * todo
         */
    }
}