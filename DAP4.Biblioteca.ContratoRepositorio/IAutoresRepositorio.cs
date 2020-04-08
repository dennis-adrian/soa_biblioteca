using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAP4.Biblioteca.Dominio;

namespace DAP4.Biblioteca.ContratoRepositorio
{
    public interface IAutoresRepositorio
    {
        IEnumerable<Autores> ListarAutores();
        Autores ObtenerAutorPorId(string id_autor);
        Autores ObtenerAutorPorNombre(string nombre_autor);
        Autores InsertarAutor(Autores autor);
        Autores ActualizarAutor(Autores autor);
        bool EliminarAutor(string id_autor);

    }
}
