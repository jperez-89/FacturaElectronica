using System;
using System.Globalization;
using System.Web.UI;
using CapaEntidades;
using CapaLogicaNegocios;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Facturacion : Page
    {
        public static EVenta objEncaVenta = new EVenta();
        public static EVentaDetalle ObjVentaDetalle = new EVentaDetalle();

        protected void Page_Load(object sender, EventArgs e)
        {
            //CultureInfo culture = new CultureInfo("es-ES");
            DateTime thisDay = DateTime.Now;
            TxtFecha.Text = thisDay.ToLocalTime().ToString(); //thisDay.ToString("d", new CultureInfo("es-ES"));

            if (!Page.IsPostBack)
            {
                
            }
        }

        public static EVenta GetValoresVenta(char Action, string FechaFact, string ClientDNI, int Plazo, string Moneda, string MedioPago, string EstadoHacienda, string Enviada, string Anulada, string Observaciones)
        {
            if (Action == 'I')
            {
                try
                {
                    // OBTIENE LA ULTIMA FACTURA REGISTRADA PARA AGREGAR LA NUEVA
                    int NFactura = LNVenta.GetInstacia().ObtenerNum_Factura();
                    // CREA EL OBJETO ENCABEZADO DE LA FACTURA
                    objEncaVenta = new EVenta
                    {
                        Action = Action,
                        UserID = Login.objUser.Id,
                        NumFact = NFactura + 1,
                        FechaFact = FechaFact,
                        ClientDNI = ClientDNI,
                        Plazo = Plazo,
                        Moneda = Moneda,
                        MedioPago = MedioPago,
                        EstadoHacienda = EstadoHacienda,
                        Enviada = Enviada,
                        Anulada = Anulada,
                        Observaciones = Observaciones
                    };
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

            }
            return objEncaVenta;
        }

        public static EVentaDetalle GetValoresVentaDetalle(char Action, int NFactura, List<EVentaDetalle> ObjDetaVenta)
        {
            ObjVentaDetalle = null;
            //var lista = ""; 

            if (Action == 'I')
            {
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


                //foreach (EVentaDetalle Linea in DetaVenta)
                //{
                //    objDetalleVenta = new EVentaDetalle
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
            }
            return ObjVentaDetalle;
        }

        [WebMethod]
        //public static bool GuardarDatosFactura(char Action, string FechaFact, string ClientDNI, int Plazo, string Moneda, string MedioPago, string EstadoHacienda, string Enviada, string Anulada, string Observaciones, List<EVentaDetalle> VentaDetalle)
        public static bool GuardarDatosFactura(EVenta ObjEncaVenta, List<EVentaDetalle> ObjDetaVenta)
        {
            EVenta VentaEnca = ObjEncaVenta;
            // REVISAR COMO LLEGAN LAS LISTAS

            // PREPARA EL ENCABEZADO DE LA FACTURA
            //objEncaVenta = GetValoresVenta(Action, FechaFact, ClientDNI, Plazo, Moneda, MedioPago, EstadoHacienda, Enviada, Anulada, Observaciones);

            // REGISTRA EL ENCABEZADO DE LA FACTURA
            //bool RespuestaRegistroEncaVenta = LNVenta.GetInstacia().RegistrarVenta(objEncaVenta);

            // OBTIENE EL NUMERO DE LA FACTURA GUARDADA EN EL ENCABEZADO
            int NFactura = LNVenta.GetInstacia().ObtenerNum_Factura();

            //ObjVentaDetalle = GetValoresVentaDetalle('I', NFactura, ObjDetaVenta);

            bool RespuestaGuardoFactura = false;
            if (true) // RespuestaRegistroEncaVenta
            {
                RespuestaGuardoFactura = true;
                //OBTIENE EL NUMERO DE FACTURA QUE GUARDO
                //var NFact = LNVenta.GetInstacia().ObtenerNum_Factura();

                //REGISTRA EL DETALLE DE LA FACTURA
                //bool RespuestaGuardoFactura = LNVenta.GetInstacia().RegistrarDetalleVenta(GetValoresDetalleVenta('I', NFact, DetaVenta));
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