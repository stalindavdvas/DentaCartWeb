using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using ServicioDentaCart.Clases;
using ServicioDentaCart.Entidades;
using static ServicioDentaCart.Entidades.Empleado;
using static ServicioDentaCart.Entidades.Cliente;
using static ServicioDentaCart.Entidades.Proveedor;
using static ServicioDentaCart.Entidades.Producto;


namespace ServicioDentaCart
{
    /// <summary>
    /// Descripción breve de WebServiceDentaCart
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceDentaCart : System.Web.Services.WebService
    {
        ConexionDB conDB=new ConexionDB();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola esto es una prueba en vivo de asmx";
        }
        //======================================Metodos para Cliente======================================================
        [WebMethod]
        public List<ClienteDB> ListarCliente(string filtro)
        {
            Cliente cliente = new Cliente();
            return cliente.ListarClientesSP(filtro);
        }

        [WebMethod]
        public void InsertarCliente(string nombrecliente, string dnicliente, string dircliente, string emailcliente, string telfcliente)
        {
            Cliente cliente = new Cliente();
            cliente.guardarCliente(nombrecliente, dnicliente, dircliente, emailcliente, telfcliente);
        }

        [WebMethod]
        public void ActualizarCliente(int idcliente, string nombrecliente, string dnicliente, string dircliente, string emailcliente, string telfcliente)
        {
            Cliente cliente = new Cliente();
            cliente.editarCliente(idcliente, nombrecliente, dnicliente, dircliente, emailcliente, telfcliente);
        }

        [WebMethod]
        public void EliminarCliente(int idcliente)
        {
            Cliente cliente = new Cliente();
            cliente.borrarCliente(idcliente);
        }

       

        //======================================Metodos para Empleado======================================================
        [WebMethod]
        public List<EmpleadoDB> ListarEmpleado(string condicion)
        {
            Empleado empleado = new Empleado();
            return empleado.ListarEmpleadoSP(condicion);
        }
        [WebMethod]
        public EmpleadoDB ObtenerEmpleadoPorId(int empleadoID)
        {
            Empleado empleado = new Empleado();
            return empleado.ListarEmpleadoPorId(empleadoID);
        }

        [WebMethod]
        public void GuardarEmpleado(string nombreempleado, string dniempleado, string dirempleado, string emailempleado, string telfempleado, string tipoempleado, string passempleado)
        {
            Empleado empleado = new Empleado();
            empleado.guardarEmpleado(nombreempleado, dniempleado, dirempleado, emailempleado, telfempleado, tipoempleado, passempleado);
        }

        [WebMethod]
        public void EditarEmpleado(int idempleado, string nombreempleado, string dniempleado, string dirempleado, string emailempleado, string telfempleado, string tipoempleado, string passempleado)
        {
            Empleado empleado = new Empleado();
            empleado.editarEmpleado(idempleado, nombreempleado, dniempleado, dirempleado, emailempleado, telfempleado, tipoempleado, passempleado);
        }

        [WebMethod]
        public void BorrarEmpleado(int idempleado)
        {
            Empleado empleado = new Empleado();
            empleado.borrarEmpleado(idempleado);
        }

        [WebMethod]
        public EmpleadoDB LoginUsuario(string nombreempleado, string passempleado)
        {
            Empleado empleado = new Empleado();
            return empleado.loginUsuario(nombreempleado, passempleado);
        }

        //======================================Metodos para Proveedor======================================================

        [WebMethod]
        public List<ProveedorDB> ListarProveedor(string parametroBusqueda)
        {
            Proveedor proveedor = new Proveedor();
            return proveedor.ListarProveedorSP(parametroBusqueda);
        }

