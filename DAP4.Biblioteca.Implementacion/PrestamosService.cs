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
    public class PrestamosService : IPrestamosService
    {
        public Prestamos ActualizarPrestamo(Prestamos prestamo)
        {
            using (var instancia = new PrestamosFachada())
            {
                return instancia.ActualizarPrestamo(prestamo);
            }
        }

        public bool DevolverPrestamo(string id_prestamo)
        {
            using (var instancia = new PrestamosFachada())
            {
                return instancia.DevolverPrestamo(id_prestamo);
            }
        }

        public Prestamos InsertarPrestamo(Prestamos prestamo)
        {
            using (var instancia = new PrestamosFachada())
            {
                return instancia.InsertarPrestamo(prestamo);
            }
        }

        public IEnumerable<Prestamos> ListarPrestamos()
        {
            using (var instancia = new PrestamosFachada())
            {
                return instancia.ListarPrestamos();
            }
        }

        public Prestamos ObtenerPrestamoPorCodigo(string codigo_prestamo)
        {
            using (var instancia = new PrestamosFachada())
            {
                return instancia.ObtenerPrestamoPorCodigo(codigo_prestamo);
            }
        }
    }
}
