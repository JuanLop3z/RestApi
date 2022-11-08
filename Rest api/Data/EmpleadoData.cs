using Rest_api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Rest_api.Data
{
    public class EmpleadoData
    {
        //Metodo para guardar el empleado
        public static bool GuardarEmpleado(Empleado empleado) {
            //Se abre la conexion con la base de datos
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion)) 
            {   //aqui le damos El proceso almacenado en la DB a seguir "emp_Guardar"
                SqlCommand cmd = new SqlCommand("emp_Guardar" ,oConexion);
                // aca se especifica el tipo de comando que es de proceso almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //parametros que nesesita el comando para que pueda funcionar
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);


                //intenta abrir la conexion y ejecutar el Query y devuelve "true" si sale exitoso
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }//si falla es "false"
                catch (Exception ex) { 
                    return false;
                }
            }
        }
        //Metodo para modificar empleado
        public static bool ModificarEmpleado(Empleado empleado) {
            //Se abre la conexion con la base de datos
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {//aqui le damos El proceso almacenado en la DB a seguir "emp_Modificar"
                SqlCommand cmd = new SqlCommand("emp_Modificar", oConexion);
                // aca se especifica el tipo de comando que es de proceso almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //aca se ejecuta el query pero en la DB hace el cambio solo con el id y cambia el resto de parametros
                cmd.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);


                //intenta abrir la conexion y ejecutar el Query y devuelve "true" si sale exitoso
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {//si falla es "false"
                    return false;
                }
            }
        }
        //Metodo para Eliminar empleado
        public static bool EliminarEmpleado(int id) {
            //Se abre la conexion con la base de datos
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {//aqui le damos El proceso almacenado en la DB a seguir "emp_Eliminar"
                SqlCommand cmd = new SqlCommand("emp_Eliminar", oConexion);
                // aca se especifica el tipo de comando que es de proceso almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                //solo le pasamos el parametro de "Id" para que se pueda borrar
                cmd.Parameters.AddWithValue("@IdEmpleado", id);


                //intenta abrir la conexion y ejecutar el Query y devuelve "true" si sale exitoso
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }

                catch (Exception ex)
                {//si falla es "false"
                    return false;
                }
            }
        }


        //este es el metodo para Consutar empleado, no explicare cosas que ya explique
        public static Empleado ConsultarEmpleado(int IdEmpleado) {
            //se creaun objeto de la clase "Empleado" que se llama "empleado"
            Empleado empleado = new Empleado();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = new SqlCommand("emp_Consultar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                //se pasa el id y se ejecuta el Query
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    //SqlDataReader nos ayuda a leer los datos y los guarda en una variable
                    using (SqlDataReader data = cmd.ExecuteReader()) {
                        //se leen los datos
                        while (data.Read()){
                            //se usa el objeto que se creo y aparte se guardan en la clase empleado los datos que se nesesitan
                            empleado = new Empleado()
                            {   //se convierte el Id ya que llega como un dato de tipo String el resto si se deja igual
                                IdEmpleado = Convert.ToInt32(data["IdEmpleado"]),
                                Nombre = data["Nombre"].ToString(),
                                Apellido = data["Apellido"].ToString()
                            };
                            
                            
                        }
                        

                    }
                    //se devuelve el objeto empleado que tiene los datos a consultar
                    return empleado;
                }
                catch (Exception ex)
                {
                    return empleado;
                }
            }
        }
        //el metodo listar coge todos los datos de "Empleado" y los guarda en una lista
        public static List<Empleado> Listar() 
        {//se declara la lista
            List<Empleado> ListaEmple = new List<Empleado>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion)) 
            {
                //con un proceso almacenado listo los elementos
                SqlCommand cmd = new SqlCommand("emp_Listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    
                    using (SqlDataReader data = cmd.ExecuteReader())
                    {
                        while (data.Read())
                        {
                            ListaEmple.Add(new Empleado()
                            {
                                IdEmpleado = Convert.ToInt32(data["IdEmpleado"]),
                                Nombre = data["Nombre"].ToString(),
                                Apellido = data["Apellido"].ToString()
                            });
                        }
                    }//se hace el mismo proceso que antes pero esta vez como es una lista me trae todos los datos
                    return ListaEmple;
                }
                catch (Exception ex) { 
                    return ListaEmple;
                }
            }
        }
    }
}