using TesteTecnicoWK.Models;

namespace TesteTecnicoWK.Repository
{
    public interface IClienteInterface
    {
        List<ClienteModel> ListarClientes();
        ClienteModel BuscarClientePorId(int id);
        ClienteModel IncluirCliente(ClienteModel cliente);
        ClienteModel EditarCliente(ClienteModel cliente);
        ClienteModel MostrarCliente(ClienteModel cliente);
        bool ExcluirCliente(int id);
    }
}
