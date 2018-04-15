using System;
using System.Collections.Generic;

namespace EducationSystem.DataAccess.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Course = new HashSet<Course>();
        }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Password { get; set; }

        public ICollection<Course> Course { get; set; }
    }
}
