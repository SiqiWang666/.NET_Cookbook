using PracticeNotebook.EF.Data;
using PracticeNotebook.EF.Entity;

namespace PracticeNotebook.EF.Repository
{
    public class DepartmentRepository: EfRepository<Department>
    {
        public DepartmentRepository(DemoContext demoContext) : base(demoContext)
        {
        }
    }
}