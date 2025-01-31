using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoWK.Models
{
    public class PedidoItemModel
    {
        [Key]
        public int Id_Pedido { get; set; }
        public int Cod_Pedido { get; set; }
        public PedidoModel Pedido { get; set; }
        public int Cod_Produto { get; set; }
        public ProdutoModel Produto { get; set; }
        public int Val_Quantidade { get; set; }
        public decimal Val_PrecoUnitario { get; set; }
        public decimal Val_TotalItem { get; set; }
    }
}
