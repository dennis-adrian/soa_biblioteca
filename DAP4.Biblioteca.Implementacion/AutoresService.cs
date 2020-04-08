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
    public class AutoresService : IAutoresService
    {
        public Autores ActualizarAutor(Autores autor)
        {
            using (var instancia = new AutoresFachada())
            {
                return instancia.ActualizarAutor(autor);
            }
        }

        public bool EliminarAutor(string id_autor)
        {
            using (var instancia = new AutoresFachada())
            {
                return instancia.EliminarAutor(id_autor);
            }
        }

        public Autores InsertarAutor(Autores autor)
        {
            using (var instancia = new AutoresFachada())
            {
                return instancia.InsertarAutor(autor);
            }
        }

        public IEnumerable<Autores> ListarAutores()
        {
            using (var instancia = new AutoresFachada())
            {
                return instancia.ListarAutores();
            }
        }

        public Autores ObtenerAutorPorId(string id_autor)
        {
            using (var instancia = new AutoresFachada())
            {
                return instancia.ObtenerAutorPorId(id_autor);
            }
        }

        public Autores ObtenerAutorPorNombre(string nombre_autor)
        {
            using (var instancia = new AutoresFachada())
            {
                return instancia.ObtenerAutorPorNombre(nombre_autor);
            }
        }
    }
}
