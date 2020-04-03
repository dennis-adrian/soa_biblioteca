using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAP4.Biblioteca.Dominio;

namespace DAP4.Biblioteca.ContratoRepositorio
{
    public interface IEmpleadosRepositorio
    {
        IEnumerable<Empleados> ListarEmpleados();
        Empleados ObtenerEmpleadosPorId(string id);
        Empleados ObtenerEmpleadosPorApellido(string apellido);
        Empleados InsertarEmpleados(Empleados empleado);
        Empleados ActualizarEmpleado(Empleados empleado);
        bool EliminarEmpleado(string id);
    }
}
