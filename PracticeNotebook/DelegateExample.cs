using System;

namespace PracticeNotebook
{
    public class DelegateExample
    {
        public void ActionDelegateExample()
        {
            // Action<int> factorial = new Action<int>(CalculateFactorial);
            Action<int> factorial = delegate(int a)
            {
                int fact = 1;
                for (int i = a; i > 0; i--)
                {
                    fact *= fact;
                }

                Console.WriteLine(fact);
            };
        }

        public void CalculateFactorial(int a)
        {
            int fact = 1;
            for (int i = a; i > 0; i--)
            {
                fact *= fact;
            }

            Console.WriteLine(fact);
        }

        public void PredicateExample()
        {
            Predicate<int> isLeapYear = (year) =>
            {
                return DateTime.IsLeapYear(year);
            };
        }

        public void FuncExample()
        {
            Func<int, int> fibonacci = new Func<int, int>(GetFibonacci);
        }

        int GetFibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
    
    /*
     * There are three temple delegate that are commonly used.
     * Action: takes any type of input parameter but does not return any value
     * Predicate: takes any type of input but returns bool value
     * Func: takes any type of input params and can return any type of value
     */
    // It is less common to customize a delegate.
    //public delegate void MathDelegate(int a, int b);
}