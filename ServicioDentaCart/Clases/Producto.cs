using ServicioDentaCart.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ServicioDentaCart.Entidades
{
    public class Producto : ConexionDB
    {
        public class ProductoDB
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public int cant { get; set; }
            public float precio { get; set; }
            public int idprov { get; set; }
            public string nombreprov { get; set; }

        }
        public class ProvDB
        {
            public int id { get; set; }
            public string nombre { get; set; }

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

        public List<ProductoDB> ListarProductoSP(string condicion)
        {
            List<ProductoDB> personas = new List<ProductoDB>();
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "BuscarProductoProveedor";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;
                // Añade los parámetros
                comando.Parameters.AddWithValue("@parametroBusqueda", condicion + "%");
                Conexion.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProductoDB oProd = new ProductoDB();
                    oProd.id = reader.GetInt32(0);
                    oProd.nombre = reader.GetString(1);
                    oProd.cant = reader.GetInt32(2);
                    oProd.precio = Convert.ToSingle(reader[3]);
                    oProd.idprov = reader.GetInt32(4);
                    oProd.nombreprov = reader.GetString(5);
                    personas.Add(oProd);
                }
                reader.Close();
                Conexion.Close();
            }
            return personas;
        }
        //Traer Proveedores para el combo box 
        public DataTable ListaProveedorComboSP()
        {
            DataTable dataTable = new DataTable();
            List<ProvDB> prove = new List<ProvDB>();
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "BuscarProveCombo";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;
                // Añade los parámetros
                Conexion.Open();
                try
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                  Console.WriteLine("Error al obtener datos: " + ex.Message);
                }
            }
            return dataTable;
        }

        //Metodo para insertar Productos
        public void guardarProducto(string nombreproducto, int cantproducto, float precioproducto, int idproveedor)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "InsertarProducto";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@nombreproducto", nombreproducto);
                comando.Parameters.AddWithValue("@cantproducto", cantproducto);
                comando.Parameters.AddWithValue("@precioproducto", precioproducto);
                comando.Parameters.AddWithValue("@idproveedor", idproveedor);

                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Producto insertado correctamente.");
            }
        }
        //Metodo para actualizar Producto
        public void editarProducto(int idproducto, string nombreproducto, int cantproducto, float precioproducto, int idproveedor)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "ActualizarProducto";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@idproducto", idproducto);
                comando.Parameters.AddWithValue("@nombreproducto", nombreproducto);
                comando.Parameters.AddWithValue("@cantproducto", cantproducto);
                comando.Parameters.AddWithValue("@precioproducto", precioproducto);
                comando.Parameters.AddWithValue("@idproveedor", idproveedor);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Producto insertado correctamente.");
            }
        }
        //Metodo para actualizar Clientes
        public void borrarProducto(int idproducto)
        {
            // Establece la conexión a la base de datos
            using (Conexion)
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandText = "EliminarProducto";
                comando.Connection = Conexion;
                comando.CommandType = CommandType.StoredProcedure;

                // Añade los parámetros
                comando.Parameters.AddWithValue("@idproducto", idproducto);
                Conexion.Open();
                // Ejecuta el procedimiento almacenado
                comando.ExecuteNonQuery();

                Console.WriteLine("Producto eliminado correctamente.");
            }
        }

    }
}