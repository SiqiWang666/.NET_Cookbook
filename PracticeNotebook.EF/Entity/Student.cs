using System;
using System.Collections.Generic;

namespace PracticeNotebook.EF.Entity
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Sname { get; set; }
        public string Mobile { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
