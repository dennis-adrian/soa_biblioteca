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
    public class EmpleadosService : IEmpleadosService
    {
        public Empleados ActualizarEmpleado(Empleados empleado)
        {
            using (var instancia = new EmpleadosFachada())
            {
                return instancia.ActualizarEmpleado(empleado);
            }
        }

        public bool EliminarEmpleado(string id)
        {
            using (var instancia = new EmpleadosFachada())
            {
                return instancia.EliminarEmpleado(id);
            }
        }

        public Empleados InsertarEmpleados(Empleados empleado)
        {
            using (var instancia = new EmpleadosFachada())
            {
                return instancia.InsertarEmpleados(empleado);
            }
        }

        public IEnumerable<Empleados> ListarEmpleados()
        {
            using (var instancia = new EmpleadosFachada())
            {
                return instancia.ListarEmpleados();
            }
        }

        public Empleados ObtenerEmpleadosPorApellido(string apellido)
        {
            using (var instancia = new EmpleadosFachada())
            {
                return instancia.ObtenerEmpleadosPorApellido(apellido);
            }
        }

        public Empleados ObtenerEmpleadosPorId(string id)
        {
            using (var instancia = new EmpleadosFachada())
            {
                return instancia.ObtenerEmpleadosPorId(id);
            }
        }
    }
}
