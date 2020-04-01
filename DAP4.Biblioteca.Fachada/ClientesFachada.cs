using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAP4.Biblioteca.Dominio;
using DAP4.Biblioteca.ContratoRepositorio;
using DAP4.Biblioteca.SqlRepositorio;

namespace DAP4.Biblioteca.Fachada
{
    public class ClientesFachada : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public Clientes ActualizarCliente(Clientes cliente)
        {
            IClientesRepositorio instancia = new ClientesRepositorio();
            return instancia.ActualizarCliente(cliente);
        }

        public bool EliminarCliente(int id_cliente)
        {
            IClientesRepositorio instancia = new ClientesRepositorio();
            return instancia.EliminarCliente(id_cliente);
        }

        public Clientes InsertarCliente(Clientes cliente)
        {
            IClientesRepositorio instancia = new ClientesRepositorio();
            return instancia.InsertarCliente(cliente);
        }

        public IEnumerable<Clientes> ListarClientes()
        {
            IClientesRepositorio instancia = new ClientesRepositorio();
            return instancia.ListarClientes();
        }

        public Clientes ObtenerClientePorApellido(string cliente_apellido)
        {
            IClientesRepositorio instancia = new ClientesRepositorio();
            return instancia.ObtenerClientePorApellido(cliente_apellido);
        }

        public Clientes ObtenerClientePorId(int id_cliente)
        {
            IClientesRepositorio instancia = new ClientesRepositorio();
            return instancia.ObtenerClientePorId(id_cliente);
        }
    }
}
