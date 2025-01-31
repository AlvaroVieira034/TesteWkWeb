using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoWK.Models
{
    public class PedidoModel
    {
        [Key]
        public int Cod_Pedido { get; set; }
        public DateTime Dta_pedido { get; set; }
        public int Cod_Cliente { get; set; }
        public ClienteModel Cliente { get; set; }
        public decimal Val_Pedido { get; set; }
        public ICollection<PedidoItemModel> Itens { get; set; } = new List<PedidoItemModel>();
    }
}
