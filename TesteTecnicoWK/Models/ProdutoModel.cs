using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoWK.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Cod_Produto { get; set; }
        public string Des_Descricao { get; set; }
        public decimal Val_Preco { get; set; }
    }
}
