using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using DAP4.Biblioteca.Dominio;
using System.ComponentModel;
using System.ServiceModel.Web;

namespace DAP4.Biblioteca.Contrato
{
    [ServiceContract]
    public interface IClientesService
    {
        [OperationContract]
        [Description("Servicio REST que muestra el cliente segun el id")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerClientePorId/?id={id_cliente}", BodyStyle = WebMessageBodyStyle.Bare)]
        Clientes ObtenerClientePorId(string id_cliente);

        [OperationContract]
        [Description("Servicio REST que muestra el cliente segun el nombre")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerClientePorApellido/?apellido={cliente_apellido}", BodyStyle = WebMessageBodyStyle.Bare)]
        Clientes ObtenerClientePorApellido(string cliente_apellido);

        [OperationContract]
        [Description("Servicio REST que muestra todos los clientes")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarClientes", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Clientes> ListarClientes();

        [OperationContract]
        [Description("Servicio REST que inserta un cliente")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/InsertarCliente", BodyStyle = WebMessageBodyStyle.Bare)]
        Clientes InsertarCliente(Clientes cliente);

        [OperationContract]
        [Description("Servicio REST que permite actualizar un cliente")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/ActualizarCliente", BodyStyle = WebMessageBodyStyle.Bare)]
        Clientes ActualizarCliente(Clientes cliente);

        [OperationContract]
        [Description("Servicio REST que permite eliminar un cliente")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "/EliminarCliente/?id={id_cliente}", BodyStyle = WebMessageBodyStyle.Bare)]
        bool EliminarCliente(string id_cliente);
    }
}
