using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentaCartASP.Formularios
{
    public partial class Productos1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar el valor almacenado en sesión
                string emailUsuario = (string)Session["EmailUsuario"];
                string tipoUsuario = (string)Session["TipoUsuario"];
                if (emailUsuario == null && tipoUsuario == null)
                {
                    Response.Redirect("IniciarSesion.aspx");
                }
                else
                {
                    cargarProductos();
                    CargarProveedores();
                    habilitar(false);
                    btnActualizar.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    cmbProveedor.Enabled = false;
                }
            }
            
        }


        public void cargarProductos() {

            try
            {
                // Instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient servicio = new ServicioDentaCart.WebServiceDentaCartSoapClient();

                // Llamada al método del servicio web para obtener la lista de empleados
                List<ServicioDentaCart.ProductoDB> listaProductos = servicio.ListarProducto("").Cast<ServicioDentaCart.ProductoDB>().ToList();

                // Enlazar la lista de empleados al GridView
                gvProductos.DataSource = listaProductos;
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar el error (puedes mostrar un mensaje de error en la página)
                Console.WriteLine($"Error al obtener la lista de empleados: {ex.Message}");
                // Inicio de sesión no exitoso, mostrar alerta
                ltlAlertaProductos.Text = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>No se puede cargar los datos.<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
            }

        }

        private void CargarProveedores()
        {
            try
            {
                // Instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient servicio = new ServicioDentaCart.WebServiceDentaCartSoapClient();

                // Llamada al método del servicio web para obtener la lista de clientes
                List<ServicioDentaCart.ProveedorDB> listaProveedores = servicio.ListarProveedor("").Cast<ServicioDentaCart.ProveedorDB>().ToList();


                // Agrega un elemento inicial al DropDownList
                cmbProveedor.Items.Add(new ListItem("Elige un proveedor", ""));

                // Agrega los proveedores al DropDownList
                foreach (ServicioDentaCart.ProveedorDB proveedor in listaProveedores)
                {
                    cmbProveedor.Items.Add(new ListItem(proveedor.nombre, proveedor.id.ToString()));
                }
            }
            catch (Exception ex)
            {
                // Manejar el error (puedes mostrar un mensaje de error en la página)
                Console.WriteLine($"Error al obtener la lista de Proveedores: {ex.Message}");
            }
        }
        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void gvClientes_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")

            {
                habilitar(true);
                btnActualizar.Enabled = true;
                btnCancelar.Enabled = true;
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = false;
                cmbProveedor.Enabled = false;
                // Obtener el índice de la fila seleccionada
                int indiceFila = Convert.ToInt32(e.CommandArgument);

                // Obtener el valor de la clave primaria de la fila seleccionada (asumo que es "id" en este caso)
                int idProducto = Convert.ToInt32(gvProductos.DataKeys[indiceFila].Value);
               
                // Crear una instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();

                try
                {
                    // Llamar al método del servicio web para obtener los detalles del empleado
                    ServicioDentaCart.ProductoDB productoSeleccionado = clienteServicioWeb.ObtenerProductoPorId(idProducto);

                    // Asignar los valores a los TextBox del modal
                    if (productoSeleccionado != null)
                    {
                        txtId.Text = productoSeleccionado.id.ToString();
                        txtNombre.Text = productoSeleccionado.nombre;
                        txtCant.Text = productoSeleccionado.cant.ToString();
                        txtPrecio.Text = productoSeleccionado.precio.ToString();
                        txtCodProv.Text = productoSeleccionado.idprov.ToString();

                    }
                    Console.WriteLine($"Respuesta del servicio web: {productoSeleccionado}");
                    // Mostrar el modal
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModal", "$('#modalEditar').modal('show');", true);
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante la llamada al servicio web
                    // Puedes registrar el error, mostrar un mensaje al usuario, etc.
                    Console.WriteLine($"Error al llamar al servicio web: {ex.Message}");
                }
                finally
                {
                    // Cerrar el cliente del servicio web
                    if (clienteServicioWeb.State != System.ServiceModel.CommunicationState.Closed)
                    {
                        clienteServicioWeb.Close();
                    }
                }
            }

            if (e.CommandName == "Eliminar")

            {

                // Obtener el índice de la fila seleccionada
                int indiceFila = Convert.ToInt32(e.CommandArgument);

                // Obtener el valor de la clave primaria de la fila seleccionada (asumo que es "id" en este caso)
                int idProducto = Convert.ToInt32(gvProductos.DataKeys[indiceFila].Value);

                // Crear una instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();

                try
                {
                    // Llamar al método del servicio web para obtener los detalles del empleado
                    ServicioDentaCart.ProductoDB productoSeleccionado = clienteServicioWeb.ObtenerProductoPorId(idProducto);

                    // Asignar los valores a los TextBox del modal
                    if (productoSeleccionado != null)
                    {
                        txtIdM.Text = productoSeleccionado.id.ToString();
                        txtNombreM.Text = productoSeleccionado.nombre;
                        txtCanM.Text = productoSeleccionado.cant.ToString();
                        txtPrecioM.Text = productoSeleccionado.precio.ToString();
                    }
                    string script = "<script type=\"text/javascript\">mostrarModalBorrar('" +
                                     productoSeleccionado.id.ToString() +
                                     "','" + productoSeleccionado.nombre +
                                     "','" + productoSeleccionado.cant +
                                     "','" + productoSeleccionado.precio +
                              
                                     "');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "MostrarModalBorrar", script);
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante la llamada al servicio web
                    // Puedes registrar el error, mostrar un mensaje al usuario, etc.
                    Console.WriteLine($"Error al llamar al servicio web: {ex.Message}");
                }
                finally
                {
                    // Cerrar el cliente del servicio web
                    if (clienteServicioWeb.State != System.ServiceModel.CommunicationState.Closed)
                    {
                        clienteServicioWeb.Close();
                    }
                }
            }
        }

        protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        public void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtCant.Text = "";
            txtPrecio.Text = "";
            txtCodProv.Text = "";
            cmbProveedor.SelectedValue = "";

        }
        public void habilitar(bool a)
        {
            txtNombre.Enabled = a;
            txtCant.Enabled = a;
            txtPrecio.Enabled = a;

        }
        public bool validar()
        {
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCant.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text)||
               string.IsNullOrWhiteSpace(cmbProveedor.SelectedValue)
                )
            {
                ok = false;
            }

            return ok;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar(true);
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = false;
            cmbProveedor.Enabled = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                // Crear una instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();
                clienteServicioWeb.InsertarProducto(txtNombre.Text,Int32.Parse(txtCant.Text),float.Parse(txtPrecio.Text),Int32.Parse(cmbProveedor.SelectedValue)
                  );
                //string script = "<script type=\"text/javascript\">mostrarAlerta();</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlerta", script);

                // Inicio de sesión no exitoso, mostrar alerta
                ltlAlertaProductos.Text = "<div class='alert alert-success alert-dismissible fade show' role='alert'>Datos Guardados correctamente.<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
                cargarProductos();
                CargarProveedores();
                habilitar(false);
                limpiar();
                btnActualizar.Enabled = false;
                btnCancelar.Enabled = false;
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;
                cmbProveedor .Enabled = false;

            }
            else
            {
                //string script = "<script type=\"text/javascript\">mostrarAlertaError();</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlertaError", script);
                ltlAlertaProductos.Text = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>Error no se puede guardar los datos <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar(false);

            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = true;
            cmbProveedor.Enabled = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();
            clienteServicioWeb.ActualizarProducto(Int32.Parse(txtId.Text), txtNombre.Text, Int32.Parse(txtCant.Text), float.Parse(txtPrecio.Text), Int32.Parse(txtCodProv.Text));
            // string script = "<script type=\"text/javascript\">mostrarAlertaEditar();</script>";
            //ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlertaEditar", script);
            ltlAlertaProductos.Text = "<div class='alert alert-success alert-dismissible fade show' role='alert'>Datos Actualizados correctamente.<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
            cargarProductos();
            
            habilitar(false);
            limpiar();
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
            cmbProveedor.Enabled = false;
        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();
            clienteServicioWeb.EliminarProducto(Int32.Parse(txtIdM.Text));
            // string script = "<script type=\"text/javascript\">mostrarAlertaBorrado();</script>";
            // ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlertaBorrado", script);
            ltlAlertaProductos.Text = "<div class='alert alert-success alert-dismissible fade show' role='alert'>Datos Eliminados correctamente.<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
           
            cargarProductos();
        }

    }
}