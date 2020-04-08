using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAP4.Biblioteca.Dominio;

namespace DAP4.Biblioteca.ContratoRepositorio
{
    public interface IGenerosRepositorio
    {
        IEnumerable<Generos> ListarGeneros();
        Generos InsertarGenero(Generos genero);
        Generos ActualizarGenero(Generos genero);
        bool EliminarGenero(string id_genero);
    }
}
