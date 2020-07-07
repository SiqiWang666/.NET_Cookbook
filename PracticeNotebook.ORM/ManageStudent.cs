using System;
using System.Data;

namespace PracticeNotebook.ORM
{
    public class ManageStudent
    {
        private StudentRepository _studentRepository;

        public ManageStudent()
        {
            _studentRepository = new StudentRepository();
        }

        public void GetStudentById(int id)
        {
            var s = _studentRepository.GetById(id);
            Console.WriteLine(s is null ? "not found" : s.SName);
        }

        public void UpdateStudent()
        {
            var rowEffected = _studentRepository.Update(new Student{Id = 4, SName = "William", Mobile = "890-123-1212"});
            Console.WriteLine(rowEffected > 0 ? "Successfully updated" : "Student not exists");
        }
    }
}