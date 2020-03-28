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
    public class LibrosFachada: IDisposable
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

        public Libros ObtenerLibroPorId(int id_libro)
        {
            ILibrosRepositorio instancia = new LibrosRepositorio();
            return instancia.ObtenerLibroPorId(id_libro);
        }

        public Libros ObtenerLibroPorNombre(string libro_nombre)
        {
            ILibrosRepositorio instancia = new LibrosRepositorio();
            return instancia.ObtenerLibroPorNombre(libro_nombre);
        }
        public void InsertarLibro(string libro_nombre, string libro_isbn, int anio_publicacion, int id_autor, int id_genero)
        {
            ILibrosRepositorio instancia = new LibrosRepositorio();
            instancia.InsertarLibro(libro_nombre, libro_isbn, anio_publicacion, id_autor, id_genero);
        }
    }
}
