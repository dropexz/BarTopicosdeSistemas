using System.ComponentModel.DataAnnotations.Schema;

namespace BarAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int BebidaId { get; set; }
        public Bebida? Bebida { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;
    }
}
