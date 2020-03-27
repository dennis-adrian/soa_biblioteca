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
    }
}
