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
    public class LibrosFachada : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public IEnumerable<Libros> ListarLibros()
        {
            ILibrosRepositorio instancia = new LibrosRepositorio();
            return instancia.ListarLibros();
        }

        public Libros ObtenerLibroPorId(string id_libro)
        {
            ILibrosRepositorio instancia = new LibrosRepositorio();
            return instancia.ObtenerLibroPorId(id_libro);
        }

        public Libros ObtenerLibroPorNombre(string libro_nombre)
        {
            ILibrosRepositorio instancia = new LibrosRepositorio();
            return instancia.ObtenerLibroPorNombre(libro_nombre);
        }
        public Libros InsertarLibro(Libros libro)
        {
            ILibrosRepositorio instancia = new LibrosRepositorio();
            return instancia.InsertarLibro(libro);
        }
        public Libros ActualizarLibro(Libros libro)
        {
            ILibrosRepositorio instancia = new LibrosRepositorio();
            return instancia.ActualizarLibro(libro);
        }
        public bool EliminarLibro(string id_libro)
        {
            ILibrosRepositorio instancia = new LibrosRepositorio();
            return instancia.EliminarLibro(id_libro);
        }
    }
}
