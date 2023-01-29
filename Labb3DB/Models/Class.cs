using System;
using System.Collections.Generic;

namespace Labb3DB.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassStudents = new HashSet<ClassStudent>();
        }

        public int KlassId { get; set; }
        public string? KlassNamn { get; set; }
        public string? KlassInriktning { get; set; }

        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
    }
}
