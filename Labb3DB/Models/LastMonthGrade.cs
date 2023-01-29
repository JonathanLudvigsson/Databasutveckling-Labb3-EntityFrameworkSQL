using System;
using System.Collections.Generic;

namespace Labb3DB.Models
{
    public partial class LastMonthGrade
    {
        public string Fnamn { get; set; } = null!;
        public string Lnamn { get; set; } = null!;
        public string KursNamn { get; set; } = null!;
        public string? Betyg { get; set; }
        public DateTime? SattPåDatum { get; set; }
    }
}
