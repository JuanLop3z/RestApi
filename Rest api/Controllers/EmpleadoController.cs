using Rest_api.Data;
using Rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Rest_api.Controllers
{   //nesesario poner la etiqueta de "ApiController" ese nos trae metodos nesesarios para correr el api
    public class EmpleadoController : ApiController
    {
        //GET api/empleado/
        public List<Empleado> Get() 
        {   //hace una lista de "Empleado" y los muestra
            return EmpleadoData.Listar();
        }
        //GET api/empleado/(id)
        public Empleado Get(int IdEmpleado) 
        {   //Obtiene el id ingresado y muestra los datos que concuerden
            return EmpleadoData.ConsultarEmpleado(IdEmpleado);
        }
        //POST api/empleado/
        public bool Post([FromBody]Empleado empleado)
        {   //Guarda un nuevo empleado pasado por formato JSON 
            return EmpleadoData.GuardarEmpleado(empleado);
        }
        //PUT api/empleado/
        public bool Put([FromBody] Empleado empleado)
        {   //Actualiza el empleado con el id que se le pase al igual en formato JSON
            return EmpleadoData.ModificarEmpleado(empleado);
        }
        //DELETE api/empleado/id
        public bool Delete(int id)
        {   //Solo es introducir el id correspondiente
            return EmpleadoData.EliminarEmpleado(id);
        }
    }
}
