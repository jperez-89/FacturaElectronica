using System;
using System.Configuration;
using System.Data.SqlClient;
using CapaEntidades;
using System.Data;
using System.Collections.Generic;

namespace CapaAccesoDatos
{
    public class AD_Producto
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Market"].ConnectionString.ToString());

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        bool respuesta = false;

        #region SINGLETON
        private static AD_Producto objADCliente = null;
        private AD_Producto() { }
        public static AD_Producto GetInstacia()
        {
            if (objADCliente == null)
            {
                objADCliente = new AD_Producto();
            }
            return objADCliente;
        }
        #endregion

        public bool RegistrarProducto(EProducto objProducto)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDProductos", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Action", objProducto.action);
                cmd.Parameters.AddWithValue("@ProductId", objProducto.ProductId);
                cmd.Parameters.AddWithValue("@Name", objProducto.name);
                cmd.Parameters.AddWithValue("@Measure", objProducto.measure);
                cmd.Parameters.AddWithValue("@PriceC", objProducto.unitPriceC);
                cmd.Parameters.AddWithValue("@PriceD", objProducto.unitPriceD);
                cmd.Parameters.AddWithValue("@CategoryId", objProducto.CategoryID);
                cmd.Parameters.AddWithValue("@State", objProducto.state);
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

        public List<EProducto> MostarProductos()
        {
            List<EProducto> ListaProductos = new List<EProducto>();
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spListarProductos", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EProducto objProductos = new EProducto();

                    // OBTIENE LOS VALORES
                    objProductos.Id = Convert.ToInt32(dr["Id"].ToString());
                    objProductos.ProductId = dr["ProductId"].ToString();
                    objProductos.name = dr["name"].ToString();
                    objProductos.measure = dr["measure"].ToString();
                    objProductos.unitPriceC = Convert.ToDecimal(dr["unitPriceC"].ToString());
                    objProductos.unitPriceD = Convert.ToDecimal(dr["unitPriceD"].ToString());
                    objProductos.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                    objProductos.state = Convert.ToBoolean(dr["state"].ToString());

                    //CARGA LA LISTA
                    ListaProductos.Add(objProductos);
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
            return ListaProductos;
        }

        public bool ActualizarProducto(EProducto objProducto)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDProductos", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Action", objProducto.action);
                cmd.Parameters.AddWithValue("@ProductId", objProducto.ProductId);
                cmd.Parameters.AddWithValue("@Name", objProducto.name);
                cmd.Parameters.AddWithValue("@Measure", objProducto.measure);
                cmd.Parameters.AddWithValue("@PriceC", objProducto.unitPriceC);
                cmd.Parameters.AddWithValue("@PriceD", objProducto.unitPriceD);
                cmd.Parameters.AddWithValue("@CategoryId", objProducto.CategoryID);
                cmd.Parameters.AddWithValue("@State", objProducto.state);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) respuesta = true;
            }
            catch (Exception error)
            {
                respuesta = false;
                throw error;
            }
            finally
            {
                con.Close();
            }
            return respuesta;
        }

        public bool EliminarProducto(EProducto objProducto)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDProductos", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Action", objProducto.action);
                cmd.Parameters.AddWithValue("@ProductId", objProducto.ProductId);
                cmd.Parameters.AddWithValue("@Name", "");
                cmd.Parameters.AddWithValue("@Measure", "");
                cmd.Parameters.AddWithValue("@PriceC", 0);
                cmd.Parameters.AddWithValue("@PriceD", 0);
                cmd.Parameters.AddWithValue("@CategoryId", 0);
                cmd.Parameters.AddWithValue("@State", objProducto.state);
                con.Open();

                cmd.ExecuteNonQuery();
                respuesta = true;
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

        public bool ActivarProducto(EProducto objProducto)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDProductos", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Action", objProducto.action);
                cmd.Parameters.AddWithValue("@ProductId", objProducto.ProductId);
                cmd.Parameters.AddWithValue("@Name", "");
                cmd.Parameters.AddWithValue("@Measure", "");
                cmd.Parameters.AddWithValue("@PriceC", 0);
                cmd.Parameters.AddWithValue("@PriceD", 0);
                cmd.Parameters.AddWithValue("@CategoryId", 0);
                cmd.Parameters.AddWithValue("@State", objProducto.state);
                con.Open();

                cmd.ExecuteNonQuery();
                respuesta = true;
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

        public int ListarCantProductos()
        {
            Int32 cantPro;
            try
            {
                cmd = new SqlCommand("SELECT COUNT(Id) FROM SC_ADMIN.Products", con);

                con.Open();
                cantPro = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return cantPro;
        }
    }
}
