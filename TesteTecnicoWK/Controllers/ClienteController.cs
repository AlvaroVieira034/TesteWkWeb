using Microsoft.AspNetCore.Mvc;
using TesteTecnicoWK.Models;
using TesteTecnicoWK.Repository;

namespace TesteTecnicoWK.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteInterface _clienteRepository;
        public ClienteController(IClienteInterface clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            List<ClienteModel> clientes = _clienteRepository.ListarClientes();
            return View(clientes);
        }

        public IActionResult IncluirCliente()
        {
            return View();
        }

        public IActionResult EditarCliente(int id)
        {
            ClienteModel cliente = _clienteRepository.BuscarClientePorId(id);
            return View(cliente);
        }

        public IActionResult ExcluirCliente(int id)
        {
            ClienteModel cliente = _clienteRepository.BuscarClientePorId(id);
            return View(cliente);
        }

        public IActionResult MostrarCliente(int id)
        {
            ClienteModel cliente = _clienteRepository.BuscarClientePorId(id);
            return View(cliente);
        }


        [HttpPost]
        public IActionResult IncluirCliente(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepository.IncluirCliente(cliente);
                    TempData["MensagemSucesso"] = "Cliente incluído com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao incluir um novo cliente! - Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarCliente(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepository.EditarCliente(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao editar o cliente! - Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult ApagarCliente(int id)
        {
            try
            {
                _clienteRepository.ExcluirCliente(id);
                TempData["MensagemSucesso"] = "Cliente excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao excluir o cliente! - Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
