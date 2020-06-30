using System;
using System.Collections.Generic;
using PracticeNotebook.Model;
using PracticeNotebook.Repository;

namespace PracticeNotebook
{
    public class ManageEmployee
    {
        EmpRepository _empRepository = new EmpRepository();

        public void FilterEmployee()
        {
            Predicate<Employee> con = new Predicate<Employee>(MeetCondition);
            // you can either to choose implement a delegate externally (same input and output type) or uee lambda.
            List<Employee> result = _empRepository.GetCollectionByCondition((e) => e.Salary > 80000);
            _empRepository.PrintResult(result);
        }

        public bool MeetCondition(Employee e)
        {
            return e.Salary > 8000;
        }

        public void DisplaySalary()
        {
            double bonus = 0.8;
            Dictionary<int, decimal> salary =
                _empRepository.CalculateSalaryByBonus((e) => (decimal) ((double) e.Salary * (1 + bonus)));
            
            foreach (var keyValuePair in salary)
            {
                Console.WriteLine(keyValuePair);
            }
        }
    }
}