using System;
using System.Collections.Generic;

namespace EducationSystem.DataAccess.Models
{
    public partial class Student
    {
        public Student()
        {
            CourseRecord = new HashSet<CourseRecord>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Password { get; set; }

        public ICollection<CourseRecord> CourseRecord { get; set; }
    }
}
