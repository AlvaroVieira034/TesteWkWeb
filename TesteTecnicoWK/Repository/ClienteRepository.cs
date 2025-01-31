using TesteTecnicoWK.Data;
using TesteTecnicoWK.Models;

namespace TesteTecnicoWK.Repository
{
    public class ClienteRepository : IClienteInterface
    {
        private readonly BancoContext _bancoContext;
        public ClienteRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ClienteModel> ListarClientes()
        {
            return _bancoContext.Tab_Cliente.ToList();
        }

        public ClienteModel BuscarClientePorId(int id)
        {
            return _bancoContext.Tab_Cliente.FirstOrDefault(x => x.Cod_Cliente == id);
        }

        public ClienteModel IncluirCliente(ClienteModel cliente)
        {
            _bancoContext.Tab_Cliente.Add(cliente);
            _bancoContext.SaveChanges();
            return cliente;
        }

        public ClienteModel EditarCliente(ClienteModel cliente)
        {
            ClienteModel clienteDB = BuscarClientePorId(cliente.Cod_Cliente);

            if (clienteDB == null) throw new System.Exception("Houve um erro na atualização do cliente!");

            clienteDB.Des_NomeCliente = cliente.Des_NomeCliente;
            clienteDB.Des_Cep = cliente.Des_Cep;
            clienteDB.Des_Cidade = cliente.Des_Cidade;
            clienteDB.Des_UF = cliente.Des_UF;

            _bancoContext.Tab_Cliente.Update(clienteDB);
            _bancoContext.SaveChanges();

            return clienteDB;
        }

        public bool ExcluirCliente(int id)
        {
            ClienteModel clienteDB = BuscarClientePorId(id);

            if (clienteDB == null) throw new System.Exception("Houve um erro ao excluir o cliente");

            _bancoContext.Tab_Cliente.Remove(clienteDB);
            _bancoContext.SaveChanges(true);

            return true;
        }

        public ClienteModel MostrarCliente(ClienteModel cliente)
        {
            throw new NotImplementedException();
        }
    }
}
