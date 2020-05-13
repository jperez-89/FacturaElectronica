using CapaAccesoDatos;
using CapaEntidades;
using CapaLogicaNegocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Inicio1 : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Market"].ConnectionString.ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //GetCantClientes();
            }
        }

        [WebMethod]
        public static Int32 ListarCantClientes() //List<ECliente>
        {
            Int32 CantidadClientes;
            try
            {
                CantidadClientes = LNCliente.GetInstacia().ListarCantClientes();
            }
            catch (Exception Error)
            {
                throw Error;
            }
            return CantidadClientes;
        }

        [WebMethod]
        public static Int32 ListarCantProductos() 
        {
            Int32 CantProduct;
            try
            {
                CantProduct = LNProducto.GetInstacia().ListarCantProductos();
            }
            catch (Exception Error)
            {
                throw Error;
            }
            return CantProduct;
        }


    }
}