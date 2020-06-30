using System.Collections.Generic;

namespace PracticeNotebook
{
    /*
     * Generic Type
     *  Syntax: append <T> to the class name or func name.
     */
    public class GenericExample<T>
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