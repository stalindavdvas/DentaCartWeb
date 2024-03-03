using ServicioDentaCart.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ServicioDentaCart.Entidades
{
   public class Proveedor : ConexionDB
    {
        public class ProveedorDB
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string dni { get; set; }
            public string dir { get; set; }
            public string correo { get; set; }
            public string telefono { get; set; }

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

        public List<ProveedorDB> ListarProveedorSP(string condicion)
        {
            List<ProveedorDB> personas = new List<ProveedorDB>();
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "BuscarProveedor";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;
                // Añade los parámetros
                comando.Parameters.AddWithValue("@parametroBusqueda", condicion + "%");
                Conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProveedorDB oProv = new ProveedorDB();
                    oProv.id = reader.GetInt32(0);
                    oProv.nombre = reader.GetString(1);
                    oProv.dni = reader.GetString(2);
                    oProv.dir = reader.GetString(3);
                    oProv.correo = reader.GetString(4);
                    oProv.telefono = reader.GetString(5);
                    personas.Add(oProv);
                }
                reader.Close();
                Conexion.Close();
            }
            return personas;
        }
        //Traer Proveedor por id
        public ProveedorDB ObtenerProveedorPorId(int proveedorID)
        {
            ProveedorDB proveedor = null;
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "ObtenerProveedorPorID";  // Nombre de tu procedimiento almacenado
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade el parámetro para el ID del proveedor
                comando.Parameters.AddWithValue("@ProveedorID", proveedorID);

                Conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    proveedor = new ProveedorDB
                    {
                        id = reader.GetInt32(0),
                        nombre = reader.GetString(1),
                        dni = reader.GetString(2),
                        dir = reader.GetString(3),
                        correo = reader.GetString(4),
                        telefono = reader.GetString(5)
                    };
                }
                reader.Close();
                Conexion.Close();
            }
            return proveedor;
        }

        //Metodo para insertar Clientes
        public void guardarProveedor(string nombreproveedor, string dniproveedor, string dirproveedor, string emailproveedor, string telfproveedor)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "InsertarProveedor";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@nombreproveedor", nombreproveedor);
                comando.Parameters.AddWithValue("@dniproveedor", dniproveedor);
                comando.Parameters.AddWithValue("@dirproveedor", dirproveedor);
                comando.Parameters.AddWithValue("@emailproveedor", emailproveedor);
                comando.Parameters.AddWithValue("@telfproveedor", telfproveedor);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Proveedor insertado correctamente.");
            }
        }
        //Metodo para actualizar Clientes
        public void editarProveedor(int idproveedor, string nombreproveedor, string dniproveedor, string dirproveedor, string emailproveedor, string telfproveedor)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "ActualizarProveedor";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@idproveedor", idproveedor);
                comando.Parameters.AddWithValue("@nombreproveedor", nombreproveedor);
                comando.Parameters.AddWithValue("@dniproveedor", dniproveedor);
                comando.Parameters.AddWithValue("@dirproveedor", dirproveedor);
                comando.Parameters.AddWithValue("@emailproveedor", emailproveedor);
                comando.Parameters.AddWithValue("@telfproveedor", telfproveedor);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Proveedor insertado correctamente.");
            }
        }
        //Metodo para actualizar Clientes
        public void borrarProveedor(int idproveedor)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EliminarProveedor";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@idproveedor", idproveedor);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Proveedor eliminado correctamente.");
            }
        }

    }
}