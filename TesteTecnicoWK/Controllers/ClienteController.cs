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
    }
}
