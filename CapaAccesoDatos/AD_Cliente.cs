using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaAccesoDatos
{
    public class AD_Cliente
    {
        private SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["Market"].ConnectionString.ToString());
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        bool respuesta = false;

        #region SINGLETON
        private static AD_Cliente objADCliente = null;
        private AD_Cliente() { }
        public static AD_Cliente GetInstacia()
        {
            if (objADCliente == null)
            {
                objADCliente = new AD_Cliente();
            }
            return objADCliente;
        }
        #endregion

        public bool RegistrarCliente(ECliente objCliente)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDCliente", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@action", objCliente.Action);
                cmd.Parameters.AddWithValue("@typeDNI", objCliente.TypeDNI);
                cmd.Parameters.AddWithValue("@dni", objCliente.DNI);
                cmd.Parameters.AddWithValue("@name", objCliente.Name);
                cmd.Parameters.AddWithValue("@districtid", objCliente.DistrictID);
                cmd.Parameters.AddWithValue("@email", objCliente.Email);
                cmd.Parameters.AddWithValue("@phone", objCliente.Phone);
                cmd.Parameters.AddWithValue("@state", objCliente.State);
                cmd.Parameters.AddWithValue("@direction", objCliente.Direction);
                Con.Open();

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
                Con.Close();
            }
            return respuesta;
        }

        public int ListarCantClientes()
        {
            Int32 cantCli;
            try
            {
                cmd = new SqlCommand("SELECT COUNT(Id) FROM SC_ADMIN.Client", Con);

                Con.Open();
                cantCli = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //cant = 0;
                Con.Close();
            }
            return cantCli;
        }

        public bool ActualizarCliente(ECliente objCliente)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDCliente", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@action", objCliente.Action);
                cmd.Parameters.AddWithValue("@typeDNI", objCliente.TypeDNI);
                cmd.Parameters.AddWithValue("@dni", objCliente.DNI);
                cmd.Parameters.AddWithValue("@name", objCliente.Name);
                cmd.Parameters.AddWithValue("@districtid", objCliente.DistrictID);
                cmd.Parameters.AddWithValue("@email", objCliente.Email);
                cmd.Parameters.AddWithValue("@phone", objCliente.Phone);
                cmd.Parameters.AddWithValue("@state", objCliente.State);
                cmd.Parameters.AddWithValue("@Direction", objCliente.Direction);
                Con.Open();

                int filas = cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (Exception ex)
            {
                respuesta = false;
                throw ex;
            }
            finally
            {
                Con.Close();
            }
            return respuesta;
        }

        public List<ECliente> MostarClientes()
        {
            List<ECliente> ListaClientes = new List<ECliente>();
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spListarClientes", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                Con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ECliente objCliente = new ECliente();

                    // OBTIENE LOS VALORES
                    objCliente.Id = Convert.ToInt32(dr["Id"].ToString());
                    objCliente.TypeDNI = Convert.ToChar(dr["typeDNI"].ToString());
                    objCliente.DNI = dr["DNI"].ToString();
                    objCliente.Name = dr["name"].ToString();
                    objCliente.Phone = Convert.ToInt32(dr["phone"].ToString());
                    objCliente.Email = dr["email"].ToString();
                    objCliente.State = Convert.ToBoolean(dr["state"].ToString());
                    objCliente.DistrictID = Convert.ToInt32(dr["districtID"].ToString());
                    objCliente.Direction = dr["direction"].ToString();
                    //CARGA LA LISTA
                    ListaClientes.Add(objCliente);
                }
            }
            catch (Exception Error)
            {
                objADCliente = null;
                throw Error;
            }
            finally
            {
                dr.Close();
                Con.Close();
            }
            return ListaClientes;
        }

        public bool EliminarCliente(ECliente objCliente)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDCliente", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@action", objCliente.Action);
                cmd.Parameters.AddWithValue("@typeDNI", objCliente.TypeDNI);
                cmd.Parameters.AddWithValue("@dni", objCliente.DNI);
                cmd.Parameters.AddWithValue("@name", objCliente.Name);
                cmd.Parameters.AddWithValue("@districtid", objCliente.DistrictID);
                cmd.Parameters.AddWithValue("@email", objCliente.Email);
                cmd.Parameters.AddWithValue("@phone", objCliente.Phone);
                cmd.Parameters.AddWithValue("@state", objCliente.State);
                cmd.Parameters.AddWithValue("@Direction", objCliente.Direction);
                Con.Open();

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
                Con.Close();
            }
            return respuesta;
        }

        public bool ActivarCliente(ECliente objCliente)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDCliente", Con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@action", objCliente.Action);
                cmd.Parameters.AddWithValue("@typeDNI", objCliente.TypeDNI);
                cmd.Parameters.AddWithValue("@dni", objCliente.DNI);
                cmd.Parameters.AddWithValue("@name", objCliente.Name);
                cmd.Parameters.AddWithValue("@districtid", objCliente.DistrictID);
                cmd.Parameters.AddWithValue("@email", objCliente.Email);
                cmd.Parameters.AddWithValue("@phone", objCliente.Phone);
                cmd.Parameters.AddWithValue("@state", objCliente.State);
                cmd.Parameters.AddWithValue("@Direction", objCliente.Direction);
                Con.Open();

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
                Con.Close();
            }
            return respuesta;
        }
    }
}
