using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using PracticeNotebook.Model;

namespace PracticeNotebook.ORM
{
    public class ProductRespository
    {
        /*
         * Query multi-mapping: one-to-many, one side
         */
        public Supplier GetSupplier()
        {
            string query = "SELECT s.SupplierID, s.CompanyName, p.ProductID, p.ProductName FROM Products p INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID";
            try
            {
                using (IDbConnection conn = DBHelper.NorthwindConnection)
                {
                    // Throw ArgumentException without "spliton"
                    return conn.Query<Supplier, Product, Supplier>(query, (s, p) =>
                    {
                        p.Supplier = s;
                        return s;
                    }, splitOn: "ProductID").FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public IEnumerable<Product> GetAllSync()
        {
            string query = @"SELECT p.ProductName, p.UnitPrice FROM Products p";
            using (IDbConnection conn = DBHelper.NorthwindConnection)
            {
                return conn.Query<Product>(query);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            string query = @"SELECT p.ProductName, p.UnitPrice FROM Products p";
            using (IDbConnection conn = DBHelper.NorthwindConnection)
            {
                return await conn.QueryAsync<Product>(query);
            }
        }
    }
}