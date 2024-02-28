using ServicioDentaCart.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentaCartASP.Formularios
{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEmpleados();
                habilitar(false);
                btnActualizar.Enabled = false;
                btnCancelar.Enabled = false;
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;
            }

        }

        private void CargarEmpleados()
        {
            try
            {
                // Instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient servicio = new ServicioDentaCart.WebServiceDentaCartSoapClient();

                // Llamada al método del servicio web para obtener la lista de empleados
                List<ServicioDentaCart.EmpleadoDB> listaEmpleados = servicio.ListarEmpleado("").Cast<ServicioDentaCart.EmpleadoDB>().ToList();

                // Enlazar la lista de empleados al GridView
                gvEmpleados.DataSource = listaEmpleados;
                gvEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar el error (puedes mostrar un mensaje de error en la página)
                Console.WriteLine($"Error al obtener la lista de empleados: {ex.Message}");
            }
        }
        protected void gvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
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
                int idEmpleado = Convert.ToInt32(gvEmpleados.DataKeys[indiceFila].Value);

                // Crear una instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();

                try
                {
                    // Llamar al método del servicio web para obtener los detalles del empleado
                    ServicioDentaCart.EmpleadoDB empleadoSeleccionado = clienteServicioWeb.ObtenerEmpleadoPorId(idEmpleado);

                    // Asignar los valores a los TextBox del modal
                    if (empleadoSeleccionado != null)
                    {
                        txtId.Text = empleadoSeleccionado.id.ToString();
                        txtNombre.Text = empleadoSeleccionado.nombre;
                        txtDni.Text = empleadoSeleccionado.dni;
                        txtDir.Text = empleadoSeleccionado.dir;
                        txtCorreo.Text = empleadoSeleccionado.correo;
                        txtTelefono.Text = empleadoSeleccionado.telefono;
                        if (empleadoSeleccionado.tipo == "AD")
                        {
                            cmbTipo.SelectedValue = "AD";
                        }
                        else if (empleadoSeleccionado.tipo == "US")
                        {
                            cmbTipo.SelectedValue = "US";
                        }
                        else
                        {

                            cmbTipo.SelectedValue = "";
                        }

                        txtPass.Text = empleadoSeleccionado.pass;

                    }
                    Console.WriteLine($"Respuesta del servicio web: {empleadoSeleccionado}");
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
                int idEmpleado = Convert.ToInt32(gvEmpleados.DataKeys[indiceFila].Value);

                // Crear una instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();

                try
                {
                    // Llamar al método del servicio web para obtener los detalles del empleado
                    ServicioDentaCart.EmpleadoDB empleadoSeleccionado = clienteServicioWeb.ObtenerEmpleadoPorId(idEmpleado);

                    // Asignar los valores a los TextBox del modal
                    if (empleadoSeleccionado != null)
                    {
                        txtIdM.Text = empleadoSeleccionado.id.ToString();
                        txtNombreM.Text = empleadoSeleccionado.nombre;
                        txtDniM.Text = empleadoSeleccionado.dni;
                        txtDirM.Text = empleadoSeleccionado.dir;
                        txtCorreoM.Text = empleadoSeleccionado.correo;
                        txtTelfM.Text = empleadoSeleccionado.telefono;
                        txtTipoM.Text = empleadoSeleccionado.tipo;
                        txtPassM.Text = empleadoSeleccionado.pass;

                    }
                    string script = "<script type=\"text/javascript\">mostrarModalBorrar('" +
     empleadoSeleccionado.id.ToString() +
     "','" + empleadoSeleccionado.nombre +
     "','" + empleadoSeleccionado.dni +
     "','" + empleadoSeleccionado.dir +
     "','" + empleadoSeleccionado.correo +
     "','" + empleadoSeleccionado.telefono +
     "','" + empleadoSeleccionado.tipo +
     "','" + empleadoSeleccionado.pass +
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

        protected void gvEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gvEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvEmpleados_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar(false);
            cmbTipo.SelectedIndex = 0;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = true;
        }
        public void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDni.Text = "";
            txtDir.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtPass.Text = "";
            cmbTipo.SelectedValue = "";

        }
        public void habilitar(bool a)
        {
            txtNombre.Enabled = a;
            txtDni.Enabled = a;
            txtDir.Enabled = a;
            txtCorreo.Enabled = a;
            txtTelefono.Enabled = a;
            txtPass.Enabled = a;
            cmbTipo.Enabled = a;


        }
        public bool validar()
        {
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtDir.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtPass.Text) ||
                string.IsNullOrWhiteSpace(cmbTipo.SelectedValue))
            {
                ok = false;
            }

            return ok;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                // Crear una instancia del cliente del servicio web
                ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();
                clienteServicioWeb.GuardarEmpleado(txtNombre.Text, txtDni.Text, txtDir.Text, txtCorreo.Text,
                    txtTelefono.Text, cmbTipo.SelectedValue, txtPass.Text);
                string script = "<script type=\"text/javascript\">mostrarAlerta();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlerta", script);
                CargarEmpleados();
                habilitar(false);
                limpiar();
                btnActualizar.Enabled = false;
                btnCancelar.Enabled = false;
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = true;

            }
            else {
                string script = "<script type=\"text/javascript\">mostrarAlertaError();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlertaError", script);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();
            clienteServicioWeb.EditarEmpleado(Int32.Parse(txtId.Text), txtNombre.Text, txtDni.Text, txtDir.Text, txtCorreo.Text,
                txtTelefono.Text, cmbTipo.SelectedValue, txtPass.Text);
            string script = "<script type=\"text/javascript\">mostrarAlertaEditar();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlertaEditar", script);
            CargarEmpleados();
            habilitar(false);
            limpiar();
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ServicioDentaCart.WebServiceDentaCartSoapClient clienteServicioWeb = new ServicioDentaCart.WebServiceDentaCartSoapClient();
            clienteServicioWeb.BorrarEmpleado(Int32.Parse(txtIdM.Text));
            string script = "<script type=\"text/javascript\">mostrarAlertaBorrado();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "MostrarAlertaBorrado", script);
            CargarEmpleados();
        }
    }
}