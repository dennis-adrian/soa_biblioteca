using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DAP4.Biblioteca.Dominio
{
    [DataContract]
    public class Generos
    {
        [DataMember]
        public int id_genero { get; set; }
        [DataMember]
        public string genero_nombre { get; set; }
    }
}
