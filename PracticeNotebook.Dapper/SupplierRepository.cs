using System.Collections.Generic;
using System.Data;
using Dapper;
using PracticeNotebook.Model;

namespace PracticeNotebook.ORM
{
    public class SupplierRepository
    {
        /*
         * Query multi-mapping
         * one-to-one relationship
         * one-to-many, Employee-Department
         *   List<Employee> in department model
         *   Department filed in employee model
         */
        
        public IEnumerable<Supplier> GetSupplyProducts()
        {
            string query = "SELECT s.SupplierID, s.CompanyName, p.ProductID, p.ProductName FROM Suppliers s INNER JOIN Products p ON s.SupplierID = p.SupplierID";
            using (IDbConnection conn = DBHelper.NorthwindConnection)
            {
                // type parameter: each object you want to map, last one is the object it will return.
                return conn.Query<Supplier, Product, Supplier>(query, (s, p) =>
                {
                    s.Products ??= new List<Product>();
                    s.Products.Add(p);
                    p.Supplier = s;
                    return s;
                }, splitOn:"ProductID");
            }
        }
        
    }
}