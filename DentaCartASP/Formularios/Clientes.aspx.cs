using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentaCartASP.Formularios
{
    public partial class Clientes1 : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
           
           // Si el usuario está autenticado, la página se cargará  // Recuperar el valor almacenado en sesión
            string emailUsuario = (string)Session["EmailUsuario"];
            string tipoUsuario = (string)Session["TipoUsuario"];
            if (emailUsuario == null && tipoUsuario == null)
            {
                Response.Redirect("IniciarSesion.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
               
                    CargarClientes();
                habilitar(false);
                btnActualizar.Enabled = false;
                btnCancelar.Enabled = false;
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;

            }
           

        }
        private void CargarClientes()
        {
            try
            {
                // Instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient servicio = new ServicioDentaCart.WebServiceDentaCartSoapClient();

                // Llamada al método del servicio web para obtener la lista de clientes
                List<ServicioDentaCart.ClienteDB> listaClientes = servicio.ListarCliente("").Cast<ServicioDentaCart.ClienteDB>().ToList();

                // Enlazar la lista de clientes al GridView (puedes usar otro control, como ListBox o DropDownList según tus necesidades)
                gvClientes.DataSource = listaClientes;
                gvClientes.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar el error (puedes mostrar un mensaje de error en la página)
                Console.WriteLine($"Error al obtener la lista de clientes: {ex.Message}");
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

                // Obtener el índice de la fila seleccionada
                int indiceFila = Convert.ToInt32(e.CommandArgument);

                // Obtener el valor de la clave primaria de la fila seleccionada (asumo que es "id" en este caso)
                int idCliente = Convert.ToInt32(gvClientes.DataKeys[indiceFila].Value);

                // Crear una instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();

                try
                {
                    // Llamar al método del servicio web para obtener los detalles del empleado
                    ServicioDentaCart.ClienteDB clienteSeleccionado = clienteServicioWeb.ObtenerClientePorId(idCliente);

                    // Asignar los valores a los TextBox del modal
                    if (clienteSeleccionado != null)
                    {
                        txtId.Text = clienteSeleccionado.id.ToString();
                        txtNombre.Text = clienteSeleccionado.nombre;
                        txtDni.Text = clienteSeleccionado.dni;
                        txtDir.Text = clienteSeleccionado.dir;
                        txtCorreo.Text = clienteSeleccionado.correo;
                        txtTelefono.Text = clienteSeleccionado.telefono;
                        

                    }
                    Console.WriteLine($"Respuesta del servicio web: {clienteSeleccionado}");
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
                int idCliente = Convert.ToInt32(gvClientes.DataKeys[indiceFila].Value);

                // Crear una instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();

                try
                {
                    // Llamar al método del servicio web para obtener los detalles del empleado
                    ServicioDentaCart.ClienteDB clienteSeleccionado = clienteServicioWeb.ObtenerClientePorId(idCliente);

                    // Asignar los valores a los TextBox del modal
                    if (clienteSeleccionado != null)
                    {
                        txtIdM.Text = clienteSeleccionado.id.ToString();
                        txtNombreM.Text = clienteSeleccionado.nombre;
                        txtDniM.Text = clienteSeleccionado.dni;
                        txtDirM.Text = clienteSeleccionado.dir;
                        txtCorreoM.Text = clienteSeleccionado.correo;
                        txtTelfM.Text = clienteSeleccionado.telefono;
                    }
                    string script = "<script type=\"text/javascript\">mostrarModalBorrar('" +
                                     clienteSeleccionado.id.ToString() +
                                     "','" + clienteSeleccionado.nombre +
                                     "','" + clienteSeleccionado.dni +
                                     "','" + clienteSeleccionado.dir +
                                     "','" + clienteSeleccionado.correo +
                                     "','" + clienteSeleccionado.telefono+
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
            txtDni.Text = "";
            txtDir.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
         
        }
        public void habilitar(bool a)
        {
            txtNombre.Enabled = a;
            txtDni.Enabled = a;
            txtDir.Enabled = a;
            txtCorreo.Enabled = a;
            txtTelefono.Enabled = a;
           

        }
        public bool validar()
        {
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtDir.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text)) 
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
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                // Crear una instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();
                clienteServicioWeb.InsertarCliente(txtNombre.Text, txtDni.Text, txtDir.Text, txtCorreo.Text,
                    txtTelefono.Text);
                //string script = "<script type=\"text/javascript\">mostrarAlerta();</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlerta", script);

                // Inicio de sesión no exitoso, mostrar alerta
                ltlAlertaClientes.Text = "<div class='alert alert-success alert-dismissible fade show' role='alert'>Datos Guardados correctamente.<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
                CargarClientes();
                habilitar(false);
                limpiar();
                btnActualizar.Enabled = false;
                btnCancelar.Enabled = false;
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;

            }
            else
            {
                //string script = "<script type=\"text/javascript\">mostrarAlertaError();</script>";
                //ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlertaError", script);
                ltlAlertaClientes.Text = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>Error no se puede guardar los datos <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";

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
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();
            clienteServicioWeb.ActualizarCliente(Int32.Parse(txtId.Text), txtNombre.Text, txtDni.Text, txtDir.Text, txtCorreo.Text,
                txtTelefono.Text);
            // string script = "<script type=\"text/javascript\">mostrarAlertaEditar();</script>";
            //ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlertaEditar", script);
            ltlAlertaClientes.Text = "<div class='alert alert-success alert-dismissible fade show' role='alert'>Datos Actualizados correctamente.<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";

            CargarClientes();
            habilitar(false);
            limpiar();
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();
            clienteServicioWeb.EliminarCliente(Int32.Parse(txtIdM.Text));
            // string script = "<script type=\"text/javascript\">mostrarAlertaBorrado();</script>";
            // ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlertaBorrado", script);
            ltlAlertaClientes.Text = "<div class='alert alert-success alert-dismissible fade show' role='alert'>Datos Eliminados correctamente.<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
            CargarClientes();
        }
    }
}