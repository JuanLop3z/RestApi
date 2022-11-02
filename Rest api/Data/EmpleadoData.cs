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
        public static bool GuardarEmpleado(Empleado empleado) {
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion)) 
            {
                SqlCommand cmd = new SqlCommand("emp_Guardar" ,oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) { 
                    return false;
                }
            }
        }
        public static bool ModificarEmpleado(Empleado empleado) {
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = new SqlCommand("emp_Modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public static bool EliminarEmpleado(int id) {
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = new SqlCommand("emp_Eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }



        public static Empleado ConsultarEmpleado(int IdEmpleado) {
            Empleado empleado = new Empleado();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion))
            {
                SqlCommand cmd = new SqlCommand("emp_Consultar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();


                    using (SqlDataReader data = cmd.ExecuteReader()) {

                        while (data.Read()){
                            empleado = new Empleado()
                            {
                                IdEmpleado = Convert.ToInt32(data["IdEmpleado"]),
                                Nombre = data["Nombre"].ToString(),
                                Apellido = data["Apellido"].ToString()
                            };
                            
                            
                        }
                        

                    }

                    return empleado;
                }
                catch (Exception ex)
                {
                    return empleado;
                }
            }
        }
        public static List<Empleado> Listar() 
        {
            List<Empleado> ListaEmple = new List<Empleado>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.conexion)) 
            {
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
                    }
                    return ListaEmple;
                }
                catch (Exception ex) { 
                    return ListaEmple;
                }
            }
        }
    }
}