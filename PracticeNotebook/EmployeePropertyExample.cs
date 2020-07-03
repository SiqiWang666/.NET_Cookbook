using System;
namespace PracticeNotebook
{
    public class EmployeePropertyExample
    {
        private int _Id;

        // manually created property. Have to create explicit backing fields, in this case `_Id`
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                // value keyword
                _Id = value;
            }
        }

        // auto-implemented property. Compiler will create the backing field.
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
