using System;

namespace PracticeNotebook
{
    public class ParameterExample
    {
        public ParameterExample()
        {
        }

        /// <summary>
        /// Passing By value is the default mode of parameters. A copy of the actual parameter
        ///   is passed to the function;
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void PassingByValue(int a, int b)
        {
            a = 100;
            b = 200;
        }

        public static void PassingByRef(ref int a, ref int b)
        {
            a = 100;
            b = 200;
        }

        // optional parameter must be at the end
        // If you have multiple optional parameters, use `name:`
        public static void PrintValues(string str, int i, bool flag, float f = 4.3f)
        {
            Console.WriteLine("string is: " + str);
        }

        // out parameter
        [Obsolete(message: "fake message!", error: false)] //It is helpfule when you refactor some API.
        public static bool IsIntEven(int i, out string msg)
        {
            if (i % 2 == 0) msg = "the input number is even.";
            else msg = "the input number is odd!";
            return i % 2 == 0;
        }

        // variable sized parameters
        public static int AddNumbers(params int[] num)
        {
            int sum = 0;
            foreach (int i in num)
            {
                sum += i;
            }
            return sum;
        }

        // method overload, different # of params or different type of params
        public void Multiply(int a, int b)
        {
        }

        
        /*
         * todo [review-6/29/2020]
         * dynamic type
         * `var` keyword. `dynamic` keyword
         *  `var` will figure out the type during compile time;
         *  `dynamic` will figure out the type during runtime;
         * anonymous type
         *  var name = new {} //property is read-only
         */
    }
}