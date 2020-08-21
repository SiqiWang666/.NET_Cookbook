using System;
using System.Threading.Tasks;

namespace PracticeNotebook.ORM
{
    public class ManageProduct
    {
        private ProductRespository _productRespository;

        public ManageProduct()
        {
            _productRespository = new ProductRespository();
        }
        
        public void GetSupplier()
        {
            var s = _productRespository.GetSupplier();
            Console.WriteLine("ID: " + s.SupplierID);
            Console.WriteLine("Company name:" + s.CompanyName);
            Console.WriteLine("Contact name" + s.ContactTitle);
        }

        public void GetAllSync()
        {
            var collection = _productRespository.GetAllSync();
            foreach (var p in collection)
            {
                Console.WriteLine(p.ProductName);
            }
        }

        public async Task GetAllAsync()
        {
            try
            {
                // ToDo [bug - solved]
                var collection = await _productRespository.GetAllAsync();
                if (collection != null)
                {
                    foreach (var c in collection)
                    {
                        Console.WriteLine($"Product Name: {c.ProductName}. Unit Price: {c.UnitPrice}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }
    }
}