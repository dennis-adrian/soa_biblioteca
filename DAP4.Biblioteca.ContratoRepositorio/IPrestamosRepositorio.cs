using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAP4.Biblioteca.Dominio;

namespace DAP4.Biblioteca.ContratoRepositorio
{
    public interface IPrestamosRepositorio
    {
        Prestamos ObtenerPrestamoPorCodigo(string codigo_prestamo);
        IEnumerable<Prestamos> ListarPrestamos();
        Prestamos InsertarPrestamo(Prestamos prestamo);
        Prestamos ActualizarPrestamo(Prestamos prestamo);
        bool DevolverPrestamo(string id_prestamo);
    }
}
