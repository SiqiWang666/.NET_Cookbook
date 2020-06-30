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
         * Repository: 
         */
        public int Insert(Student obj)
        {
            // view - server explorer - add connection - add the database
            SqlConnection connection = new SqlConnection();
            // cmd.ExecuteNonQuery()
            return 0;
        }

        public int Update(Student obj)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}