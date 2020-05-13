using System;
using System.Globalization;
using System.Web.UI;
using CapaEntidades;
using CapaLogicaNegocios;
using System.Data;
using System.Linq;

namespace CapaPresentacion
{
    public partial class Facturacion : Page
    {
        DataTable dtDetalle = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //CultureInfo culture = new CultureInfo("es-ES");
            DateTime thisDay = DateTime.Now;
            TxtFecha.Text = thisDay.ToString("d", new CultureInfo("es-ES"));
            dtDetalle = new DataTable("Tbl_CargaProductos");

            if (!Page.IsPostBack)
            {
                
            }
        }

        private EVenta GetValoresVenta(char Action)
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

        private EDetalleVenta GetValoresDetalleVenta(char Action, int NFactura )
        {
            EDetalleVenta objDetalleVenta = null;

            //DataTable table = new DataTable();
            


            if (Action == 'I')
            {
                objDetalleVenta = new EDetalleVenta
                {
                    Id_Nfact = NFactura,
                    LineaVenta = 1,
                    ProductID = "ab",
                    Cantidad = 1,
                    PrecioUnit = 100,
                    PorceDesc = 0,
                    MontDesc = 0,
                    PorceIVA = 13,
                    MontIVA = 13
                };
            }

            return objDetalleVenta;
        }

        public string ObtenerValores(DataTable dt)
        {
            string a = null;
            foreach (DataRow r in dt.Rows)
            {
                a = r[0].ToString();
                //string b = r[1].ToString();
                //Insertar("INSERT INTO  NOBRE_TABLA (NOMBRE_CAMPO_a , NOMBRE_CAMPO_b) VALUES (@par1,@par2)", a, b);                
            }
            return a;
        }

        protected void BtnFacturar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                try
                {
                    DataRowCollection rows = dtDetalle.Rows;
                    ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('"+ rows.Count + "', 'success', 'bounceInDown');", true);


                    //bool respuestaDetalleVenta = false;
                    //bool respuestaVenta = LNVenta.GetInstacia().RegistrarVenta(GetValoresVenta('I'));
                    
                    //if (respuestaVenta)
                    //{
                    //    int NFactura = LNVenta.GetInstacia().ObtenerNum_Factura();
                    //    respuestaDetalleVenta = LNVenta.GetInstacia().RegistrarDetalleVenta(GetValoresDetalleVenta('I', NFactura));
                    //}

                    //if (respuestaDetalleVenta)
                    //{
                    //    ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Registro Guardado', 'success', 'bounceInDown');", true);
                    //}

                    //string FechaFact = TxtFecha.Text;
                    //string IdCliente = TxtIdentificacion.Text;

                    //string Subtotal = TxtSubtotal.Text;
                    //string MontoDescuento = TxtMontoDescuento.Text;
                    //string ImpProd = TxtImpuesto.Text;

                    //string TotalFact = lblTotalFactura.Text;


                    //int DescProd = Convert.ToInt32(TxtDescuento.Text);
                    //int IvaProd = Convert.ToInt32(TxtIVA.Text);                
                    //int TotalProd = Convert.ToInt32(TxtTotalFactura.Text);

                    //ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('" + FechaFact + '-' + IdCliente + '-' + Subtotal + '-' + MontoDescuento + '-' + ImpProd + '-' + lblTotalFactura.Text + "', 'success', 'zoomIn');", true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert2('Complete los campos requeridos', 'error', 'zoomIn');", true);
            }
        }
    }
}