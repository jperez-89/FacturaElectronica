using System;
using System.Web.UI;
using CapaEntidades;
using CapaLogicaNegocios;
using System.Web.Services;
using System.Collections.Generic;
using System.IO;
using CapaAccesoDatos;

namespace CapaPresentacion
{
    public partial class Facturacion : Page
    {
        public static EVenta ListEncaVenta = new EVenta();
        public static EVentaDetalle ListDetaVenta = new EVentaDetalle();
        public static List<EVentaDetalle> ObjListDetaVenta = null;
        public static int NF;

        protected void Page_Load(object sender, EventArgs e)
        {
            //CultureInfo culture = new CultureInfo("es-ES");
            DateTime thisDay = DateTime.Now;
            TxtFecha.Text = thisDay.ToLocalTime().ToString(); //thisDay.ToString("d", new CultureInfo("es-ES"));
            //Numfactura.InnerText = Convert.ToString(AD_Venta.Factura);


            if (!Page.IsPostBack)
            {
                //Numfactura.InnerText = Nf.ToString();
            }
        }

        private static EVenta GetValoresVenta(List<EVenta> ObjEncaVenta)
        {
            if (ObjEncaVenta[0].Action == 'I')
            {
                try
                {
                    // OBTIENE LA ULTIMA FACTURA REGISTRADA PARA AGREGAR LA NUEVA
                    int NFactura = LNVenta.GetInstacia().ObtenerNum_Factura();
                    // CREA EL OBJETO ENCABEZADO DE LA FACTURA
                    ListEncaVenta = new EVenta
                    {
                        Action = ObjEncaVenta[0].Action,
                        UserID = Login.objUser.Id,
                        NumFact = NFactura + 1,
                        FechaFact = ObjEncaVenta[0].FechaFact,
                        ClientDNI = ObjEncaVenta[0].ClientDNI,
                        Plazo = ObjEncaVenta[0].Plazo,
                        Moneda = ObjEncaVenta[0].Moneda,
                        MedioPago = ObjEncaVenta[0].MedioPago,
                        EstadoHacienda = ObjEncaVenta[0].EstadoHacienda,
                        Enviada = ObjEncaVenta[0].Enviada,
                        Anulada = ObjEncaVenta[0].Enviada,
                        Observaciones = ObjEncaVenta[0].Observaciones
                    };
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

            }
            return ListEncaVenta;
        }

        [WebMethod]
        public static bool GuardarDatosFactura(List<EVenta> ObjEncaVenta, List<EVentaDetalle> ObjDetaVenta)
        {
            // PREPARA EL ENCABEZADO DE LA FACTURA
            ListEncaVenta = GetValoresVenta(ObjEncaVenta);

            // REGISTRA EL ENCABEZADO DE LA FACTURA
            bool RespuestaRegistroEncaVenta = LNVenta.GetInstacia().RegistrarVenta(ListEncaVenta);            

            bool RespuestaGuardoFactura = true;
            if (RespuestaRegistroEncaVenta)
            {
                //REGISTRA EL DETALLE DE LA FACTURA
                RespuestaGuardoFactura = LNVenta.GetInstacia().RegistrarDetalleVenta(ObjDetaVenta);

                //RespuestaGuardoFactura = true;
                //OBTIENE EL NUMERO DE FACTURA QUE GUARDO
                //var NFact = LNVenta.GetInstacia().ObtenerNum_Factura();
            }

            return RespuestaGuardoFactura;
        }

        [WebMethod]
        public static int obtenerNFactura()
        {
            return LNVenta.GetInstacia().ObtenerNum_Factura();
        }

        protected void BtnFacturar_Click(object sender, EventArgs e)
        {
            
        }
    }
}