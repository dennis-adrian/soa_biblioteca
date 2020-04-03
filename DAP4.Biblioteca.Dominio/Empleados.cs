using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DAP4.Biblioteca.Dominio
{
    [DataContract]
    public class Empleados
    {
        [DataMember]
        public int id_empleado { get; set; }
        [DataMember]
        public string empleado_nombre { get; set; }
        [DataMember]
        public string empleado_apellido { get; set; }
        [DataMember]
        public string empleado_cargo { get; set; }
        [DataMember]
        public DateTime empleado_fecha_nac { get; set; }
        [DataMember]
        public string empleado_telefono { get; set; }
        [DataMember]
        public string empleado_email { get; set; }
    }
}
