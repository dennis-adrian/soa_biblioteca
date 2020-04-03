using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAP4.Biblioteca.Dominio;
using DAP4.Biblioteca.SqlRepositorio;
using DAP4.Biblioteca.ContratoRepositorio;

namespace DAP4.Biblioteca.Fachada
{
    public class EmpleadosFachada : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public Empleados ActualizarEmpleado(Empleados empleado)
        {
            IEmpleadosRepositorio instancia = new EmpleadosRepositorio();
            return instancia.ActualizarEmpleado(empleado);
        }

        public bool EliminarEmpleado(string id)
        {
            IEmpleadosRepositorio instancia = new EmpleadosRepositorio();
            return instancia.EliminarEmpleado(id);
        }

        public Empleados InsertarEmpleados(Empleados empleado)
        {
            IEmpleadosRepositorio instancia = new EmpleadosRepositorio();
            return instancia.InsertarEmpleados(empleado);
        }

        public IEnumerable<Empleados> ListarEmpleados()
        {
            IEmpleadosRepositorio instancia = new EmpleadosRepositorio();
            return instancia.ListarEmpleados();
        }

        public Empleados ObtenerEmpleadosPorApellido(string apellido)
        {
            IEmpleadosRepositorio instancia = new EmpleadosRepositorio();
            return instancia.ObtenerEmpleadosPorApellido(apellido);
        }

        public Empleados ObtenerEmpleadosPorId(string id)
        {
            IEmpleadosRepositorio instancia = new EmpleadosRepositorio();
            return instancia.ObtenerEmpleadosPorId(id);
        }
    }
}
