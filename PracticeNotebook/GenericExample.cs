using System.Collections.Generic;

namespace PracticeNotebook
{
    /*
     * Generic Type
     *  Syntax: append <T> to the class name or func name.
     * you can assign constraints on T: where T : class | where T : struct
     */
    public class GenericExample<T> where T : class
    {
        public List<T> list = new List<T>();

        public void Insert(T item)
        {
            list.Add(item);
        }
        public bool Sum<T>(T a, T b)
        {
            return a.Equals(b);
        }
    }
}