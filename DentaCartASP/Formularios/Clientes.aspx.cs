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
        private void MostrarModalEditar(int index)
        {
            // Lógica para cargar datos en el modal de editar
            // Puedes usar GridViewClientes.Rows[index].Cells[indiceDeLaColumna].Text para obtener el valor de una celda específica
            // Luego, muestra el modal de editar
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModalEditar", "$('#modalEditar').modal('show');", true);
        }

        private void MostrarModalEliminar(int index)
        {
            // Lógica para cargar datos en el modal de eliminar
            // Puedes usar GridViewClientes.Rows[index].Cells[indiceDeLaColumna].Text para obtener el valor de una celda específica
            // Luego, muestra el modal de eliminar
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModalEliminar", "$('#modalEliminar').modal('show');", true);
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}