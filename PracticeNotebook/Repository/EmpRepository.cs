using System;
using System.Collections.Generic;
using PracticeNotebook.Model;

namespace PracticeNotebook.Repository
{
    public class EmpRepository
    {
        private List<Employee> listEmp = new List<Employee>()
        {
            // TODO [Review]
            // init with a list of anonymous objects, new ClassName{<file> = <value>, ..}
            new Employee{Id = 1, Name="Tom", Department = "Computer Science", City = "Arlington", Salary = 80000},
            new Employee{Id = 2, Name="Smith", Department = "Computer Science", City = "DC", Salary = 90000},
            new Employee{Id = 3, Name="Tim", Department = "Math", City = "Seattle", Salary = 100000},
            new Employee{Id = 4, Name = "Json", Department = "Physics", City = "New York", Salary = 40000},
            new Employee{Id = 5, Name="William", Department = "Science", City = "Arlington", Salary = 80000}
        };

        public List<Employee> GetCollectionByCondition(Predicate<Employee> condition)
        {
            List<Employee> collection = new List<Employee>();
            foreach (var employee in listEmp)
            {
                if(condition(employee)) collection.Add(employee);
            }
            return collection;
        }
        
        public void PrintResult(List<Employee> collection)
        {
            collection.ForEach((emp) => Console.WriteLine($"Name is {emp.Name}. City is {emp.City}. Department is {emp.Department}. Salary is {emp.Salary}"));
        }
        
        // requirements: Write a method to calculate the salary based on the bonus. For example, the bonus of this year is 30%, the an employee will be paid with salary * (1 + 30 %);
        // Define the calculate the bonus as a delegate

        public Dictionary<int, decimal> CalculateSalaryByBonus(Func<Employee, decimal> bonus)
        {
            Dictionary<int, decimal> result = new Dictionary<int, decimal>();
            foreach (var emp in listEmp)
            {
                result.Add(emp.Id, bonus(emp));
            }
            return result;
        }

        /*
         * todo [review-class note 06/26/2020]
         * .Net structure
         * How to organize the structure efficiently so that it can scale out as the product grows?
         * [Company].[Product]
         *  - for example. [Company].[Product].Utility, [Company].[Product].Service
         * purpose?
         *  - make project more scalable, have the flexibility of the namespace.
         */
    }
}