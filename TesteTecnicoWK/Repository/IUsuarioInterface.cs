using TesteTecnicoWK.Models;

namespace TesteTecnicoWK.Repository
{
    public interface IUsuarioInterface
    {
        List<UsuarioModel> ListarUsuarios();
        UsuarioModel BuscarUsuarioPorId(int id);
        UsuarioModel IncluirUsuario(UsuarioModel Usuario);
        UsuarioModel EditarUsuario(UsuarioModel Usuario);
        UsuarioModel MostrarUsuario(UsuarioModel Usuario);
        bool ExcluirUsuario(int id);
    }
}
