using System;

namespace PracticeNotebook
{
    enum Operators
    {
        // you can customize the number
        Add = 1,
        Subtract,
        Multiply
    }

    public class EnumExample
    {
        // Hide teh implementation but expose only few code
        // access-modifier
        public EnumExample()
        {
        }

        void PrintMenu()
        {
            string[] names = Enum.GetNames(typeof(Operators));
            int[] values = (int[]) Enum.GetValues(typeof(Operators));
            // do some calculation
            // do't exit unless type exit
            // Console.clear();
        }

        // default method modifier is private
        void AddNumbers()
        {
            //Convert.ToInt32(s);
        }

        void SubtractNumbers()
        {
        }

        void MultiplyNumbers()
        {
        }

        // If you hard-coded your code, there are chances to make mistakes.
    }
}