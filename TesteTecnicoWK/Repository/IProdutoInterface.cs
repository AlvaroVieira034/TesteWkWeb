using TesteTecnicoWK.Models;

namespace TesteTecnicoWK.Repository
{
    public interface IProdutoInterface
    {
        List<ProdutoModel> ListarProdutos();
        ProdutoModel BuscarProdutoPorId(int id);
        ProdutoModel IncluirProduto(ProdutoModel Produto);
        ProdutoModel EditarProduto(ProdutoModel Produto);
        ProdutoModel MostrarProduto(ProdutoModel produto);
        bool ExcluirProduto(int id);
    }
}
