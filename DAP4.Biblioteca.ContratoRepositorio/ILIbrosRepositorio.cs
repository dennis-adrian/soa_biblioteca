using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAP4.Biblioteca.Dominio;

namespace DAP4.Biblioteca.ContratoRepositorio
{
    public interface ILibrosRepositorio
    {
        Libros ObtenerLibroPorId(int id_libro);
        Libros ObtenerLibroPorNombre(string libro_nombre);
        IEnumerable<Libros> ListarLibros();
        void InsertarLibro(string libro_nombre, string libro_isbn, int anio_publicacion, string autor_nombre, string genero_nombre);
        Libros ActualizarLibro(int id_libro, string libro_nombre, string libro_isbn, int anio_publicacion, string autor_nombre, string genero_nombre);
        Libros EliminarLibro(int id_libro);
    }
}
