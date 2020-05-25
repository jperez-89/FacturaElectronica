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

        public bool RegistrarVenta(EVenta objVenta)
        {
            try
            {
                cmd = new SqlCommand("SC_VENTAS.spInsertVenta", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Action", objVenta.Action);
                cmd.Parameters.AddWithValue("@UserID", objVenta.UserID);
                cmd.Parameters.AddWithValue("@NumFact", objVenta.NumFact);
                cmd.Parameters.AddWithValue("@FechaFact", objVenta.FechaFact);
                cmd.Parameters.AddWithValue("@ClientDNI", objVenta.ClientDNI);
                cmd.Parameters.AddWithValue("@Plazo", objVenta.Plazo);
                cmd.Parameters.AddWithValue("@Moneda", objVenta.Moneda);
                cmd.Parameters.AddWithValue("@MedioPago", objVenta.MedioPago);
                cmd.Parameters.AddWithValue("@EstadoHacienda", objVenta.EstadoHacienda);
                cmd.Parameters.AddWithValue("@Enviada", objVenta.Enviada);
                cmd.Parameters.AddWithValue("@Anulada", objVenta.Anulada);
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

        public bool RegistrarDetalleVenta(EVentaDetalle objDetalleVenta)
        {
            try
            {
                cmd = new SqlCommand("SC_VENTAS.spInsertDetalleVenta", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id_Nfact", objDetalleVenta.Id_Nfact);
                cmd.Parameters.AddWithValue("@LineaVenta", objDetalleVenta.LineaVenta);
                cmd.Parameters.AddWithValue("@ProductID", objDetalleVenta.ProductID);
                cmd.Parameters.AddWithValue("@Cantidad", objDetalleVenta.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnit", objDetalleVenta.PrecioUnit);
                cmd.Parameters.AddWithValue("@PorceDesc", objDetalleVenta.PorceDesc);
                cmd.Parameters.AddWithValue("@MontDesc", objDetalleVenta.MontDesc);
                cmd.Parameters.AddWithValue("@PorceIVA", objDetalleVenta.PorceIVA);
                cmd.Parameters.AddWithValue("@MontIVA", objDetalleVenta.MontIVA);
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

    }
}
