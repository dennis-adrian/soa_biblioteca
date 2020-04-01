using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAP4.Biblioteca.Dominio;
using System.ServiceModel;

namespace DAP4.Biblioteca.Contrato
{
    [ServiceContract]
    public interface ILibrosService
    {
        [OperationContract]
        //crear un método que nos devuelva suppliers
        Libros ObtenerLibroPorId(int id_libro);
        [OperationContract]
        Libros ObtenerLibroPorNombre(string libro_nombre);

        //crear un método que nos devuelva una lista con todos los proveedores
        [OperationContract]
        IEnumerable<Libros> ListarLibros();
        [OperationContract]
        void InsertarLibro(string libro_nombre, string libro_isbn, int anio_publicacion, string autor_nombre, string genero_nombre);
        [OperationContract]
        Libros ActualizarLibro(int id_libro, string libro_nombre, string libro_isbn, int anio_publicacion, string autor_nombre, string genero_nombre);
        [OperationContract]
        Libros EliminarLibro(int id_libro);
    }
}
