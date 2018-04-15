using System;
using System.Collections.Generic;

namespace EducationSystem.DataAccess.Models
{
    public partial class CourseRecord
    {
        public int CourseRecordId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime? ApplyTime { get; set; }
        public int? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
