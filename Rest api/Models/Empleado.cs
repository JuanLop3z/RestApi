using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rest_api.Models
{
    //estos atributos son los mismos que los de la tabla "Empleado" en la Base de datos
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}