        [WebMethod]
        public void InsertarProveedor(string nombreproveedor, string dniproveedor, string dirproveedor, string emailproveedor, string telfproveedor)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.guardarProveedor(nombreproveedor, dniproveedor, dirproveedor, emailproveedor, telfproveedor);
        }

        [WebMethod]
        public void ActualizarProveedor(int idproveedor, string nombreproveedor, string dniproveedor, string dirproveedor, string emailproveedor, string telfproveedor)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.editarProveedor(idproveedor, nombreproveedor, dniproveedor, dirproveedor, emailproveedor, telfproveedor);
        }

        [WebMethod]
        public void EliminarProveedor(int idproveedor)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.borrarProveedor(idproveedor);
        }
        //======================================Metodos para productos======================================================
        [WebMethod]
        public List<ProductoDB> ListarProducto(string parametroBusqueda)
        {
            Producto producto = new Producto();
            return producto.ListarProductoSP(parametroBusqueda);
        }

        [WebMethod]
        public void InsertarProducto(string nombreproducto, int cantproducto, float precioproducto, int idproveedor)
        {
            Producto producto = new Producto();
            producto.guardarProducto(nombreproducto, cantproducto, precioproducto, idproveedor);
        }

        [WebMethod]
        public void ActualizarProducto(int idproducto, string nombreproducto, int cantproducto, float precioproducto, int idproveedor)
        {
            Producto producto = new Producto();
            producto.editarProducto(idproducto, nombreproducto, cantproducto, precioproducto, idproveedor);
        }

        [WebMethod]
        public void EliminarProducto(int idproducto)
        {
            Producto producto = new Producto();
            producto.borrarProducto(idproducto);
        }


        //======================================Metodos para CabFactura======================================================
        //[WebMethod]
        //public List<CabeceraFacturaDB> ListarCabeceraFactura(int numerocabecera)
        //{
        //    CabeceraFactura cabeceraFactura = new CabeceraFactura();
        //    return cabeceraFactura.ListarCabeceraFactura(numerocabecera);
        //}

        //[WebMethod]
        //public void InsertarCabeceraFactura(int numerocabecera, DateTime fechacabecera, float totalcabecera, float impuestocabecera, int idcliente)
        //{
        //    CabeceraFactura cabeceraFactura = new CabeceraFactura();
        //    cabeceraFactura.InsertarCabeceraFactura(numerocabecera, fechacabecera, totalcabecera, impuestocabecera, idcliente);
        //}

        //[WebMethod]
        //public void ActualizarCabeceraFactura(int numerocabecera, DateTime fechacabecera, float totalcabecera, float impuestocabecera, int idcliente)
        //{
        //    CabeceraFactura cabeceraFactura = new CabeceraFactura();
        //    cabeceraFactura.ActualizarCabeceraFactura(numerocabecera, fechacabecera, totalcabecera, impuestocabecera, idcliente);
        //}

        //[WebMethod]
        //public void EliminarCabeceraFactura(int numerocabecera)
        //{
        //    CabeceraFactura cabeceraFactura = new CabeceraFactura();
        //    cabeceraFactura.EliminarCabeceraFactura(numerocabecera);
        //}

        //[WebMethod]
        //public void InsertarCabeceraFactura(int numeroCabecera, DateTime fechaCabecera, float totalCabecera, float impuestoCabecera, int idCliente)
        //{
        //    using (SqlConnection conexion = conDB.ObtenerConexion())
        //    {
        //        using (SqlCommand command = new SqlCommand("InsertarCabeceraFactura", conexion))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@numerocabecera", numeroCabecera);
        //            command.Parameters.AddWithValue("@fechacabecera", fechaCabecera);
        //            command.Parameters.AddWithValue("@totalcabecera", totalCabecera);
        //            command.Parameters.AddWithValue("@impuestocabecera", impuestoCabecera);
        //            command.Parameters.AddWithValue("@idcliente", idCliente);

        //            try
        //            {
        //                conexion.Open();
        //                command.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                // Manejar la excepción según tus necesidades.
        //                throw;
        //            }
        //        }
        //    }
        //}

        //[WebMethod]
        //public DataTable BuscarCabeceraFactura(int numeroCabecera)
        //{
        //    DataTable resultTable = new DataTable("CabeceraFactura");

        //    using (SqlConnection conexion = conDB.ObtenerConexion())
        //    {
        //        using (SqlCommand command = new SqlCommand("BuscarCabeceraFactura", conexion))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@numerocabecera", numeroCabecera);

        //            try
        //            {
        //                conexion.Open();
        //                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //                {
        //                    adapter.Fill(resultTable);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                // Manejar la excepción según tus necesidades.
        //                throw;
        //            }
        //        }
        //    }

        //    return resultTable;
        //}

        //[WebMethod]
        //public void ActualizarCabeceraFactura(int numeroCabecera, DateTime fechaCabecera, float totalCabecera, float impuestoCabecera, int idCliente)
        //{
        //    using (SqlConnection conexion = conDB.ObtenerConexion())
        //    {
        //        using (SqlCommand command = new SqlCommand("ActualizarCabeceraFactura", conexion))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@numerocabecera", numeroCabecera);
        //            command.Parameters.AddWithValue("@fechacabecera", fechaCabecera);
        //            command.Parameters.AddWithValue("@totalcabecera", totalCabecera);
        //            command.Parameters.AddWithValue("@impuestocabecera", impuestoCabecera);
        //            command.Parameters.AddWithValue("@idcliente", idCliente);

        //            try
        //            {
        //                conexion.Open();
        //                command.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                // Manejar la excepción según tus necesidades.
        //                throw;
        //            }
        //        }
        //    }
        //}

        //[WebMethod]
        //public void EliminarCabeceraFactura(int numeroCabecera)
        //{
        //    using (SqlConnection conexion = conDB.ObtenerConexion())
        //    {
        //        using (SqlCommand command = new SqlCommand("EliminarCabeceraFactura", conexion))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@numerocabecera", numeroCabecera);

        //            try
        //            {
        //                conexion.Open();
        //                command.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                // Manejar la excepción según tus necesidades.
        //                throw;
        //            }
        //        }
        //    }
        //}
        //======================================Metodos para DetalleFactura======================================================
        //[WebMethod]
        //public List<DetalleFacturaDB> ListarDetalleFactura(int numerocabecera)
        //{
        //    DetalleFactura detalleFactura = new DetalleFactura();
        //    return detalleFactura.ListarDetalleFactura(numerocabecera);
        //}

        //[WebMethod]
        //public void InsertarDetalleFactura(int idprod, int cantdetalleprod, float subtotalprod, int idcabecera)
        //{
        //    DetalleFactura detalleFactura = new DetalleFactura();
        //    detalleFactura.InsertarDetalleFactura(idprod, cantdetalleprod, subtotalprod, idcabecera);
        //}

        //[WebMethod]
        //public void ActualizarDetalleFactura(int iddetalle, int idprod, int cantdetalleprod, float subtotalprod)
        //{
        //    DetalleFactura detalleFactura = new DetalleFactura();
        //    detalleFactura.ActualizarDetalleFactura(iddetalle, idprod, cantdetalleprod, subtotalprod);
        //}

        //[WebMethod]
        //public void EliminarDetalleFactura(int iddetalle)
        //{
        //    DetalleFactura detalleFactura = new DetalleFactura();
        //    detalleFactura.EliminarDetalleFactura(iddetalle);
        //}


        //[WebMethod]
        //public void InsertarDetalleFactura(int idProducto, int cantidad, float subtotal, int idCabecera)
        //{
        //    using (SqlConnection conexion = conDB.ObtenerConexion())
        //    {
        //        using (SqlCommand command = new SqlCommand("InsertarDetalleFactura", conexion))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@idprod", idProducto);
        //            command.Parameters.AddWithValue("@cantdetalleprod", cantidad);
        //            command.Parameters.AddWithValue("@subtotalprod", subtotal);
        //            command.Parameters.AddWithValue("@idcabecera", idCabecera);

        //            try
        //            {
        //                conexion.Open();
        //                command.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                // Manejar la excepción según tus necesidades.
        //                throw;
        //            }
        //        }
        //    }
        //}

        //[WebMethod]
        //public DataTable BuscarDetalleFactura(int numeroCabecera)
        //{
        //    DataTable resultTable = new DataTable("DetalleFactura");

        //    using (SqlConnection conexion = conDB.ObtenerConexion())
        //    {
        //        using (SqlCommand command = new SqlCommand("BuscarDetalleFactura", conexion))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@numerocabecera", numeroCabecera);

        //            try
        //            {
        //                conexion.Open();
        //                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //                {
        //                    adapter.Fill(resultTable);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                // Manejar la excepción según tus necesidades.
        //                throw;
        //            }
        //        }
        //    }

        //    return resultTable;
        //}

        //[WebMethod]
        //public void ActualizarDetalleFactura(int idDetalle, int idProducto, int cantidad, float subtotal)
        //{
        //    using (SqlConnection conexion = conDB.ObtenerConexion())
        //    {
        //        using (SqlCommand command = new SqlCommand("ActualizarDetalleFactura", conexion))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@iddetalle", idDetalle);
        //            command.Parameters.AddWithValue("@idprod", idProducto);
        //            command.Parameters.AddWithValue("@cantdetalleprod", cantidad);
        //            command.Parameters.AddWithValue("@subtotalprod", subtotal);

        //            try
        //            {
        //                conexion.Open();
        //                command.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                // Manejar la excepción según tus necesidades.
        //                throw;
        //            }
        //        }
        //    }
        //}

        //[WebMethod]
        //public void EliminarDetalleFactura(int idDetalle)
        //{
        //    using (SqlConnection conexion = conDB.ObtenerConexion())
        //    {
        //        using (SqlCommand command = new SqlCommand("EliminarDetalleFactura", conexion))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@iddetalle", idDetalle);

        //            try
        //            {
        //                conexion.Open();
        //                command.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                // Manejar la excepción según tus necesidades.
        //                throw;
        //            }
        //        }
        //    }
        //}


    }
}
