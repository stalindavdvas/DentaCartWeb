using ServicioDentaCart.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ServicioDentaCart.Entidades
{
   public class Empleado : ConexionDB
    {
        public class EmpleadoDB
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string dni { get; set; }
            public string dir { get; set; }
            public string correo { get; set; }
            public string telefono { get; set; }
            public string tipo { get; set; }
            public string pass { get; set; }

        }
        public bool validarConexion()
        {
            try
            {
                Conexion.Open();
                Conexion.Close();

                return true;
            }
            catch (Exception ex)
            {
               Console.WriteLine("Error:" + ex.Message);
                return false;
            }

        }

        public List<EmpleadoDB> ListarEmpleadoSP(string condicion)
        {
            List<EmpleadoDB> empleado = new List<EmpleadoDB>();
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "BuscarEmpleado";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;
                // Añade los parámetros
                comando.Parameters.AddWithValue("@parametroBusqueda", condicion + "%");
                Conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EmpleadoDB oEmpl = new EmpleadoDB();
                    oEmpl.id = reader.GetInt32(0);
                    oEmpl.nombre = reader.GetString(1);
                    oEmpl.dni = reader.GetString(2);
                    oEmpl.dir = reader.GetString(3);
                    oEmpl.correo = reader.GetString(4);
                    oEmpl.telefono = reader.GetString(5);
                    oEmpl.tipo = reader.GetString(6);
                    oEmpl.pass = reader.GetString(7);

                    empleado.Add(oEmpl);
                }
                reader.Close();
                Conexion.Close();
            }
            return empleado;
        }
        public EmpleadoDB ListarEmpleadoPorId(int condicion)
        {
            EmpleadoDB empleado = new EmpleadoDB();
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "BuscarEmpleadoPorID";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;
                // Añade los parámetros
                comando.Parameters.AddWithValue("@EmpleadoID", condicion);
                Conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    empleado.id = reader.GetInt32(0);
                    empleado.nombre = reader.GetString(1);
                    empleado.dni = reader.GetString(2);
                    empleado.dir = reader.GetString(3);
                    empleado.correo = reader.GetString(4);
                    empleado.telefono = reader.GetString(5);
                    empleado.tipo = reader.GetString(6);
                    empleado.pass = reader.GetString(7);
                }
                reader.Close();
                Conexion.Close();
            }
            return empleado;
        }
        //Metodo para insertar Clientes
        public void guardarEmpleado(string nombreempleado, string dniempleado, string dirempleado, string emailempleado, string telfempleado, string tipoempleado, string passempleado)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "InsertarEmpleado";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@nombreempleado", nombreempleado);
                comando.Parameters.AddWithValue("@dniempleado", dniempleado);
                comando.Parameters.AddWithValue("@dirempleado", dirempleado);
                comando.Parameters.AddWithValue("@emailempleado", emailempleado);
                comando.Parameters.AddWithValue("@telfempleado", telfempleado);
                comando.Parameters.AddWithValue("@tipoempleado", tipoempleado);
                comando.Parameters.AddWithValue("@passempleado", passempleado);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Empleado insertado correctamente.");
            }
        }
        //Metodo para actualizar Clientes
        public void editarEmpleado(int idempleado, string nombreempleado, string dniempleado, string dirempleado, string emailempleado, string telfempleado, string tipoempleado, string passempleado)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "ActualizarEmpleado";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@idempleado", idempleado);
                comando.Parameters.AddWithValue("@nombreempleado", nombreempleado);
                comando.Parameters.AddWithValue("@dniempleado", dniempleado);
                comando.Parameters.AddWithValue("@dirempleado", dirempleado);
                comando.Parameters.AddWithValue("@emailempleado", emailempleado);
                comando.Parameters.AddWithValue("@telfempleado", telfempleado);
                comando.Parameters.AddWithValue("@tipoempleado", tipoempleado);
                comando.Parameters.AddWithValue("@passempleado", passempleado);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Empleado Actualizado correctamente.");
            }
        }
        //Metodo para actualizar Clientes
        public void borrarEmpleado(int idempleado)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EliminarEmpleado";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@idempleado", idempleado);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Empleado eliminado correctamente.");
            }
        }

        //Metodo para actualizar Clientes
        public EmpleadoDB loginUsuario(string nombreempleado, string passempleado)
        {
            bool login;
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "ValidarUsuario";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@NombreUsuario", nombreempleado);
                comando.Parameters.AddWithValue("@Clave", passempleado);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read()) // Si hay resultados
                {
                    // Crear un objeto Usuario con los datos obtenidos
                    EmpleadoDB existe = new EmpleadoDB
                    {

                        nombre = reader["nombreempleado"].ToString(),
                        tipo = reader["tipoempleado"].ToString(),
                        pass = reader["passempleado"].ToString()
                        // Agrega otras propiedades según tus necesidades
                    };

                    return existe;
                }
                // No se encontraron resultados
                return null;
            }

        }
    }
}