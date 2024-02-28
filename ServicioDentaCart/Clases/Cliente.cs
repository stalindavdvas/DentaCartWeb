using ServicioDentaCart.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ServicioDentaCart.Entidades
{
    public class Cliente: ConexionDB
    {
        public class ClienteDB
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
                Console.Write("Error:" + ex.Message);
                return false;
            }

        }

        public List<ClienteDB> ListarClientesSP(string condicion)
        {
            List<ClienteDB> personas = new List<ClienteDB>();
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "traerCliente";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;
                // Añade los parámetros
                comando.Parameters.AddWithValue("@filtro", condicion + "%");
                Conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ClienteDB oCli = new ClienteDB();
                    oCli.id = reader.GetInt32(0);
                    oCli.nombre = reader.GetString(1);
                    oCli.dni = reader.GetString(2);
                    oCli.dir = reader.GetString(3);
                    oCli.correo = reader.GetString(4);
                    oCli.telefono = reader.GetString(5);
                    personas.Add(oCli);
                }
                reader.Close();
                Conexion.Close();
            }
            return personas;
        }
        //Metodo para insertar Clientes
        public void guardarCliente(string nombrecliente, string dnicliente, string dircliente, string emailcliente, string telfcliente)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "InsertarCliente";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@nombrecliente", nombrecliente);
                comando.Parameters.AddWithValue("@dnicliente", dnicliente);
                comando.Parameters.AddWithValue("@dircliente", dircliente);
                comando.Parameters.AddWithValue("@emailcliente", emailcliente);
                comando.Parameters.AddWithValue("@telfcliente", telfcliente);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Cliente insertado correctamente.");
            }
        }
        //Metodo para actualizar Clientes
        public void editarCliente(int idcliente, string nombrecliente, string dnicliente, string dircliente, string emailcliente, string telfcliente)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "ActualizarCliente";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@idcliente", idcliente);
                comando.Parameters.AddWithValue("@nombrecliente", nombrecliente);
                comando.Parameters.AddWithValue("@dnicliente", dnicliente);
                comando.Parameters.AddWithValue("@dircliente", dircliente);
                comando.Parameters.AddWithValue("@emailcliente", emailcliente);
                comando.Parameters.AddWithValue("@telfcliente", telfcliente);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Cliente insertado correctamente.");
            }
        }
        //Metodo para actualizar Clientes
        public void borrarCliente(int idcliente)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EliminarCliente";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@idcliente", idcliente);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Cliente eliminado correctamente.");
            }
        }
    }
}