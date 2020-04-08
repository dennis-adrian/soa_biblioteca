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
    public class AutoresFachada : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public Autores ActualizarAutor(Autores autor)
        {
            IAutoresRepositorio instancia = new AutoresRepositorio();
            return instancia.ActualizarAutor(autor);
        }

        public bool EliminarAutor(string id_autor)
        {
            IAutoresRepositorio instancia = new AutoresRepositorio();
            return instancia.EliminarAutor(id_autor);
        }

        public Autores InsertarAutor(Autores autor)
        {
            IAutoresRepositorio instancia = new AutoresRepositorio();
            return instancia.InsertarAutor(autor);
        }

        public IEnumerable<Autores> ListarAutores()
        {
            IAutoresRepositorio instancia = new AutoresRepositorio();
            return instancia.ListarAutores();
        }

        public Autores ObtenerAutorPorId(string id_autor)
        {
            IAutoresRepositorio instancia = new AutoresRepositorio();
            return instancia.ObtenerAutorPorId(id_autor);
        }

        public Autores ObtenerAutorPorNombre(string nombre_autor)
        {
            IAutoresRepositorio instancia = new AutoresRepositorio();
            return instancia.ObtenerAutorPorNombre(nombre_autor);
        }
    }
}
