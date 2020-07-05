using System.Collections.Generic;

namespace PracticeNotebook
{
    static class ExtensionExample
    {
        /*
         * Extension method is way to add a new functionality into an existing type.
         * requirements:
         *  1. class must be static, non-nested, non-generic
         *  2. extension method itself must be static
         *  3. first param to the extension method must be of the type which will be extended and with leading `this` keyword.
         */

        public static bool IsPrime(this int x)
        {
            if (x < 4 && x > 0) return true;
            for (int i = 2; i < x / 2; i++)
            {
                if (x % i == 0) return false;
            }
            
            return true;
        }

        // Extension methods can be added to any types
        public static List<T> CombineLists<T>(List<T> a, List<T> b)
        {
            a.AddRange(b);
            return a;
        } 
    }
}