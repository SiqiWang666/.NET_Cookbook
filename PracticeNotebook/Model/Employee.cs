namespace PracticeNotebook.Model
{
    public class Employee
    {
        /*
         * Property
         *  - getter and setter, read and write
         *  - setter, write only
         *  - getter, read only
         */
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public decimal Salary { get; set; }
    }
}