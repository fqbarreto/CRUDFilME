using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Rateview
    {
        public int? RatingId { get; set; }
        public double? Rate { get; set; }
        public int? FilmeId { get; set; }
        public string? Nome { get; set; }
    }
}
