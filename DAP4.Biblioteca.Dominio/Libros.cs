using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DAP4.Biblioteca.Dominio
{
    [DataContract]
    public class Libros
    {
        [DataMember]
        public int id_libro { get; set; }
        [DataMember]
        public string libro_nombre { get; set; }
        [DataMember]
        public string libro_isbn { get; set; }
        [DataMember]
        public int libro_anio_publicacion { get; set; }
        [DataMember]
        public string autor_nombre { get; set; }
        [DataMember]
        public string genero_nombre { get; set; }
    }
}
