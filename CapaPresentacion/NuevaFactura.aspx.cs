using System;
using System.Globalization;
using System.Web.UI;
using CapaEntidades;
using CapaLogicaNegocios;
using System.Web.Services;
using System.Collections.Generic;

namespace CapaPresentacion
{
    public partial class Facturacion : Page
    {
        public static EVenta objEncaVenta = new EVenta();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //CultureInfo culture = new CultureInfo("es-ES");
            DateTime thisDay = DateTime.Now;
            TxtFecha.Text = thisDay.ToLocalTime().ToString(); //thisDay.ToString("d", new CultureInfo("es-ES"));

            if (!Page.IsPostBack)
            {
                
            }
        }

        public static EVenta GetValoresVenta(char Action, string FechaFact, string ClientDNI, int Plazo, string Moneda, string MedioPago, string EstadoHacienda, string Enviada, string Anulada)
        {
            if (Action == 'I')
            {
                try
                {
                    // VER SI SE PUEDE GENERAR ESTO
                    //EUsers users = new EUsers();
                    int NFactura = LNVenta.GetInstacia().ObtenerNum_Factura();
                    objEncaVenta = new EVenta
                    {
                        Action = Action,
                        UserID = 1,
                        NumFact = NFactura + 1,
                        FechaFact = Convert.ToDateTime(FechaFact),
                        ClientDNI = ClientDNI,
                        Plazo = Plazo,
                        Moneda = Moneda,
                        MedioPago = MedioPago,
                        EstadoHacienda = "Aceptado",
                        Enviada = "Si",
                        Anulada = "No"
                    };
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

            }
            return objEncaVenta;
        }

        private EVentaDetalle GetValoresDetalleVenta(char Action, int NFactura, List<EVentaDetalle> DetaVenta )
        {
            EVentaDetalle objDetalleVenta = null;
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
            return objDetalleVenta;
        }

        [WebMethod]
        public static bool GuardarDatosFactura(char Action, string FechaFact, string ClientDNI, int Plazo, string Moneda, string MedioPago, string EstadoHacienda, string Enviada, string Anulada)
        {
            // OBTIENE EL ULTIMO NUMERO DE FACTURA GUARDADA
            //int NFactura = LNVenta.GetInstacia().ObtenerNum_Factura();

            // OBTIENE EL ENCABEZADO DE LA FACTURA
            //var obj = Deserialize<EVenta>(EncaVenta);

            //foreach (EVenta venta in EncaVenta)
            //{
            //    objEncaVenta.Action = venta.Action;
            //    objEncaVenta.UserID = users.Id;
            //    objEncaVenta.NumFact = NFactura + 1;
            //    objEncaVenta.FechaFact = venta.FechaFact;
            //    objEncaVenta.ClientDNI = venta.ClientDNI;
            //    objEncaVenta.Plazo = venta.Plazo;
            //    objEncaVenta.Moneda = venta.Moneda;
            //    objEncaVenta.MedioPago = venta.MedioPago;
            //    objEncaVenta.EstadoHacienda = "Acepatdo";
            //    objEncaVenta.Enviada = "Si";
            //    objEncaVenta.Anulada = "No";
            //}

            objEncaVenta = GetValoresVenta(Action, FechaFact, ClientDNI, Plazo, Moneda, MedioPago, EstadoHacienda, Enviada, Anulada);

            bool RespuestaGuardoFactura = true;
            // REGISTRA EL ENCABEZADO DE LA FACTURA
            //bool RespuestaRegistroEncaVenta = LNVenta.GetInstacia().RegistrarVenta(objEncaVenta);

            //if (RespuestaRegistroEncaVenta)
            //{
            //  OBTIENE EL NUMERO DE FACTURA QUE GUARDO    
            //    //var NFact = LNVenta.GetInstacia().ObtenerNum_Factura();

            //  REGISTRA EL DETALLE DE LA FACTURA
            //    //bool RespuestaGuardoFactura = LNVenta.GetInstacia().RegistrarDetalleVenta(GetValoresDetalleVenta('I', NFact, DetaVenta));
            //}

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