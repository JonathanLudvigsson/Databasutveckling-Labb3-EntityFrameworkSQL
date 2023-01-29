using System;
using System.Collections.Generic;

namespace Labb3DB.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            StudentGrades = new HashSet<StudentGrade>();
        }

        public int FacultyId { get; set; }
        public long Personnummer { get; set; }
        public string Fnamn { get; set; } = null!;
        public string Lnamn { get; set; } = null!;
        public string? Adress { get; set; }
        public string? Telefonnummer { get; set; }
        public string? Email { get; set; }
        public int? JobId { get; set; }

        public virtual Job? Job { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
    }
}
