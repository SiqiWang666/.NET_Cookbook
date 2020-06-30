namespace PracticeNotebook.Repository
{
    
    public interface IRepository<T> where T:class
    {
        /*
         * [class-note] 6/25/2020
         * Interface
         *  - naming convention with a leading I.
         *  - it supports multiple inheritance.
         *  - methods are by default public and abstract
         *  - cannot be instantiated and doesn't support constructor
         *  - If you implements multiple interface with same signature, you need to implement explicitly
         *
         * Collections
         *  - Add, Insert, RemoveAt
         */
        void Add(T obj);
        void Create(T obj);

    }
}