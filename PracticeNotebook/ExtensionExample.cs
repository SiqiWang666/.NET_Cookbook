namespace PracticeNotebook
{
    static class ExtensionExample
    {
        /*
         * Extension method is way to add a new functionality into an existing type.
         * requirements:
         *  1. class must be static
         *  2. extension method itself must be static
         *  3. first param to the extension method must be of the type which will be extended and with leading `this` keyword.
         */

        public static bool IsPrime(this int x, string a)
        {
            if (x < 4 && x > 0) return true;
            for (int i = 2; i < x / 2; i++)
            {
                if (x % i == 0) return false;
            }
            
            return true;
        }
    }
}