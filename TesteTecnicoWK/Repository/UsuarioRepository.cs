using TesteTecnicoWK.Data;
using TesteTecnicoWK.Models;

namespace TesteTecnicoWK.Repository
{
    public class UsuarioRepository : IUsuarioInterface
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;   
        }
        public List<UsuarioModel> ListarUsuarios()
        {
            return _bancoContext.Tab_Usuario.ToList();
        }

        public UsuarioModel BuscarUsuarioPorId(int id)
        {
            return _bancoContext.Tab_Usuario.FirstOrDefault(x => x.Cod_Usuario == id);
        }

        public UsuarioModel IncluirUsuario(UsuarioModel usuario)
        {
            _bancoContext.Tab_Usuario.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel EditarUsuario(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarUsuarioPorId(usuario.Cod_Usuario);

            if (usuarioDB == null) throw new Exception("Exceção lançada classe UsuarioRepository - Metodo: EditarUsuario");

            usuarioDB.Des_NomeUsuario = usuario.Des_NomeUsuario;
            usuarioDB.Des_Email = usuario.Des_Email;
            usuarioDB.Des_Login = usuario.Des_Login;
            usuarioDB.Cod_Perfil = usuario.Cod_Perfil;
            usuarioDB.Des_Senha = usuario.Des_Senha;
            usuarioDB.Dta_Cadastro = usuario.Dta_Cadastro;
            usuarioDB.Dta_Atualizacao = usuario.Dta_Atualizacao;

            _bancoContext.Tab_Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;

        }

        public bool ExcluirUsuario(int id)
        {
            UsuarioModel usuarioDB = BuscarUsuarioPorId(id);

            if (usuarioDB == null) throw new System.Exception("Exceção lançada classe UsuarioRepository - Metodo: ExcluirUsuario");

            _bancoContext.Tab_Usuario.Remove(usuarioDB);
            _bancoContext.SaveChanges(true);

            return true;

        }

        public UsuarioModel MostrarUsuario(UsuarioModel Usuario)
        {
            throw new NotImplementedException();
        }
    }
}
