using System;

namespace PracticeNotebook
{
    public class DelegateExample
    {
        /*
         * Delegate is a pointer to a method which can be passed as a parameter.
         */
        public void ActionDelegateExample()
        {
            // define a delegate function
            Action<int> factorialImplement = new Action<int>(CalculateFactorial);
            
            // Using anonymous methods
            Action<int> factorialAnonymous = delegate(int a)
            {
                int fact = 1;
                for (int i = a; i > 0; i--)
                {
                    fact *= fact;
                }
            
                Console.WriteLine(fact);
            };
            
            // Using lambda expression
            Action<int> factorialLambda = (a) =>
            {
                var fact = 1;
                for (int i = a; i > 0; i--)
                {
                    fact *= i;
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

        public void IncrementHelper(int[] arr, MathDelegate worker)
        {
            int increment = 99;
            foreach (var element in arr)
            {
                worker(element, increment);
            }
        }

        // Invoke the customized delegate
        public void Increment(int[] arr)
        {
            IncrementHelper(arr, (a, b) => Console.WriteLine(a + b));
        }
    }
    
    /*
     * There are three temple delegate that are commonly used.
     * Action: takes any type of input parameter but does not return any value
     * Predicate: takes any type of input but returns bool value
     * Func: takes any type of input params and can return any type of value
     *
     * FYI: It is less common to customize a delegate.
     */
    
    // Customize a new delegate type
    public delegate void MathDelegate(int a, int b);
}