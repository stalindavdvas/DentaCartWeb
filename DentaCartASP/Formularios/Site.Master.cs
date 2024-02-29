using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentaCartASP
{
    public partial class SiteMaster : MasterPage
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
       
    }
}