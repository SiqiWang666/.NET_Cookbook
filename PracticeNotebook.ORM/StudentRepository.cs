using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using Dapper;

namespace PracticeNotebook.ORM
{
    public class StudentRepository
    {
        /*
         * Dapper is an open-source maintained by stackoverflow.
         *  Dapper is a popular micro ORM.
         *
         * 1. Create IDbConnection object. (Perform CRUD operation directly using IDbConnection object)
         * 2. Write a query to perform CRUD operations.
         * 3. Pass query as a parameter in Execute method.
         *
         * Dapper extend the IDbConnection by providing useful extension methods to query our database.
         */

        #region Simple CRUD operation using Dapper

        public IEnumerable<Student> GetAll()
        {
            string query = @"SELECT Id, SName, Mobile FROM Student";
            using (IDbConnection conn = DBHelper.ConnectionString)
            {
                // todo [review-Dapper]
                // Don't necessarily open the connection. It's implemented inside Query function.
                return conn.Query<Student>(query); // No strongly typed will return dynamic
            }
        }

        public Student GetById(int id)
        {
            string cmd = @"SELECT SName, Mobile FROM Student WHERE Id = @id";
            using (IDbConnection conn = DBHelper.ConnectionString)
            {
                return conn.QueryFirstOrDefault<Student>(cmd, new {id = id});
            }
        }
        
        public int Update(Student s)
        {
            string cmd = @"UPDATE Student SET SName=@SName, Mobile=@Mobile WHERE Id = @Id";
            using (IDbConnection conn = DBHelper.ConnectionString)
            {
                return conn.Execute(cmd, s);
            }
        }

        public int Insert(Student s)
        {
            string cmd = @"INSERT INTO Student VALUES (@Id, @SName, @Mobile)";
            using (IDbConnection conn = DBHelper.ConnectionString)
            {
                return conn.Execute(cmd, s);
            }
        }

        public int InsertMany(Student[] students)
        {
            string cmd = @"INSERT INTO Student VALUES (@Id, @SName, @Mobile)";
            using (IDbConnection conn = DBHelper.ConnectionString)
            {
                // Execute the command multiple times by passing an array of params (object).
                return conn.Execute(cmd, students);
            }
        }

        public int Delete(int id)
        {
            string cmd = @"DELETE FROM Student WHERE Id = @id";
            using (IDbConnection conn = DBHelper.ConnectionString)
            {
                return conn.Execute(cmd, new {id});
            }
        }
        #endregion

        #region complex mapping using Dapper

        // todo [implementation needed]
        /*
         * Query multi-mapping
         * many-to-many relationship
         * one-to-many, Employee-Department
         *   List<Employee> in department model
         *   Department filed in empoyee model
         */

        #endregion
        
    }
}