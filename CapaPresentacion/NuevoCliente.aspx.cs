using CapaEntidades;
using CapaLogicaNegocios;
using CapaAccesoDatos;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Clientes : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Market"].ConnectionString.ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                GetProvincia();
                LlenarListas();                
            }
        }        

        protected void LlenarListas()
        {
            // Carga la lista de Tipo de Identificacion
            ddlTipoIdentificacion.Items.Clear();
            ddlTipoIdentificacion.Items.Add(new ListItem(" ", String.Empty));
            ddlTipoIdentificacion.Items.Add(new ListItem("Física", "F"));
            ddlTipoIdentificacion.Items.Add(new ListItem("Jurídica", "J"));

            // Carga la lista de los paises
            ddlPais.Items.Clear();
            ddlPais.Items.Add(new ListItem(" ", String.Empty));
            ddlPais.Items.Add(new ListItem("Costa Rica", "CR"));
        }

        #region OBTENER PROVINCIA DE LA BD
        protected void GetProvincia() //BindRegionCombo
        {
            SqlCommand cmd = new SqlCommand("select id, name from SC_ADMIN.Province", con);
            SqlDataReader dataReader = null;
            try
            {                
                // Carga la Lista de Provincia
                con.Open();
                dataReader = cmd.ExecuteReader();
                ddlProvincia.Items.Clear();                
                ddlProvincia.Items.Add(new ListItem(" ", String.Empty));
                while (dataReader.Read())
                {
                    ddlProvincia.Items.Add(new ListItem(Convert.ToString(dataReader[1]).Trim(), Convert.ToString(dataReader[0]).Trim()));
                }
                //this.ddlProvincia.SelectedIndex = this.ddlProvincia.Items.Count - 1;
            }
            catch (Exception ex)
            {
                AD_StoreProcedure.GetInstancia().MensajeScript(ex.Message.ToString(), "error", "flash");
                //ScriptManager.RegisterStartupScript(Page, GetType(), "Message", "alert('" + ex.Message.ToString() + "')", true);
            }
            finally
            {
                con.Close();
                dataReader.Dispose();
            }
        }
        #endregion

        #region OBTENER CANTON DE LA BD
        public string GetCanton()
        {
            string strCanton = String.Empty;
            SqlCommand sqlCom = new SqlCommand("select provinceID, id, name from SC_ADMIN.Canton ORDER BY provinceID, id", con);
            SqlDataReader sqlDr = null;
            try
            {
                con.Open();
                sqlDr = sqlCom.ExecuteReader();
                Int32 i = 0;
                while (sqlDr.Read())
                {
                    strCanton += "Canton[" + i + "] = new Array(" + Convert.ToString(sqlDr[0]).Trim() + ", '" + Convert.ToString(sqlDr[1]).Trim() + "', '" + Convert.ToString(sqlDr[2]).Trim() + "');\n";
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                AD_StoreProcedure.GetInstancia().MensajeScript(ex.Message.ToString(), "error", "flash");
                //Response.Write(ex.Message.ToString());
            }
            finally
            {
                con.Close();
                sqlDr.Dispose();
            }
            return strCanton;
        }
        #endregion

        #region OBTENER DISTRITO DE LA BD
        protected string GetDistrito()
        {
            string strDistrict = String.Empty;
            SqlCommand sqlCom = new SqlCommand("select cantonID, id, name from SC_ADMIN.District ORDER BY cantonID, id", con);
            SqlDataReader sqlDr = null;
            try
            {
                con.Open();
                sqlDr = sqlCom.ExecuteReader();
                Int32 i = 0;
                while (sqlDr.Read())
                {

                    strDistrict += "Distrito[" + i + "] = new Array(" + Convert.ToString(sqlDr[0]).Trim() + ", '" + Convert.ToString(sqlDr[1]).Trim() + "', '" + Convert.ToString(sqlDr[2]).Trim() + "');\n";
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                AD_StoreProcedure.GetInstancia().MensajeScript(ex.Message.ToString(), "error", "flash");
                //Response.Write(ex.Message.ToString());
            }
            finally
            {
                con.Close();
                sqlDr.Dispose();
            }
            return strDistrict;
        }
        #endregion

        protected void LlenarddlCanton()
        {
            SqlCommand cmd = new SqlCommand("select provinceID, id, name from SC_ADMIN.Canton ORDER BY provinceID, id", con);
            SqlDataReader dataReader = null;

            con.Open();
            dataReader = cmd.ExecuteReader();
            ddlCanton.Items.Clear();
            ddlCanton.Items.Add(new ListItem(" ", string.Empty));

            while (dataReader.Read())
            {
                ddlCanton.Items.Add(new ListItem(Convert.ToString(dataReader[2]).Trim(), Convert.ToString(dataReader[1]).Trim()));
            }

            con.Close();
            dataReader.Close();
        }

        protected void LlenarddlDistrito()
        {
            SqlCommand cmd = new SqlCommand("select cantonID, id, name from SC_ADMIN.District ORDER BY cantonID, id", con);
            SqlDataReader dataReader = null;

            con.Open();
            dataReader = cmd.ExecuteReader();
            ddlDistrito.Items.Clear();
            ddlDistrito.Items.Add(new ListItem(" ", String.Empty));

            while (dataReader.Read())
            {
                ddlDistrito.Items.Add(new ListItem(Convert.ToString(dataReader[2]).Trim(), Convert.ToString(dataReader[1]).Trim()));
            }
            con.Close();
        }

        private ECliente GetValores(char action)
        {
            ECliente objCliente = new ECliente();
            try
            {
                if (action == 'I')
                {
                    //int pro = Convert.ToInt32(ddlProvincia.SelectedItem.Value);
                    //int can = Convert.ToInt32(ddlCanton.SelectedItem.Value);
                    objCliente.action = action;
                    objCliente.typeDNI = Convert.ToChar(ddlTipoIdentificacion.SelectedValue);
                    objCliente.DNI = TxtIdentificacion.Text;
                    objCliente.name = TxtNombre.Text;
                    objCliente.districtID = Convert.ToInt32(ddlDistrito.SelectedValue);
                    objCliente.email = TxtEmail.Text;
                    objCliente.phone = Convert.ToInt32(TxtTelefono.Text);
                    objCliente.state = true;
                    objCliente.direction = TxtDireccion.Text;
                }                
            }
            catch (Exception Error)
            {
                AD_StoreProcedure.GetInstancia().MensajeScript("'Error al obtener los datos '" + Error.Message.ToString(), "error", "flash");
            }
            return objCliente;
        }

        protected void Clear()
        {
            ddlTipoIdentificacion.ClearSelection();
            ddlPais.ClearSelection();
            ddlProvincia.ClearSelection();
            TxtDireccion.Text = "";
            TxtIdentificacion.Text = "";
            TxtNombre.Text = "";
            TxtTelefono.Text = "";
            TxtEmail.Text = "";
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                // Obtiene datos de cliente
                ECliente objCliente = GetValores('I');

                // Enviar a la capa de LN para ejecutar el SP y envia un bool 
                bool respuesta = LNCliente.GetInstacia().RegistrarCliente(objCliente);

                if (respuesta)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Registro Guardado', 'success', 'bounceInDown');", true);
                    Clear();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert2('Complete los campos requeridos', 'error', 'zoomIn');", true);
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}