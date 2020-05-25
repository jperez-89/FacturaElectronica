using CapaAccesoDatos;
using CapaEntidades;
using CapaLogicaNegocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class BuscarCliente : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Market"].ConnectionString.ToString());
        public static ECliente objCliente = new ECliente();
        public static bool respuesta = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetProvincia();
                //LlenarddlCanton();
                //LlenarddlDistrito();
            }
        }

        // ELIMINAR CLIENTE
        public static ECliente GetCliente(char action, string TypeDNI, string DNI, string Name, string District, string Email, string Phone, string Direction, bool State)
        {
            //if (action == 'U')
            //{
                objCliente.action = action;
                objCliente.typeDNI = Convert.ToChar(TypeDNI);
                objCliente.DNI = DNI;
                objCliente.name = Name;
                objCliente.districtID = Convert.ToInt32(District);
                objCliente.email = Email;
                objCliente.phone = Convert.ToInt32(Phone);
                objCliente.direction = Direction;
                objCliente.state = State;
            //}
            //else if (action == 'D')
            //{
                //objCliente.action = action;
                //objCliente.DNI = DNI;
                //objCliente.state = State;
            //}
            return objCliente;
        }

        protected void BtnRegistrarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoCliente.aspx");
        }

        [WebMethod]
        public static List<ECliente> MostrarClientes()
        {
            List<ECliente> ListaClientes = null;
            try
            {
                ListaClientes = LNCliente.GetInstacia().MostarClientes();
            }
            catch (Exception Error)
            {
                ListaClientes = null;
                throw Error;
            }
            return ListaClientes;
        }

        [WebMethod]
        public static bool ActualizarCliente(string TypeDNI, string DNI, string Name, string Phone, string Email, string District, string Direction)
        {
            objCliente = GetCliente('U', TypeDNI, DNI, Name, District, Email, Phone, Direction, true);

            return respuesta = LNCliente.GetInstacia().ActualizarCliente(objCliente);
        }

        protected void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            //Response.Redirect("EditarCliente.aspx");
        }

        [WebMethod]
        public static bool EliminarCliente(string DNI)
        {
            objCliente = GetCliente('D',"a",DNI, "a","1","a","1","a",false);

            return respuesta = LNCliente.GetInstacia().EliminarCliente(objCliente);
        }
        [WebMethod]
        public static bool ActivarCliente(string DNI)
        {
            objCliente = GetCliente('A', "a", DNI, "a", "1", "a", "1", "a", true);

            return respuesta = LNCliente.GetInstacia().ActivarCliente(objCliente);
        }

        #region OBTENER PROVINCIA DE LA BD
        protected void GetProvincia() //BindRegionCombo
        {
            SqlCommand cmd = new SqlCommand("select id, name from SC_ADMIN.Province", con);
            SqlDataReader dataReader = null;
            try
            {
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
                MensajeSwalert2.GetInstancia().MensajeSwalert(ex.Message.ToString(), "error", "flash");
                //ScriptManager.RegisterStartupScript(Page, GetType(), "Message", "alert('" + ex.Message.ToString() + "')", true);
            }
            finally
            {
                con.Close();
                dataReader.Dispose();
            }
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
                MensajeSwalert2.GetInstancia().MensajeSwalert(ex.Message.ToString(), "error", "flash");
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

        #region OBTENER CANTON DE LA BD
        protected string GetCanton()
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
                MensajeSwalert2.GetInstancia().MensajeSwalert(ex.Message.ToString(), "error", "flash");
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
    }

}