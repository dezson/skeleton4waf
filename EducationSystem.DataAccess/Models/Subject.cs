using System;
using System.Collections.Generic;

namespace EducationSystem.DataAccess.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Course = new HashSet<Course>();
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int ProgramId { get; set; }

        public Program Program { get; set; }
        public ICollection<Course> Course { get; set; }
    }
}
