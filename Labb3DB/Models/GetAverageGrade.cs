using System;
using System.Collections.Generic;

namespace Labb3DB.Models
{
    public partial class GetAverageGrade
    {
        public string KursNamn { get; set; } = null!;
        public string? KursBeskrivning { get; set; }
        public int? AverageGrade { get; set; }
        public int? LägstaBetyg { get; set; }
        public int? HögstaBetyg { get; set; }
    }
}
