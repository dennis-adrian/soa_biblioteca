using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DAP4.Biblioteca.Dominio
{
	[DataContract]
    public class Clientes
    {
		[DataMember]
		public int id_cliente { get; set; }
		[DataMember]
		public string cliente_nombre { get; set; }
		[DataMember]
		public string cliente_apellido { get; set; }
		[DataMember]
		public DateTime cliente_fecha_nac { get; set; }
		[DataMember]
		public string cliente_domicilio { get; set; }
		[DataMember]
		public string cliente_telefono { get; set; }
		[DataMember]
		public string cliente_email { get; set; }
	}
}
