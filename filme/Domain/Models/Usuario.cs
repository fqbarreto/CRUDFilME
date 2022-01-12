using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Lista = new HashSet<Listum>();
            Ratings = new HashSet<Rating>();
        }

        public int UserId { get; set; }
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public DateOnly DataCriacao { get; set; }
        public bool Assinante { get; set; }
        public DateOnly? Assinatura { get; set; }

        public virtual ICollection<Listum> Lista { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
