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
        public Libros ActualizarLibro(Libros libro)
        {
            using (var instancia = new LibrosFachada())
            {
                return instancia.ActualizarLibro(libro);
            }
        }

        public bool EliminarLibro(string id_libro)
        {
            using (var instancia = new LibrosFachada())
            {
                return instancia.EliminarLibro(id_libro);
            }
        }

        public Libros InsertarLibro(Libros libro)
        {
            using (var instancia = new LibrosFachada())
            {
                return instancia.InsertarLibro(libro);
            }
        }

        IEnumerable<Libros> ILibrosService.ListarLibros()
        {
            using (var instancia = new LibrosFachada())
            {
                return instancia.ListarLibros();
            }
        }

        Libros ILibrosService.ObtenerLibroPorId(string id_libro)
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
