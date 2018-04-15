using System;
using System.Collections.Generic;

namespace EducationSystem.DataAccess.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseRecord = new HashSet<CourseRecord>();
        }

        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int StartDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public int Seats { get; set; }

        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<CourseRecord> CourseRecord { get; set; }
    }
}
