using System;
using System.Globalization;
using System.Web.UI;
using CapaEntidades;
using CapaLogicaNegocios;
using System.Data;
using System.Web.Services;
using System.Collections.Generic;

namespace CapaPresentacion
{
    public partial class Facturacion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CultureInfo culture = new CultureInfo("es-ES");
            DateTime thisDay = DateTime.Now;
            TxtFecha.Text = thisDay.ToString("d", new CultureInfo("es-ES"));

            if (!Page.IsPostBack)
            {
                
            }
        }

        public EVenta GetValoresVenta(char Action)
        {
            EVenta objVenta = null;
            int dias = 0;

            if (Action == 'I')
            {
                if(DiasCredito.Text != "")
                {
                    dias = Convert.ToInt32(DiasCredito.Text);
                }
                try
                {
                    EUsers users = new EUsers();
                    int NFactura = LNVenta.GetInstacia().ObtenerNum_Factura();
                    objVenta = new EVenta
                    {
                        Action = 'I',
                        UserID = users.Id,
                        NumFact = NFactura + 1,
                        FechaFact = Convert.ToDateTime(TxtFecha.Text),
                        ClientDNI = TxtIdentificacion.Text,
                        Plazo = dias,
                        Moneda = ddlMoneda.SelectedValue.ToString(),
                        MedioPago = ddlMedioPago.SelectedValue.ToString(),
                        EstadoHacienda = "Aceptado",
                        Enviada = "Si",
                        Anulada = "No"
                    };
                }catch(Exception ex)
                {
                    ex.Message.ToString();
                }
                
            }
            return objVenta;
        }

        private EDetalleVenta GetValoresDetalleVenta(char Action, int NFactura, List<EDetalleVenta> DetaVenta )
        {
            EDetalleVenta objDetalleVenta = null;
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


                //foreach (EDetalleVenta Linea in DetaVenta)
                //{
                //    objDetalleVenta = new EDetalleVenta
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
        public static bool GuardarDatosFactura()
        {
            //Array a = DetaVenta;
            bool respuestaVenta = LNVenta.GetInstacia().RegistrarVenta(GetValoresVenta('I'));
            //if (respuestaVenta)
            //{
            //    var NFact = LNVenta.GetInstacia().ObtenerNum_Factura();
            //    bool respuesta = LNVenta.GetInstacia().RegistrarDetalleVenta(GetValoresDetalleVenta('I', NFact, DetaVenta));

            //}
            return true;
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