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
    public class GenerosFachada : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public Generos ActualizarGenero(Generos genero)
        {
            IGenerosRepositorio instancia = new GenerosRepositorio();
            return instancia.ActualizarGenero(genero);
        }

        public bool EliminarGenero(string id_genero)
        {
            IGenerosRepositorio instancia = new GenerosRepositorio();
            return instancia.EliminarGenero(id_genero);
        }

        public Generos InsertarGenero(Generos genero)
        {
            IGenerosRepositorio instancia = new GenerosRepositorio();
            return instancia.InsertarGenero(genero);
        }

        public IEnumerable<Generos> ListarGeneros()
        {
            IGenerosRepositorio instancia = new GenerosRepositorio();
            return instancia.ListarGeneros();
        }
    }
}
