using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentaCartASP.Formularios
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Si el usuario está autenticado, la página se cargará  // Recuperar el valor almacenado en sesión
                string emailUsuario = (string)Session["EmailUsuario"];
                string tipoUsuario = (string)Session["TipoUsuario"];
                if (emailUsuario == null && tipoUsuario == null)
                {
                    Response.Redirect("IniciarSesion.aspx");
                }
            }
        }
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