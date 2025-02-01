using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoWK.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Cod_Produto { get; set; }
        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        public string Des_Descricao { get; set; }
        [Required(ErrorMessage = "O valor do produto é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor do produto deve ser maior que zero.")]
        public decimal Val_Preco { get; set; }
    }
}
