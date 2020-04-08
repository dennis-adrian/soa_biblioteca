using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAP4.Biblioteca.Contrato;
using DAP4.Biblioteca.Dominio;
using DAP4.Biblioteca.Fachada;

namespace DAP4.Biblioteca.Implementacion
{
    public class ClientesService : IClientesService
    {
        public Clientes ActualizarCliente(Clientes cliente)
        {
            using (var instancia = new ClientesFachada())
            {
                return instancia.ActualizarCliente(cliente);
            }
        }

        public bool EliminarCliente(string id_cliente)
        {
            using (var instancia = new ClientesFachada())
            {
                return instancia.EliminarCliente(id_cliente);
            }
        }

        public Clientes InsertarCliente(Clientes cliente)
        {
            using (var instancia = new ClientesFachada())
            {
                return instancia.InsertarCliente(cliente);
            }
        }

        public IEnumerable<Clientes> ListarClientes()
        {
            using (var instancia = new ClientesFachada())
            {
                return instancia.ListarClientes();
            }
        }

        public Clientes ObtenerClientePorApellido(string cliente_apellido)
        {
            using (var instancia = new ClientesFachada())
            {
                return instancia.ObtenerClientePorApellido(cliente_apellido);
            }
        }

        public Clientes ObtenerClientePorId(string id_cliente)
        {
            using (var instancia = new ClientesFachada())
            {
                return instancia.ObtenerClientePorId(id_cliente);
            }
        }
    }
}
