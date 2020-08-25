using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticeNotebook.EF.Data;

namespace PracticeNotebook.EF.Repository
{
    public class EfRepository<T> where T: class
    {
        protected readonly DemoContext _demoContext;

        public EfRepository(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            // SELECT ALL query
            return await _demoContext.Set<T>().ToListAsync();
        }
    }
}