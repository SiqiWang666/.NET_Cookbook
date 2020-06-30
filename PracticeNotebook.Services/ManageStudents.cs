using System;
using System.Collections;
using System.Collections.Generic;
using PracticeNotebook.Data.Repository;
using PracticeNotebook.Model;

namespace PracticeNotebook.Services
{
    public class ManageStudents
    {
        StuRepository _stuRepository = new StuRepository();

        public void AddStudent(String name, String mobile)
        {
            Student student = new Student{SName = name,Mobile = mobile};
            int rowEffected = _stuRepository.Insert(student);
            Console.WriteLine(rowEffected > 0 ? "Success" : "Failed");
        }

        public void GetAllStudents()
        {
            IEnumerable<Student> collection =  _stuRepository.GetAll();

            if (collection != null)
            {
                foreach (Student student in collection)
                {
                    Console.WriteLine($"Id: {student.Id}, name: {student.SName}, mobile: {student.Mobile}");
                }
            }
        }

        public void GetStudentById(int i)
        {
            Student student = _stuRepository.GetById(i);
            Console.WriteLine($"Id: {student.Id} | Name: {student.SName} | Mobile: {student.Mobile}");
        }

        public void DeleteStudentById(int i)
        {
            int res = _stuRepository.Delete(i);
            Console.WriteLine(res > 0 ? "Success" : "Fail");
        }

        public void UpdateStudent(Student student)
        {
            int res = _stuRepository.Update(student);
            Console.WriteLine(res > 0 ? "Success" : "Student not exist");
        }
    }
}