using System;

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
    }
}