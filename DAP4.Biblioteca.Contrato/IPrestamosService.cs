using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAP4.Biblioteca.Dominio;
using System.ServiceModel;
using System.ServiceModel.Web;
//Nos permite agregar descripciones a nuestro servicio
using System.ComponentModel;

namespace DAP4.Biblioteca.Contrato
{
    [ServiceContract]
    public interface IPrestamosService
    {
        [OperationContract]
        [Description("Servicio REST que muestra el prestamo segun el codigo")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerPrestamoPorCodigo/?codigo={codigo_prestamo}", BodyStyle = WebMessageBodyStyle.Bare)]
        Prestamos ObtenerPrestamoPorCodigo(string codigo_prestamo);


        [OperationContract]
        [Description("Servicio REST que muestra todos los prestamos")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarPrestamos", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Prestamos> ListarPrestamos();


        [OperationContract]
        [Description("Servicio REST que inserta un prestamo")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/InsertarPrestamo", BodyStyle = WebMessageBodyStyle.Bare)]
        Prestamos InsertarPrestamo(Prestamos prestamo);


        [OperationContract]
        [Description("Servicio REST que permite actualizar un prestamo")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/ActualizarPrestamo", BodyStyle = WebMessageBodyStyle.Bare)]
        Prestamos ActualizarPrestamo(Prestamos prestamo);


        [OperationContract]
        [Description("Servicio REST que modifica el estado de un prestamo a devuelto")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/DevolverPrestamo/?id={id_prestamo}", BodyStyle = WebMessageBodyStyle.Bare)]
        bool DevolverPrestamo(string id_prestamo);
    }
}
