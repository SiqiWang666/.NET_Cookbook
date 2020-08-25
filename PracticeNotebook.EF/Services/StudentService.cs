using System.Collections.Generic;
using System.Threading.Tasks;
using PracticeNotebook.EF.Data;
using PracticeNotebook.EF.Entity;
using PracticeNotebook.EF.Repository;

namespace PracticeNotebook.EF.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository = new StudentRepository(new DemoContext());

        public async Task<IEnumerable<Student>> ListStudents()
        {
            var students = await _studentRepository.ListAllAsync();
            return students;
        }

        public async Task<IEnumerable<Student>> ListStudentsWithDepartment()
        {
            var students = await _studentRepository.ListAllDepartmentAsync();
            return students;
        }
    }
}