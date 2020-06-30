using System;

namespace PracticeNotebook
{
    public class FactoryDesignPattern
    {
        public BaseCustomer GenerateObject(int p)
        {
            switch (p)
            {
                case (int) Patterns.Customer:
                    return new Customer();
            }
            return null;
        }

        public void PrintHelpMenu()
        {
            Console.WriteLine("Please select you type of account.");
            String[] patterns = Enum.GetNames(typeof(Patterns));
            int[] indices = (int[]) Enum.GetValues(typeof(Patterns));
            for (int i = 0; i < indices.Length; i++)
            {
                Console.WriteLine("If you are a {0}, please enter {1}", patterns[i], indices[i]);
            }
        }
    }
}