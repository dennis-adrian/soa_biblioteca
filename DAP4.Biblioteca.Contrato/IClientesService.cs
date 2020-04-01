using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using DAP4.Biblioteca.Dominio;

namespace DAP4.Biblioteca.Contrato
{
    [ServiceContract]
    public interface IClientesService
    {
        [OperationContract]
        Clientes ObtenerClientePorId(int id_cliente);
        [OperationContract]
        Clientes ObtenerClientePorApellido(string cliente_apellido);
        [OperationContract]
        IEnumerable<Clientes> ListarClientes();
        [OperationContract]
        Clientes InsertarCliente(Clientes cliente);
        [OperationContract]
        Clientes ActualizarCliente(Clientes cliente);
        [OperationContract]
        bool EliminarCliente(int id_cliente);
    }
}
