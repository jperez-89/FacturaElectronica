using System;
using System.Globalization;
using System.Web.UI;
using CapaEntidades;
using CapaLogicaNegocios;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;
using System.Collections;

namespace CapaPresentacion
{
    public partial class Facturacion : Page
    {
        public static EVenta ListEncaVenta = new EVenta();
        public static EVentaDetalle ListDetaVenta = new EVentaDetalle();
        public static List<EVentaDetalle> ObjListDetaVenta = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //CultureInfo culture = new CultureInfo("es-ES");
            DateTime thisDay = DateTime.Now;
            TxtFecha.Text = thisDay.ToLocalTime().ToString(); //thisDay.ToString("d", new CultureInfo("es-ES"));

            if (!Page.IsPostBack)
            {
                
            }
        }

        public static EVenta GetValoresVenta(List<EVenta> ObjEncaVenta)
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

        //private static EVentaDetalle GetValoresDetalleVenta(char Action, int NFactura, List<EVentaDetalle> ObjDetaVenta)
        //{
            

        //    if (Action == 'I')
        //    {
                //for (var i = 0; i < DetaVenta.Count; i++)
                //{
                //    var o = 0;
                //    lista += 
                //            DetaVenta[0] + DetaVenta[1] + DetaVenta[2] +
                //            DetaVenta[3] +
                //            DetaVenta[4] +
                //            DetaVenta[5] +
                //            DetaVenta[6] +
                //            DetaVenta[7]
                //}
                

                //for (int i = 0; i < ObjDetaVenta.Count; i++)
                //{
                //    ListDetaVenta = new EVentaDetalle
                //    {
                //        Id_Nfact = NFactura,
                //        LineaVenta = ObjDetaVenta[i].LineaVenta,
                //        ProductID = ObjDetaVenta[i].ProductID,
                //        Cantidad = ObjDetaVenta[i].Cantidad,
                //        PrecioUnit = ObjDetaVenta[i].PrecioUnit,
                //        PorceDesc = ObjDetaVenta[i].PorceDesc,
                //        MontDesc = ObjDetaVenta[i].MontDesc,
                //        PorceIVA = ObjDetaVenta[i].PorceIVA,
                //        MontIVA = ObjDetaVenta[i].MontIVA
                //    };
                //    ObjListDetaVenta.Add(ListDetaVenta);
                //}


                //foreach (EVentaDetalle Linea in ObjDetaVenta)
                //{
                //    ListDetaVenta = new EVentaDetalle
                //    {
                //        Id_Nfact = NFactura,
                //        LineaVenta = Linea.LineaVenta,
                //        ProductID = Linea.ProductID,
                //        Cantidad = Linea.Cantidad,
                //        PrecioUnit = Linea.PrecioUnit,
                //        PorceDesc = Linea.PorceDesc,
                //        MontDesc = Linea.MontDesc,
                //        PorceIVA = Linea.PorceIVA,
                //        MontIVA = Linea.MontIVA
                //    };
                //}
        //    }
        //    return ObjListDetaVenta;
        //}

        [WebMethod]
        public static bool GuardarDatosFactura(List<EVenta> ObjEncaVenta, List<EVentaDetalle> ObjDetaVenta)
        {
            //EVenta VentaEnca = ObjEncaVenta;


            // PREPARA EL ENCABEZADO DE LA FACTURA
            ListEncaVenta = GetValoresVenta(ObjEncaVenta);

            // REGISTRA EL ENCABEZADO DE LA FACTURA
            bool RespuestaRegistroEncaVenta = LNVenta.GetInstacia().RegistrarVenta(ListEncaVenta);

            bool RespuestaGuardoFactura = false;
            if (RespuestaRegistroEncaVenta)
            {
                // OBTIENE EL NUMERO DE LA FACTURA GUARDADA EN EL ENCABEZADO
                //int NFactura = LNVenta.GetInstacia().ObtenerNum_Factura();

                // PREPARA EL DETALLE DE LA FACTURA
                //ListDetaVenta = GetValoresDetalleVenta('I', NFactura, ObjDetaVenta);

                //REGISTRA EL DETALLE DE LA FACTURA
                RespuestaGuardoFactura = LNVenta.GetInstacia().RegistrarDetalleVenta(ObjDetaVenta);


                //RespuestaGuardoFactura = true;
                //OBTIENE EL NUMERO DE FACTURA QUE GUARDO
                //var NFact = LNVenta.GetInstacia().ObtenerNum_Factura();
            }

            return RespuestaGuardoFactura;
        }        

        protected void BtnFacturar_Click(object sender, EventArgs e)
        {
            //Page.Validate();
            //if (Page.IsValid)
            //{
            //    try
            //    {
            //        bool respuestaDetalleVenta = false;
            //        bool respuestaVenta = LNVenta.GetInstacia().RegistrarVenta(GetValoresVenta('I'));

            //        if (respuestaVenta)
            //        {
            //            int NFactura = LNVenta.GetInstacia().ObtenerNum_Factura();
            //            respuestaDetalleVenta = LNVenta.GetInstacia().RegistrarDetalleVenta(GetValoresDetalleVenta('I', NFactura));
            //        }

            //        if (respuestaDetalleVenta)
            //        {
            //            ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Registro Guardado', 'success', 'bounceInDown');", true);
            //        }

            //        string FechaFact = TxtFecha.Text;
            //        string IdCliente = TxtIdentificacion.Text;

            //        string Subtotal = TxtSubtotal.Text;
            //        string MontoDescuento = TxtMontoDescuento.Text;
            //        string ImpProd = TxtImpuesto.Text;

            //        string TotalFact = lblTotalFactura.Text;


            //        int DescProd = Convert.ToInt32(TxtDescuento.Text);
            //        int IvaProd = Convert.ToInt32(TxtIVA.Text);
            //        int TotalProd = Convert.ToInt32(TxtTotalFactura.Text);

            //        ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('" + FechaFact + '-' + IdCliente + '-' + Subtotal + '-' + MontoDescuento + '-' + ImpProd + '-' + lblTotalFactura.Text + "', 'success', 'zoomIn');", true);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
            //else
            //{
            //    ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert2('Complete los campos requeridos', 'error', 'zoomIn');", true);
            //}
        }
    }
}