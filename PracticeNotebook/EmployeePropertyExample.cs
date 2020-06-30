using System;
namespace PracticeNotebook
{
    public class EmployeePropertyExample
    {
        private int id;

        // no parenthesis
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                // value keyword
                id = value;
            }
        }

        public string EName { get; set; }

        public decimal Salary { get; set; }

        // Constructor
        // Constructor cannot be inherited
        public EmployeePropertyExample()
        {
        }

        public EmployeePropertyExample(int i, string n, decimal s): this()
        {
            Id = i;
            Salary = s;
            EName = n;
        }
    }
}
