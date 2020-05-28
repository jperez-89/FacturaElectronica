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
    public class MensajeSwalert2 : System.Web.UI.Page
    {
        #region SIMPLETON
        private static MensajeSwalert2 AD_Store = null;
        private MensajeSwalert2() { }

        public static MensajeSwalert2 GetInstancia() // crea metodo para retornar conexion en caso de que sea null
        {
            if (AD_Store == null)
            {
                AD_Store = new MensajeSwalert2();
            }
            return AD_Store;
        }
        #endregion

        public void MensajeSwalert(string Icono, string Titulo, string Mensaje) ///string mensaje
        {
            //return ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('registro guardado', 'success', 'zoomIn');", true);
            ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert2('" + Icono + "', '" + Titulo + "', '" + Mensaje + "');", true);

        }
    }
}
