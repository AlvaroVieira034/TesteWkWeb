using TesteTecnicoWK.Data;
using TesteTecnicoWK.Models;

namespace TesteTecnicoWK.Repository
{
    public class ProdutoRepository : IProdutoInterface
    {
        private readonly BancoContext _bancoContext;
        public ProdutoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ProdutoModel> ListarProdutos()
        {
            return _bancoContext.Tab_Produto.ToList();
        }

        public ProdutoModel BuscarProdutoPorId(int id)
        {
            return _bancoContext.Tab_Produto.FirstOrDefault(x => x.Cod_Produto == id);
        }

        public ProdutoModel IncluirProduto(ProdutoModel produto)
        {
            _bancoContext.Tab_Produto.Add(produto);
            _bancoContext.SaveChanges();
            return produto;
        }

        public ProdutoModel EditarProduto(ProdutoModel produto)
        {
            ProdutoModel produtoDB = BuscarProdutoPorId(produto.Cod_Produto);

            if (produtoDB == null) throw new System.Exception("Exceção lançada classe ProdutoRepository - Metodo: EditarProduto");

            produtoDB.Des_Descricao = produto.Des_Descricao;
            produtoDB.Val_Preco = produto.Val_Preco;
            
            _bancoContext.Tab_Produto.Update(produtoDB);
            _bancoContext.SaveChanges();

            return produtoDB;
        }

        public bool ExcluirProduto(int id)
        {
            ProdutoModel produtoDB = BuscarProdutoPorId(id);

            if (produtoDB == null) throw new System.Exception("Exceção lançada classe ProdutoRepository - Metodo: ExcluirProduto");

            _bancoContext.Tab_Produto.Remove(produtoDB);
            _bancoContext.SaveChanges(true);

            return true;
        }

        public ProdutoModel MostrarProduto(ProdutoModel produto)
        {
            throw new NotImplementedException();
        }
    }
}
