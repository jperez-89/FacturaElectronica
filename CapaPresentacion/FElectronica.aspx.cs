using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class FElectronica : Page
    {
        public static EVenta ListEncaVenta = new EVenta();
        public static EVentaDetalle ListDetaVenta = new EVentaDetalle();
        protected void Page_Load(object sender, EventArgs e)
        {         

        }

        private void GenerarEncabezado(List<EVenta> ObjEncaVenta)
        {
            NombreEmpresa.Text = "PATITO'S S.A";
            DireccionEmpresa.Text = "EN LA ESQUINA CONTRARIA A LA DERECHA";
            TelefonoEmpresa.Text = "+506 30512069";
            CorreoEmpresa.Text = "faelectro@patitos.com";
        }

        [WebMethod]
        public bool FacturaPDF(List<EVenta> ObjEncaVenta)
        {
            //GenerarEncabezado(ObjEncaVenta);


            NombreEmpresa.Text = "PATITO'S S.A";
            DireccionEmpresa.Text = "EN LA ESQUINA CONTRARIA A LA DERECHA";
            TelefonoEmpresa.Text = "+506 30512069";
            CorreoEmpresa.Text = "faelectro@patitos.com";

            NumFactura.Text = ObjEncaVenta[0].NumFact.ToString();
            FchFactura.Text = ObjEncaVenta[0].FechaFact.ToString();
            Moneda.Text = ObjEncaVenta[0].Moneda.ToString();
            NombreCliente.Text = ObjEncaVenta[0].ClientDNI.ToString();
            CedulaCliente.Text = ObjEncaVenta[0].ClientDNI.ToString();
            DireccionCliente.Text = "";
            TelefonoCliente.Text = "";
            CorreoCliente.InnerText = "";
            FechaVencimientoFact.InnerText = ObjEncaVenta[0].Plazo.ToString();
            OrdeCompra.InnerText = "";
            FormaPago.InnerText = ObjEncaVenta[0].MedioPago.ToString();


            // PREPARA EL ENCABEZADO DE LA FACTURA
            //ListEncaVenta = GetValoresVenta(ObjEncaVenta);



            // REGISTRA EL ENCABEZADO DE LA FACTURA
            //bool RespuestaRegistroEncaVenta = LNVenta.GetInstacia().RegistrarVenta(ListEncaVenta);

            //bool RespuestaGuardoFactura = false;
            //if (RespuestaRegistroEncaVenta)
            //{
            // OBTIENE EL NUMERO DE LA FACTURA GUARDADA EN EL ENCABEZADO
            //int NFactura = LNVenta.GetInstacia().ObtenerNum_Factura();

            // PREPARA EL DETALLE DE LA FACTURA
            //ListDetaVenta = GetValoresDetalleVenta('I', NFactura, ObjDetaVenta);

            //REGISTRA EL DETALLE DE LA FACTURA
            //RespuestaGuardoFactura = LNVenta.GetInstacia().RegistrarDetalleVenta(ObjDetaVenta);


            //RespuestaGuardoFactura = true;
            //OBTIENE EL NUMERO DE FACTURA QUE GUARDO
            //var NFact = LNVenta.GetInstacia().ObtenerNum_Factura();
            //}

            return true;
        }
    }
}