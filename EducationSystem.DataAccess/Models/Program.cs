using System;
using System.Collections.Generic;

namespace EducationSystem.DataAccess.Models
{
    public partial class Program
    {
        public Program()
        {
            Subject = new HashSet<Subject>();
        }

        public int ProgramId { get; set; }
        public string ProgramName { get; set; }

        public ICollection<Subject> Subject { get; set; }
    }
}
