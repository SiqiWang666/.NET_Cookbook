using System;
using System.Collections.Generic;

namespace PracticeNotebook
{
    public class ArrayExample
    {
        string[] students;
        public ArrayExample()
        {
            string[] stus = new string[] { "Tim", "Smith", "Tom" };
            this.students = stus;

        }
        public void DisplayStudentsInOrder()
        {
            Array.Sort(this.students);
            foreach (string student in this.students)
            {
                Console.WriteLine("student");
            }
        }

        public void AddSession()
        {
            Dictionary<string, DateTime> session = new Dictionary<string, DateTime>();
            
        }
    }
}
