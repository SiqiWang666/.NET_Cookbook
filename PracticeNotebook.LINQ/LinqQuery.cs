using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeNotebook.LINQ
{
    // Create a new class to query
    public class Professor
    {
        public string name { get; set; }
        public decimal salary { get; set; }
        public int age { get; set; }
        public string city { get; set; }
    }

    public class University
    {
        public string name { get; set; }
        public string city { get; set; }
    }
    /*
     * LINQ = language integrated query. It provides consistent way for querying different data source.
     *   For example, LINQ to Objects, LINQ to database, LINQ to dataset, and XML.
     * in-memory data source: Return IEnumerable. For example arrays, list, dictionary, XML file
     * out-memory data source: Return IQueryable. For example, sql server
     *
     * liNQ -> SQL
     * 1. data source 2. query creation 3.query execution
     * 
     * pros: 1. compiler checking. 2. simplicity of using a single language.
     * cons: less control over the interaction with database
     *
     * LINQ typically works with in-memory data source.
     * todo [review-important]
     * 
     * A query variable only stores the query commands.
     * Delayed execution: the sql will be executed when the variable is used.
     * IEnumerable/IQueryable variable -> deferred execution But if the statement have aggregate functions, immediate execution.
     * What's the benefit?
     *  It will greatly improve the performance when you have to manipulate large data collections. The collection results will have smaller memory foot prints.
    */
    public class LinqQuery
    {
        private List<Professor> _professors;
        private List<University> _universities;

        public LinqQuery()
        {
            _professors = new List<Professor>
            {
                new Professor {name = "Tim", salary = 90000m, age = 25, city = "DC"},
                new Professor {name = "William", salary = 90000m, age = 45, city = "DC"},
                new Professor {name = "Tom", salary = 50000m, age = 25, city = "LA"},
                new Professor {name = "Jason", salary = 100000m, age = 45, city = "LA"},
                new Professor {name = "Zhang", salary = 70000m, age = 30, city = "DC"},
                new Professor {name = "Wood", salary = 80000m, age = 45, city = "DC"},
                new Professor {name = "Ethan", salary = 60000m, age = 35, city = "Seattle"},
                new Professor {name = "Pod", salary = 110000m, age = 50, city = "DC"},
            };

            _universities = new List<University>
            {
                new University {name = "NYU", city = "New York"},
                new University {name = "GWU", city = "DC"},
                new University {name = "UCLA", city = "LA"},
                new University {name = "UWA", city = "Seattle"},
                new University {name = "AMU", city = "DC"},
                new University {name = "SEA", city = "Seattle"}
            };
        }

        #region Select-Where-Distinct-Group-Order
        
        /// <summary>
        /// Select * from
        /// </summary>
        public void GetAllSync()
        {
            // select all in method syntax
            var collection = _professors.Select(x => x);
            
            foreach (var item in collection)
            {
                Console.WriteLine($"Name: {item.name}. Salary: {item.salary}. Age: {item.age}. City: {item.city}");
            }
            
            // Select name and city in method syntax
            // todo [review-anonymous type]
            // if the name is not specified, it will be align with the members used to init them. This is called projection initializer. 
            var collectionByCondition = _professors.Select((p) => new {p.name, p.city});
            foreach (var item in collectionByCondition)
            {
                Console.WriteLine($"Professor {item.name} lives at {item.city}");
            }
        }
        
        public void FilterByAgeRange(int low, int high)
        {
            // select-where clause in query syntax
            var collectionQuery = from p in _professors where p.age >= low && p.age <= high select new {p.name, p.city};
            var collectionMethod = _professors.Where((p) => p.age >= low && p.age <= high)
                .Select((p) => new {p.name, p.city});
            
            foreach (var professor in collectionQuery)
            {
                Console.Write(professor.name + " | " + professor.city);
            }
        }

        /// <summary>
        /// Find first student with the given name.
        /// </summary>
        /// <param name="name"></param>
        public void SelectByName(string name)
        {
            // todo [tips]
            // use FirstOrDefault() instead of First(). First() will throw InvalidOperationException, FirstOrDefault() will return null. 
            var connection = _professors.Where(x => x.name.Equals(name)).Select(x => new {x.city, x.age}).FirstOrDefault();
            if(connection is null) Console.WriteLine("Professor not found");
            else
            {
                Console.WriteLine($"City is {connection.city} and age is {connection.age}");
            }
        }

        public void OrderSequenceByAge()
        {
            var ascendingOrder = from p in _professors orderby p.age ascending select new {p.name, p.age};
            var descendingOrder = _professors.OrderByDescending((p) => p.age);

            foreach (var item in ascendingOrder)
            {
                Console.WriteLine(item.name + "|" + item.age);
            }

            foreach (var item in descendingOrder)
            {
                Console.WriteLine(item.name + "|" + item.age);
            }
        }
        
        public void GroupByCity()
        {
            var query = from p in _professors
                group p by p.city
                // a collection of objects with the same key
                into pGroup
                select new {pGroup.Key, count = pGroup.Count()};
            var collectionMethod = _professors.GroupBy(p => p.city).Select(pGroup => new {pGroup.Key, Count = pGroup.Count()});
            
            foreach (var group in collectionMethod)
            {
                Console.WriteLine($"City: {group.Key}. Number: {group.Count}");
            }
        }

        public void GetDistinctCity()
        {
            var collection = _professors.Select((p) => p.city).Distinct();
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
        }
        #endregion

        #region Join Operator
        public void JoinOperator()
        {
            // Simple inner join will produce a flat result that consists of each element in p that has a matching with u.
            var innerJoinQuerySyntax = from p in _professors
                join u in _universities on p.city equals u.city
                select new {ProfessorName = p.name, p.city, UniversityName = u.name};
            
            var innerJoinMethodSyntax = _professors.Join(_universities, (p) => p.city, (u) => u.city,
                (p, u) => new {ProfessorName = p.name, p.city, UniversityName = u.name});
            
            foreach (var item in innerJoinMethodSyntax)
            {
                Console.WriteLine($"Professor: {item.ProfessorName} | University: {item.UniversityName}");
            }
            
            // Inner join will produce a hierarchical sequence.
            var innerJoinNonFlat = from p in _professors
                join u in _universities on p.city
                    equals u.city into g
                select new {Key = p.name, Item = g};
            
            foreach (var item in innerJoinNonFlat)
            {
                Console.Write($"Professor Name: {item.Key}");
                Console.WriteLine("List of universities in the same city: ");
                foreach (var u in item.Item)
                {
                    Console.Write("{0} \t", u.name);
                }
                Console.WriteLine();
            }
            
            // Inner join to get the matched count of one-to-many relationship
            var innerJoinNonFlatCount = from p in _professors
                join u in _universities
                    on p.city equals u.city into g
                let count = g.Count()
                select new {p.name, count};
            foreach (var item in innerJoinNonFlatCount)
            {
                Console.WriteLine(item.name + ", " + item.count);
            }

            
            var crossJoin = from u in _universities
                join p in _professors on u.city equals p.city into ps
                from pd in ps
                select new {u.name, u.city,  Professor = pd.name};
            
            foreach (var item in crossJoin)
            {
                Console.WriteLine($"{item.city}, {item.name}, {item.Professor}");
            }

            // Left join
            var leftJoin = from u in _universities
                join p in _professors on
                    u.city equals p.city into ps
                from pd in ps.DefaultIfEmpty()
                // Error if don't perform `null` value check
                select new {UniversityName = u.name, u.city, ProfessorName = pd is null ? "null" : pd.name};
            foreach (var item in leftJoin)
            {
                Console.WriteLine(item.UniversityName + "|" + item.city + "|" + item.ProfessorName);
            }
            // left join of multiple join clause
            var leftJoinMultipleCondition = from u in _universities
                join p in _professors on new {u.city, u.name} equals new {p.city, p.name}
                    into match
                from m in match.DefaultIfEmpty()
                select new {UniversityName = u.name, ProfessorName = m.name};

        }
        #endregion

        #region Partition

        public void GetTopThreeSalary()
        {
            var collectionMethod = _professors.Select((p) => p.salary).OrderByDescending((s) => s).Take(3);
            foreach (var s in collectionMethod)
            {
                Console.WriteLine(s + " ");
            }
        }

        public void GetLastThreeSalary()
        {
            var count = _professors.Count();
            var collectionMethod = _professors.Select((p) => p.salary).OrderByDescending((s) => s).Skip(count - 3);
            
            foreach (var s in collectionMethod)
            {
                Console.WriteLine(s + " ");
            }
        }
        #endregion

        #region Aggregate 
        // todo [implementation]
        // max, min, average, sum, aggregate
        public void GetProfessorCount()
        {
            var count = _professors.Count();
            Console.WriteLine($"The count is {count}");
        }

        #endregion

        #region Async-query
        // The return type of async method is Task.
        public async Task<IEnumerable<Professor>> GetAllAsync()
        {
            var collection = _professors.Select(x => x);
            return collection;
        }

        async void DisplayAll()
        {
            var collection = await GetAllAsync();
            // todo question? two threads that execute two async function each VS two async functions execute in a single thread.
        }

        #endregion
    }
}