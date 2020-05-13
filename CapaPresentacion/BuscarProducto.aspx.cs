using CapaAccesoDatos;
using CapaEntidades;
using CapaLogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class BuscarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static bool respuesta = false;
        public static EProducto objProducto = new EProducto();

        public static EProducto GetProducto(char action, string ProductId, string Name, string Measure, string PriceC, string PriceD, bool State)
        {
            try
            {
                objProducto.action = action;
                objProducto.ProductId = ProductId;
                objProducto.name = Name;
                objProducto.measure = Measure;
                objProducto.unitPriceC = Convert.ToDecimal(PriceC.Replace(',', '.'));
                objProducto.unitPriceD = Convert.ToDecimal(PriceD.Replace(',', '.'));
                objProducto.state = State;
            }
            catch (Exception Error)
            {
                AD_StoreProcedure.GetInstancia().MensajeScript("'Error al obtener los datos '" + Error.Message.ToString(), "error", "flash");
            }
            return objProducto;
        }

        [WebMethod]
        public static List<EProducto> MostrarProductos()
        {
            List<EProducto> ListaProductos = null;
            try
            {
                ListaProductos = LNProducto.GetInstacia().MostarProductos();
            }
            catch (Exception Error)
            {
                ListaProductos = null;
                throw Error;
            }
            return ListaProductos;
        }

        [WebMethod]
        public static bool ActualizarProducto(string ProductId, string Name, string Measure, string PriceC, string PriceD)
        {
            objProducto = GetProducto('U', ProductId, Name, Measure, PriceC, PriceD, true);

            return respuesta = LNProducto.GetInstacia().ActualizarProducto(objProducto);
        }

        [WebMethod]
        public static bool EliminarProducto(string ProductId)
        {
            try
            {
                respuesta = LNProducto.GetInstacia().EliminarProducto(GetProducto('D', ProductId, "", "", "0", "0", false));
            }
            catch (Exception Error)
            {
                respuesta = false;
                throw Error;
            }
            return respuesta;
        }

        [WebMethod]
        public static bool ActivarProducto(string ProductId)
        {
            try
            {
                respuesta = LNProducto.GetInstacia().ActivarProducto(GetProducto('A', ProductId, "", "", "0", "0", true));
            }
            catch (Exception Error)
            {
                respuesta = false;
                throw Error;
            }
            return respuesta;
        }

        protected void BtnRegistrarProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoProducto.aspx");
        }

        [WebMethod]
        public static List<EImpuestos> ListarImpuestos()
        {
            List<EImpuestos> ListaImpuestos = null;
            try
            {
                ListaImpuestos = LNImpuestos.GetInstacia().ListarImpuestos();
            }
            catch (Exception Error)
            {
                ListaImpuestos = null;
                throw Error;
            }
            return ListaImpuestos;
        }
    }
}