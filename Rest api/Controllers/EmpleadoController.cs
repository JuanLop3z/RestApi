using Rest_api.Data;
using Rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Rest_api.Controllers
{
    public class EmpleadoController : ApiController
    {
        //GET api/empleado/
        public List<Empleado> Get() 
        {
            return EmpleadoData.Listar();
        }
        //GET api/empleado/(id)
        public Empleado Get(int IdEmpleado) 
        {
            return EmpleadoData.ConsultarEmpleado(IdEmpleado);
        }
        //POST api/empleado/
        public bool Post([FromBody]Empleado empleado)
        {
            return EmpleadoData.GuardarEmpleado(empleado);
        }
        //PUT api/empleado/
        public bool Put([FromBody] Empleado empleado)
        {
            return EmpleadoData.ModificarEmpleado(empleado);
        }
        //DELETE api/empleado/
        public bool Delete(int id)
        {
            return EmpleadoData.EliminarEmpleado(id);
        }
    }
}
