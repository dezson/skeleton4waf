using System;
using System.Collections.Generic;
using System.Text;

namespace EducationSystem.DataAccess.Models
{
    public partial class CourseRecord
    {
        public bool IsCompleted
        {
            get { return this.Grade != null && this.Grade > 1; }
        }
    }
}
