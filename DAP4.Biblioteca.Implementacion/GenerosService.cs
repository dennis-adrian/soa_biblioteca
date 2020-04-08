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
    class GenerosService : IGenerosService
    {
        public Generos ActualizarGenero(Generos genero)
        {
            using (var instancia = new GenerosFachada())
            {
                return instancia.ActualizarGenero(genero);
            }
        }

        public bool EliminarGenero(string id_genero)
        {
            using (var instancia = new GenerosFachada())
            {
                return instancia.EliminarGenero(id_genero);
            }
        }

        public Generos InsertarGenero(Generos genero)
        {
            using (var instancia = new GenerosFachada())
            {
                return instancia.InsertarGenero(genero);
            }
        }

        public IEnumerable<Generos> ListarGeneros()
        {
            using (var instancia = new GenerosFachada())
            {
                return instancia.ListarGeneros();
            }
        }
    }
}
