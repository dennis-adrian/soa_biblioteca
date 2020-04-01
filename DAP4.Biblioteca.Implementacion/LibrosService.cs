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
    public class LibrosService : ILibrosService
    {
        public Libros ActualizarLibro(int id_libro, string libro_nombre, string libro_isbn, int anio_publicacion, string autor_nombre, string genero_nombre)
        {
            using (var instancia = new LibrosFachada())
            {
                return instancia.ActualizarLibro(id_libro, libro_nombre, libro_isbn, anio_publicacion, autor_nombre, genero_nombre);
            }
        }

        public Libros EliminarLibro(int id_libro)
        {
            using (var instancia = new LibrosFachada())
            {
                return instancia.EliminarLibro(id_libro);
            }
        }

        public void InsertarLibro(string libro_nombre, string libro_isbn, int anio_publicacion, string autor_nombre, string genero_nombre)
        {
            using (var instancia = new LibrosFachada())
            {
                instancia.InsertarLibro(libro_nombre, libro_isbn, anio_publicacion, autor_nombre, genero_nombre);
            }
        }

        IEnumerable<Libros> ILibrosService.ListarLibros()
        {
            using (var instancia = new LibrosFachada())
            {
                return instancia.ListarLibros();
            }
        }

        Libros ILibrosService.ObtenerLibroPorId(int id_libro)
        {
            using (var instancia = new LibrosFachada())
            {
                return instancia.ObtenerLibroPorId(id_libro);
            }
        }

        Libros ILibrosService.ObtenerLibroPorNombre(string libro_nombre)
        {
            using (var instancia = new LibrosFachada())
            {
                return instancia.ObtenerLibroPorNombre(libro_nombre);
            }
        }
    }
}
