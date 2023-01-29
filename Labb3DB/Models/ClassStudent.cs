using System;
using System.Collections.Generic;

namespace Labb3DB.Models
{
    public partial class ClassStudent
    {
        public int Id { get; set; }
        public int KlassId { get; set; }
        public int StudentId { get; set; }

        public virtual Class Klass { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
