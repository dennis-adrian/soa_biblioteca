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
    public interface IGenerosService
    {
        [OperationContract]
        [Description("Servicio REST que muestra todos los generos")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarGeneros", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Generos> ListarGeneros();

        [OperationContract]
        [Description("Servicio REST que inserta un genero literario")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/InsertarGenero", BodyStyle = WebMessageBodyStyle.Bare)]
        Generos InsertarGenero(Generos genero);

        [OperationContract]
        [Description("Servicio REST que permite actualizar un genero")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/ActualizarGenero", BodyStyle = WebMessageBodyStyle.Bare)]
        Generos ActualizarGenero(Generos genero);

        [OperationContract]
        [Description("Servicio REST que permite eliminar un genero")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "/EliminarGenero/?id={id_genero}", BodyStyle = WebMessageBodyStyle.Bare)]
        bool EliminarGenero(string id_genero);
    }
}
