using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaAccesoDatos
{
    public class AD_StoreProcedure : System.Web.UI.Page
    {
        #region SIMPLETON
        private static AD_StoreProcedure AD_Store = null;
        private AD_StoreProcedure() { }

        public static AD_StoreProcedure GetInstancia() // crea metodo para retornar conexion en caso de que sea null
        {
            if (AD_Store == null)
            {
                AD_Store = new AD_StoreProcedure();
            }
            return AD_Store;
        }
        #endregion

        public void MensajeScript(string Titulo, string alerta, string Tipo) ///string mensaje
        {
            //return ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('registro guardado', 'success', 'zoomIn');", true);
            ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert2('" + Titulo + "', '" + alerta + "', '" + Tipo + "');", true);

        }
    }
}
