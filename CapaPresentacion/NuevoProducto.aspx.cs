using CapaAccesoDatos;
using CapaEntidades;
using CapaLogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarListas();
            }
        }

        protected void LlenarListas()
        {
            ddlTipoCodigo.Items.Clear();
            ddlTipoCodigo.Items.Add(new ListItem("", string.Empty));
            ddlTipoCodigo.Items.Add(new ListItem("Producto", "1"));
            ddlTipoCodigo.Items.Add(new ListItem("Servicio", "2"));

            ddlUnidadMedida.Items.Clear();
            ddlUnidadMedida.Items.Add(new ListItem("", string.Empty));
            ddlUnidadMedida.Items.Add(new ListItem("Unidad", "Unidad"));
            ddlUnidadMedida.Items.Add(new ListItem("Toneladas", "Tons"));

        }

        public void Clear()
        {
            TxtCodigoProducto.Text = "";
            TxtDescripcion.Text = "";
            TxtPrecioColon.Text = "";
            TxtPrecioDolar.Text = "";
            ddlTipoCodigo.ClearSelection();
            ddlUnidadMedida.ClearSelection();
        }

        private EProducto GetProducto(char action)
        {
            EProducto objProdcuto = new EProducto();
            try
            {
                if (action == 'I')
                {
                    objProdcuto.action = action;
                    objProdcuto.ProductId = TxtCodigoProducto.Text;
                    objProdcuto.name = TxtDescripcion.Text;
                    objProdcuto.measure = ddlUnidadMedida.SelectedValue;
                    objProdcuto.unitPriceC = Convert.ToDecimal(TxtPrecioColon.Text);
                    objProdcuto.unitPriceD = Convert.ToDecimal(TxtPrecioDolar.Text);
                    objProdcuto.CategoryID = Convert.ToInt32(ddlTipoCodigo.SelectedValue);
                    objProdcuto.state = true;
                }
            }
            catch (Exception Error)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Error al obtener los datos '" + Error.Message.ToString() + ", 'error', 'bounceInDown');", true);
                //AD_StoreProcedure.GetInstancia().MensajeScript("'Error al obtener los datos '" + Error.Message.ToString(), "error", "flash");
                //ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Error al obtener los datos '" + Error.Message.ToString() + ", 'error', 'flash');", true);
            }
            return objProdcuto;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                // Obtiene datos de cliente
                EProducto objProducto = GetProducto('I');

                // Enviar a la capa de LN para ejecutar el SP y envia un bool 
                bool respuesta = LNProducto.GetInstacia().RegistrarProducto(objProducto);

                if (respuesta)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Registro Guardado', 'success', 'bounceInDown');", true);
                    Clear();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert2('Complete Todos lo Campos', 'error', 'bounceInDown');", true);
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}