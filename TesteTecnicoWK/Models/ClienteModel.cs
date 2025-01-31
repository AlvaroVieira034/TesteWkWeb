using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoWK.Models
{
    public class ClienteModel
    {
        [Key]
        public int Cod_Cliente { get; set; }
        public string Des_NomeCliente { get; set; }
        public string Des_Cep { get; set; }
        public string Des_Cidade { get; set; }
        public string Des_UF { get; set; }
    }
}
