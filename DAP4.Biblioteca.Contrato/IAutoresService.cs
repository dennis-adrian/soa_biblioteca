using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAP4.Biblioteca.Dominio;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;

namespace DAP4.Biblioteca.Contrato
{
    [ServiceContract]
    public interface IAutoresService
    {
        [OperationContract]
        [Description("Servicio REST que muestra todos los autores")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarAutores", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Autores> ListarAutores();

        [OperationContract]
        [Description("Servicio REST que muestra el autor segun el id")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerAutorPorId/?id={id_autor}", BodyStyle = WebMessageBodyStyle.Bare)]
        Autores ObtenerAutorPorId(string id_autor);

        [OperationContract]
        [Description("Servicio REST que muestra el autor segun el nombre")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerAutorPorNombre/?nombre={nombre_autor}", BodyStyle = WebMessageBodyStyle.Bare)]
        Autores ObtenerAutorPorNombre(string nombre_autor);

        [OperationContract]
        [Description("Servicio REST que inserta un autor")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/InsertarAutor", BodyStyle = WebMessageBodyStyle.Bare)]
        Autores InsertarAutor(Autores autor);

        [OperationContract]
        [Description("Servicio REST que permite actualizar un autor")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/ActualizarAutor", BodyStyle = WebMessageBodyStyle.Bare)]
        Autores ActualizarAutor(Autores autor);

        [OperationContract]
        [Description("Servicio REST que permite eliminar un autor")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "/EliminarAutor/?id={id_autor}", BodyStyle = WebMessageBodyStyle.Bare)]
        bool EliminarAutor(string id_autor);
    }
}
