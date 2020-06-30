using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PracticeNotebook.Model;

namespace PracticeNotebook
{
    class Program
    {


        static void Main(string[] args)
        {
            /*
            #region parameter type
            int x = 10, y = 20;
            ParameterExample.PassingByValue(x, y);
            Console.WriteLine("Inside passing by value a = {0} and b = {1}", x, y);
            ParameterExample.PassingByRef(ref x, ref y);
            Console.WriteLine("Inside passing by value a = {0} and b = {1}", x, y);
            #endregion

            #region unordered params and default params
            ParameterExample.PrintValues(flag: true, str: "antra", f: 4.3f, i: 18);
            #endregion

            #region out parameters
            string msg;
            // Method has been marded as obselete
            ParameterExample.IsIntEven(10, out msg);
            Console.WriteLine(msg);
            #endregion

            Console.WriteLine(ParameterExample.AddNumbers(2, 3, 5, 10));

            Employee employee = new Employee{EName = "Tom", Id = 1, Salary = 50000m};

            //todo Throws format exception. a) the objects have different types.[not this reason]
            // Composite Format String
            Console.WriteLine("Id= {0}, Name= {1}, Salary= {2}", employee.Id, employee.EName, employee.Salary);

            Console.WriteLine($"Id: {employee.Id} Name: {employee.EName} Salary: {employee.Salary}");

            */
            // boot up of the factory pattern
            
            /*
            FactoryDesignPattern f = new FactoryDesignPattern();
            f.PrintHelpMenu();
            
            BaseCustomer c = new Customer();
            c.AddCustomer(); // Execute the method in BaseCustomer, because the method is not overriden in class Customer
            c.PrintWelcome(); // Execute the method in Customer
            c.DisplayInfo();
            */
            
            // boot up of the delegate practice
            
            /*
            ManageEmployee manageEmployee = new ManageEmployee();
            manageEmployee.FilterEmployee();
            manageEmployee.DisplaySalary();
            */
            
            /*
             * Static
             *  - class: only have static method. cannot be inherited. (or sealed). cannot be passed as a param.
             *  - variable: static variable is global
             *  - method:
             *    constructor: without params and you cannot call it explicitly. (init class variables)
             */
            
        }
    }
}
