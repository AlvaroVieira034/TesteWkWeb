using Microsoft.AspNetCore.Mvc;
using TesteTecnicoWK.Models;
using TesteTecnicoWK.Repository;

namespace TesteTecnicoWK.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoInterface _produtoRepository;
        public ProdutoController(IProdutoInterface produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public IActionResult Index()
        {
            List<ProdutoModel> produtos = _produtoRepository.ListarProdutos();
            return View(produtos);
        }

        public IActionResult IncluirProduto()
        {
            return View();
        }

        public IActionResult EditarProduto(int id)
        {
            ProdutoModel produto = _produtoRepository.BuscarProdutoPorId(id);
            return View(produto);
        }

        public IActionResult ExcluirProduto(int id)
        {
            ProdutoModel produto = _produtoRepository.BuscarProdutoPorId(id);
            return View(produto);
        }

        public IActionResult MostrarProduto(int id)
        {
            ProdutoModel produto = _produtoRepository.BuscarProdutoPorId(id);
            return View(produto);
        }


        [HttpPost]
        public IActionResult IncluirProduto(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepository.IncluirProduto(produto);
                    TempData["MensagemSucesso"] = "Produto incluído com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao incluir um novo produto! - Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarProduto(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepository.EditarProduto(produto);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao editar o produto! - Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult ApagarProduto(int id)
        {
            try
            {
                _produtoRepository.ExcluirProduto(id);
                TempData["MensagemSucesso"] = "Produto excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao excluir o produto! - Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
