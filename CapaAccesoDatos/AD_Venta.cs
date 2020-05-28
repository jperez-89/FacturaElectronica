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
    public class AD_Venta
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Market"].ConnectionString.ToString());
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        private bool respuesta = false;
        private int Factura = 0;

        #region SINGLETON
        private static AD_Venta objADVenta = null;
        private AD_Venta() { }
        public static AD_Venta GetInstacia()
        {
            if (objADVenta == null)
            {
                objADVenta = new AD_Venta();
            }
            return objADVenta;
        }
        #endregion

        public bool RegistrarVenta(EVenta objEncaVenta)
        {
            try
            {
                cmd = new SqlCommand("SC_VENTAS.spInsertVenta", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Action", objEncaVenta.Action);
                cmd.Parameters.AddWithValue("@UserID", objEncaVenta.UserID);
                cmd.Parameters.AddWithValue("@NumFact", objEncaVenta.NumFact);
                cmd.Parameters.AddWithValue("@FechaFact", objEncaVenta.FechaFact);
                cmd.Parameters.AddWithValue("@ClientDNI", objEncaVenta.ClientDNI);
                cmd.Parameters.AddWithValue("@Plazo", objEncaVenta.Plazo);
                cmd.Parameters.AddWithValue("@Moneda", objEncaVenta.Moneda);
                cmd.Parameters.AddWithValue("@MedioPago", objEncaVenta.MedioPago);
                cmd.Parameters.AddWithValue("@EstadoHacienda", objEncaVenta.EstadoHacienda);
                cmd.Parameters.AddWithValue("@Enviada", objEncaVenta.Enviada);
                cmd.Parameters.AddWithValue("@Anulada", objEncaVenta.Anulada);
                cmd.Parameters.AddWithValue("@Observaciones", objEncaVenta.Observaciones);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) respuesta = true;
            }
            catch (Exception)
            {
                respuesta = false;
                throw;
            }
            finally
            {
                con.Close();
            }
            return respuesta;
        }

        public int ObtenerNum_Factura()
        {
            try
            {
                cmd = new SqlCommand("select top(1)NumFact from SC_VENTAS.Sales order by NumFact desc", con);
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Factura = dr.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                dr = null;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Factura;
        }

        public bool RegistrarDetalleVenta(List<EVentaDetalle> objDetalleVenta)
        {
            try
            {
                int N_factura = GetInstacia().ObtenerNum_Factura();
                for(int x = 0; x < objDetalleVenta.Count; x++)
                {
                    cmd = new SqlCommand("SC_VENTAS.spInsertDetalleVenta", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Id_Nfact", N_factura);
                    cmd.Parameters.AddWithValue("@LineaVenta", objDetalleVenta[x].LineaVenta);
                    cmd.Parameters.AddWithValue("@ProductID", objDetalleVenta[x].ProductID);
                    cmd.Parameters.AddWithValue("@Cantidad", objDetalleVenta[x].Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnit", objDetalleVenta[x].PrecioUnit);
                    cmd.Parameters.AddWithValue("@PorceDesc", objDetalleVenta[x].PorceDesc);
                    cmd.Parameters.AddWithValue("@MontDesc", objDetalleVenta[x].MontDesc);
                    cmd.Parameters.AddWithValue("@PorceIVA", objDetalleVenta[x].PorceIVA);
                    cmd.Parameters.AddWithValue("@MontIVA", objDetalleVenta[x].MontIVA);
                    con.Open();

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        respuesta = true;
                        con.Close();
                    }
                        
                }
            }
            catch (Exception)
            {
                respuesta = false;
                throw;
            }
            finally
            {
                con.Close();
            }
            return respuesta;
        }

    }
}
