using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAP4.Biblioteca.Dominio;
using System.ServiceModel;
using System.ComponentModel;
using System.ServiceModel.Web;

namespace DAP4.Biblioteca.Contrato
{
    [ServiceContract]
    public interface ILibrosService
    {
        [OperationContract]
        [Description("Servicio REST que muestra el libro segun el id")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerLibroPorId/?id={id_libro}", BodyStyle = WebMessageBodyStyle.Bare)]
        Libros ObtenerLibroPorId(string id_libro);


        [OperationContract]
        [Description("Servicio REST que muestra el libro segun el nombre")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerLibroPorNombre/?nombre={libro_nombre}", BodyStyle = WebMessageBodyStyle.Bare)]
        Libros ObtenerLibroPorNombre(string libro_nombre);

        
        [OperationContract]
        [Description("Servicio REST que muestra todos los libros")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarLibros", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Libros> ListarLibros();

        [OperationContract]
        [Description("Servicio REST que inserta un libro")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/InsertarLibro", BodyStyle = WebMessageBodyStyle.Bare)]
        Libros InsertarLibro(Libros libro);

        [OperationContract]
        [Description("Servicio REST que permite actualizar un libro")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/ActualizarLibro", BodyStyle = WebMessageBodyStyle.Bare)]
        Libros ActualizarLibro(Libros libro);

        [OperationContract]
        [Description("Servicio REST que permite eliminar un empleado")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "/EliminarLibro/?id={id_libro}", BodyStyle = WebMessageBodyStyle.Bare)]
        bool EliminarLibro(string id_libro);
    }
}
