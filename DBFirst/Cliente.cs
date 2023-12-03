using System;
using System.Collections.Generic;

namespace DBFirst
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
