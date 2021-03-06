﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DAP4.Biblioteca.Dominio
{
    [DataContract]
    public class Prestamos
    {
        [DataMember]
        public int id_prestamo { get; set; }
        [DataMember]
        public string prestamo_codigo { get; set; }
        [DataMember]
        public DateTime prestamo_fecha { get; set; }
        [DataMember]
        public DateTime prestamo_devolucion { get; set; }
        [DataMember]
        public bool prestamo_devuelto { get; set; }
        [DataMember]
        public string  libro_nombre { get; set; }
        [DataMember]
        public string cliente_apellido { get; set; }
        [DataMember]
        public string cliente_nombre { get; set; }
        [DataMember]
        public int id_empleado { get; set; }
    }
}
