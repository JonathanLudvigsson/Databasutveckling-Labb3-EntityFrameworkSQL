using System;
using System.Collections.Generic;

namespace Labb3DB.Models
{
    public partial class Job
    {
        public Job()
        {
            Faculties = new HashSet<Faculty>();
        }

        public int JobId { get; set; }
        public string? JobNamn { get; set; }
        public string? JobBeskrivning { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
