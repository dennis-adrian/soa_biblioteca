using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAP4.Biblioteca.Contrato;
using DAP4.Biblioteca.Dominio;

namespace DAP4.Biblioteca.Implementacion
{
    public class LibrosService : ILibrosService
    {
        public IEnumerable<Libros> ListarLibros()
        {
            return null;
        }

        public Libros ObtenerLibroPorId(int id_libro)
        {
            return null;
        }

        public Libros ObtenerLibroPorNombre(string libro_nombre)
        {
            return null;
        }
    }
}
