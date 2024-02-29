using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentaCartASP.Formularios
{
    public partial class InicioCuenta : System.Web.UI.MasterPage
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
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Response.Cache.SetExpires(DateTime.MinValue);
                // Recuperar el valor almacenado en sesión
                string emailUsuario = (string)Session["EmailUsuario"];
                string tipoUsuario = (string)Session["TipoUsuario"];
                if (emailUsuario == null && tipoUsuario == null)
                {
                    Response.Redirect("IniciarSesion.aspx");
                }
                else
                {
                    if (emailUsuario != null && tipoUsuario == "AD")
                    {
                        lnEmpleados.Visible = true;
                    }
                    else
                    {
                        lnEmpleados.Visible = false;
                    }

                }
            }
            

        }

        protected void lnSalir_Click(object sender, EventArgs e)
        {
            // Limpiar todas las variables de sesión
            Session["TipoUsuario"] = null;
            Session["EmailUsuario"] = null;
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}