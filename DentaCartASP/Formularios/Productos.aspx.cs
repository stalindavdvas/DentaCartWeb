using System;
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
            }
        }
    }
}