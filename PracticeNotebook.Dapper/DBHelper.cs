using System.Data.SqlClient;
using System.Configuration;

namespace PracticeNotebook.ORM
{
    public class DBHelper
    {
        public static SqlConnection ConnectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["Demo"].ConnectionString);
        public static SqlConnection NorthwindConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
    }
}