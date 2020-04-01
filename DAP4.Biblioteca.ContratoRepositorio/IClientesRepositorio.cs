using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAP4.Biblioteca.Dominio;

namespace DAP4.Biblioteca.ContratoRepositorio
{
    public interface IClientesRepositorio
    {
        Clientes ObtenerClientePorId(int id_cliente);
        Clientes ObtenerClientePorApellido(string cliente_apellido);
        IEnumerable<Clientes> ListarClientes();
        Clientes InsertarCliente(Clientes cliente);
        Clientes ActualizarCliente(Clientes cliente);
        bool EliminarCliente(int id_cliente);
    }
}
