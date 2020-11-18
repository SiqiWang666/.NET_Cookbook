using System;

namespace PracticeNotebook
{
    
    public abstract class AbstractExample
    {
        /*
         * abstract class always act as super class.
         *  - it cannot be instantiated.
         *  - abstract class can have both abstract and non-abstract methods.
         *  - abstract method is only declared (without curly brackets) in abstract class and implemented in the derived class. A derived class needs to override all abstract method in the super class.
         *  - abstract method is by default virtual so it must be overriden in derived class.
         */
        public abstract object GetMax<T>(params T[] num);

        public void Greeting()
        {
            Console.WriteLine("Good morning!");
        }
    }

    public class ConcreteClass : AbstractExample
    {
        public override object GetMax<T>(params T[] num)
        {
            if (num.Length <= 0) return null;
            
            T maxSoFar = num[0];
            // fake code
            return maxSoFar;
        }
    }
}