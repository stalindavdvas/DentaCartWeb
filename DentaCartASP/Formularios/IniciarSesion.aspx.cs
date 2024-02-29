using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentaCartASP.Formularios
{
    public partial class IniciarSesion : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string emailUsuario = (string)Session["EmailUsuario"];
            string tipoUsuario = (string)Session["TipoUsuario"];
            if (!IsPostBack)
            {
                if (emailUsuario != null && tipoUsuario != null)
                {
                   // Response.Redirect("Cliente.aspx");
                    // Ejecutar el script de JavaScript para redirigir si el usuario está logueado
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "RedirectScript", "redirectToAnotherForm();", true);
                }
            }
            
            
        }
       

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            ServicioDentaCart.WebServiceDentaCartSoapClient clienteSoap= new ServicioDentaCart.WebServiceDentaCartSoapClient();

            ServicioDentaCart.EmpleadoDB usuario = clienteSoap.LoginUsuario(txtEmailUsu.Text, txtPassUsu.Text);

            if (usuario != null) {
                Session["TipoUsuario"] = usuario.tipo;
                Session["EmailUsuario"] = usuario.correo;
                if (usuario.tipo == "AD" || usuario.tipo == "US") {
                    Response.Redirect("Cliente.aspx");
                }
            }
            
        }
    }
}