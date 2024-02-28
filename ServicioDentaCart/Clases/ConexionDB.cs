using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace ServicioDentaCart.Clases
{
    public class ConexionDB
    {
        static string strConexion = WebConfigurationManager.ConnectionStrings["DentaCart"].ConnectionString;
        public SqlConnection Conexion = new SqlConnection(strConexion);
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(strConexion);
        }
    }
}