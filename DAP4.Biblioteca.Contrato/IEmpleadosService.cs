using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using DAP4.Biblioteca.Dominio;
using System.ServiceModel.Web;
//Nos permite agregar descripciones a nuestro servicio
using System.ComponentModel;

namespace DAP4.Biblioteca.Contrato
{
    [ServiceContract]
    public interface IEmpleadosService
    {
        [OperationContract]
        [Description("Servicio REST que muestra todos los empleados")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarEmpleados", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Empleados> ListarEmpleados();
        
        [OperationContract]
        [Description("Servicio REST que muestra el empleado segun el id")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerEmpleadoPorId/?id={id}", BodyStyle = WebMessageBodyStyle.Bare)]
        Empleados ObtenerEmpleadosPorId(string id);
        
        [OperationContract]
        [Description("Servicio REST que muestra el empleado segun el apellido")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerEmpleadoPorNombre/?apellido={apellido}", BodyStyle = WebMessageBodyStyle.Bare)]
        Empleados ObtenerEmpleadosPorApellido(string apellido);
        
        [OperationContract]
        [Description("Servicio REST que inserta un empleado")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/InsertarEmpleado", BodyStyle = WebMessageBodyStyle.Bare)]
        Empleados InsertarEmpleados(Empleados empleado);
        
        [OperationContract]
        [Description("Servicio REST que permite actualizar un empleado")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/ActualizarEmpleado", BodyStyle = WebMessageBodyStyle.Bare)]
        Empleados ActualizarEmpleado(Empleados empleado);
        
        [OperationContract]
        [Description("Servicio REST que permite eliminar un empleado")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "/EliminarEmpleado/?id={id}", BodyStyle = WebMessageBodyStyle.Bare)]
        bool EliminarEmpleado(string id);
    }
}
