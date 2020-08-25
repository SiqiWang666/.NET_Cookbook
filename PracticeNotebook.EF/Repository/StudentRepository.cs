using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticeNotebook.EF.Data;
using PracticeNotebook.EF.Entity;

namespace PracticeNotebook.EF.Repository
{
    public class StudentRepository : EfRepository<Student>
    {
        public StudentRepository(DemoContext demoContext) : base(demoContext)
        {
        }

        public async Task<IEnumerable<Student>> ListAllDepartmentAsync()
        {
            // LEFT JOIN query
            var students = await _demoContext.Set<Student>().Include(s => s.Department)
                .ToListAsync();
            return students;
        }
    }
}