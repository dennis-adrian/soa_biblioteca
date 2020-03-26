using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DAP4.Biblioteca.Dominio
{
    [DataContract]
    public class Autores
    {
        [DataMember]
        public int id_autor { get; set; }
        [DataMember]
        public string  autor_nombre { get; set; }
        [DataMember]
        public string autor_pais { get; set; }

    }
}
