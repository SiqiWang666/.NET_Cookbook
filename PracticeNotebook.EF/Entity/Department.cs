using System;
using System.Collections.Generic;

namespace PracticeNotebook.EF.Entity
{
    public partial class Department
    {
        public Department()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Dname { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
