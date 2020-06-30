using System;

namespace PracticeNotebook
{
    public class BaseCustomer
    {
        // protected can be accessed within the class and derived class
        public String Mobile { get; set; }
        public String Name { get; set; }

        public BaseCustomer()
        {
            Console.WriteLine("Constructor of BaseCustomer....");
        }

        public virtual void PrintWelcome()
        {
            Console.WriteLine("Hello from base customer!");
        }

        public virtual void AddCustomer()
        {
            Console.WriteLine("Please enter your name:");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter your mobile");
            Mobile = Console.ReadLine();
        }

        public void DisplayInfo()
        {
            Console.WriteLine("****Info about the Prime Account****");
            Console.WriteLine("Name is: {0}", Name);
            Console.WriteLine("Mobile is: {0}", Mobile);
        }

        public void Greeting()
        {
            Console.WriteLine("Good morning!");
        }
        
    }

    public class PrimeCustomer : BaseCustomer
    {
        public DateTime ValidTo { get; set; }
        
        public PrimeCustomer()
        {
            Console.WriteLine("Constructor of Prime Customer...");
        }

        public override void AddCustomer()
        {
            Console.WriteLine("Executing AddCustomer from PrimeCustomer class....");
            base.AddCustomer();
            ValidTo = DateTime.Now.AddDays(365);
        }

        public override void PrintWelcome()
        {
            Console.WriteLine("Hello from prime customer");
        }

        public new void DisplayInfo()
        {
            Console.WriteLine("****Info about the Prime Account");
            Console.WriteLine("Name is: {0}", base.Name);
            Console.WriteLine("Mobile is: {0}", base.Mobile);
            Console.WriteLine("Valid to: {0}", ValidTo.Date);
        }
    }

    // inherit class: reuse the code
    public class Customer : BaseCustomer
    {
        public decimal BillAmount { get; set; }

        public Customer()
        {
            Console.WriteLine("Constructor of Customer...");
            
        }

        // method hiding
        public new void AddCustomer()
        {
            base.AddCustomer();
            Console.WriteLine("Please enter your bill amount");
            BillAmount = Convert.ToDecimal(Console.ReadLine());
        }

        // method override
        public override void PrintWelcome()
        {
            Console.WriteLine("Hello from Customer!");
        }

        public new void DisplayInfo()
        {
            Console.WriteLine("This is the method defined in customer class!");
        }
        /*
         * todo [review]
         * 1. method hiding: derived class method will hide the base class method. Same method name + params, the return type may or may not be the same.
         * 2. method overriding (keyword: virtual-override): When a virtual method is called on an object, then the most derived version of the method is called
         */

        /*
         * Generics
         * > boxing:conversion of a value type to reference is called boxing.
         * > unboxing: conversion of a reference to a value type is called unboxing.
         * > type safety
         */
    }
}