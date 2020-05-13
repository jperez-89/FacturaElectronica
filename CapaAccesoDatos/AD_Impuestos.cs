using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class AD_Impuestos
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Market"].ConnectionString.ToString());

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        //bool respuesta = false;

        #region SINGLETON
        private static AD_Impuestos objADImpuestos = null;
        private AD_Impuestos() { }
        public static AD_Impuestos GetInstacia()
        {
            if (objADImpuestos == null)
            {
                objADImpuestos = new AD_Impuestos();
            }
            return objADImpuestos;
        }
        #endregion

        public List<EImpuestos> ListarImpuestos()
        {
            List<EImpuestos> ListaImpuestos = new List<EImpuestos>();
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spListarImpuestos", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EImpuestos objImpuestos = new EImpuestos();

                    // OBTIENE LOS VALORES
                    objImpuestos.Id = Convert.ToInt32(dr["Id"].ToString());
                    objImpuestos.Name = dr["Nombre"].ToString();
                    objImpuestos.Porcentaje = Convert.ToInt32(dr["Porcentaje"].ToString());

                    //CARGA LA LISTA
                    ListaImpuestos.Add(objImpuestos);
                }
            }
            catch (Exception Error)
            {
                throw Error;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
            return ListaImpuestos;
        }
    }
}
