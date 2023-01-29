using System;
using System.Collections.Generic;

namespace Labb3DB.Models
{
    public partial class StudentGrade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int KursId { get; set; }
        public string? Betyg { get; set; }
        public int? FacultyId { get; set; }
        public DateTime? SattPåDatum { get; set; }

        public virtual Faculty? Faculty { get; set; }
        public virtual Course Kurs { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
