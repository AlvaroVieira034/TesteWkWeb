using Microsoft.AspNetCore.Mvc;
using TesteTecnicoWK.Models;
using TesteTecnicoWK.Repository;

namespace TesteTecnicoWK.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioRepository;
        public UsuarioController(IUsuarioInterface usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepository.ListarUsuarios();
            return View(usuarios);
        }

        public IActionResult IncluirUsuario()
        {
            return View();
        }

        public IActionResult EditarUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepository.BuscarUsuarioPorId(id);
            return View(usuario);
        }

        public IActionResult ExcluirUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepository.BuscarUsuarioPorId(id);
            return View(usuario);
        }

        public IActionResult MostrarUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepository.BuscarUsuarioPorId(id);
            return View(usuario);
        }


        [HttpPost]
        public IActionResult IncluirUsuario(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.IncluirUsuario(usuario);
                    TempData["MensagemSucesso"] = "Usuario incluído com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao incluir um novo usuario! - Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarUsuario(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.EditarUsuario(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao editar o usuario! - Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult ApagarUsuario(int id)
        {
            try
            {
                _usuarioRepository.ExcluirUsuario(id);
                TempData["MensagemSucesso"] = "Usuario excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao excluir o usuário! - Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
