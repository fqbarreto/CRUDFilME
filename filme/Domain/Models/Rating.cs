using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int? FilmeId { get; set; }
        public int? SerieId { get; set; }
        public int UserId { get; set; }
        public double? Rate { get; set; }

        public virtual Filmes? Filme { get; set; }
        public virtual Series? Serie { get; set; }
        public virtual Usuario User { get; set; } = null!;
    }
}
