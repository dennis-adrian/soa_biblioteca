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
    public class PrestamosFachada : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public Prestamos ActualizarPrestamo(Prestamos prestamo)
        {
            IPrestamosRepositorio instancia = new PrestamosRepositorio();
            return instancia.ActualizarPrestamo(prestamo);
        }

        public bool DevolverPrestamo(string id_prestamo)
        {
            IPrestamosRepositorio instancia = new PrestamosRepositorio();
            return instancia.DevolverPrestamo(id_prestamo);
        }

        public Prestamos InsertarPrestamo(Prestamos prestamo)
        {
            IPrestamosRepositorio instancia = new PrestamosRepositorio();
            return instancia.InsertarPrestamo(prestamo);
        }

        public IEnumerable<Prestamos> ListarPrestamos()
        {
            IPrestamosRepositorio instancia = new PrestamosRepositorio();
            return instancia.ListarPrestamos();
        }

        public Prestamos ObtenerPrestamoPorCodigo(string codigo_prestamo)
        {
            IPrestamosRepositorio instancia = new PrestamosRepositorio();
            return instancia.ObtenerPrestamoPorCodigo(codigo_prestamo);
        }
    }
}
