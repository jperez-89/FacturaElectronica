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
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Market"].ConnectionString.ToString());
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
                // REVISAR EL SP
                cmd = new SqlCommand("SC_ADMIN.spIUDCliente", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@action", objCliente.action);
                cmd.Parameters.AddWithValue("@typeDNI", objCliente.typeDNI);
                cmd.Parameters.AddWithValue("@dni", objCliente.DNI);
                cmd.Parameters.AddWithValue("@name", objCliente.name);
                cmd.Parameters.AddWithValue("@districtid", objCliente.districtID);
                cmd.Parameters.AddWithValue("@email", objCliente.email);
                cmd.Parameters.AddWithValue("@phone", objCliente.phone);
                cmd.Parameters.AddWithValue("@state", objCliente.state);
                cmd.Parameters.AddWithValue("@direction", objCliente.direction);
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

        public int ListarCantClientes()
        {
            Int32 cantCli;
            try
            {
                cmd = new SqlCommand("SELECT COUNT(Id) FROM SC_ADMIN.Client", con);

                con.Open();
                cantCli = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //cant = 0;
                con.Close();
            }
            return cantCli;
        }

        public bool ActualizarCliente(ECliente objCliente)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDCliente", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@action", objCliente.action);
                cmd.Parameters.AddWithValue("@typeDNI", objCliente.typeDNI);
                cmd.Parameters.AddWithValue("@dni", objCliente.DNI);
                cmd.Parameters.AddWithValue("@name", objCliente.name);
                cmd.Parameters.AddWithValue("@districtid", objCliente.districtID);
                cmd.Parameters.AddWithValue("@email", objCliente.email);
                cmd.Parameters.AddWithValue("@phone", objCliente.phone);
                cmd.Parameters.AddWithValue("@state", objCliente.state);
                cmd.Parameters.AddWithValue("@Direction", objCliente.direction);
                con.Open();

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
                con.Close();
            }
            return respuesta;
        }

        public List<ECliente> MostarClientes()
        {
            List<ECliente> ListaClientes = new List<ECliente>();
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spListarClientes", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ECliente objCliente = new ECliente();

                    // OBTIENE LOS VALORES
                    objCliente.Id = Convert.ToInt32(dr["Id"].ToString());
                    objCliente.typeDNI = Convert.ToChar(dr["typeDNI"].ToString());
                    objCliente.DNI = dr["DNI"].ToString();
                    objCliente.name = dr["name"].ToString();
                    objCliente.phone = Convert.ToInt32(dr["phone"].ToString());
                    objCliente.email = dr["email"].ToString();
                    objCliente.state = Convert.ToBoolean(dr["state"].ToString());
                    objCliente.districtID = Convert.ToInt32(dr["districtID"].ToString());
                    objCliente.direction = dr["direction"].ToString();
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
                con.Close();
            }
            return ListaClientes;
        }

        public bool EliminarCliente(ECliente objCliente)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDCliente", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@action", objCliente.action);
                cmd.Parameters.AddWithValue("@typeDNI", objCliente.typeDNI);
                cmd.Parameters.AddWithValue("@dni", objCliente.DNI);
                cmd.Parameters.AddWithValue("@name", objCliente.name);
                cmd.Parameters.AddWithValue("@districtid", objCliente.districtID);
                cmd.Parameters.AddWithValue("@email", objCliente.email);
                cmd.Parameters.AddWithValue("@phone", objCliente.phone);
                cmd.Parameters.AddWithValue("@state", objCliente.state);
                cmd.Parameters.AddWithValue("@Direction", objCliente.direction);
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

        public bool ActivarCliente(ECliente objCliente)
        {
            try
            {
                cmd = new SqlCommand("SC_ADMIN.spIUDCliente", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@action", objCliente.action);
                cmd.Parameters.AddWithValue("@typeDNI", objCliente.typeDNI);
                cmd.Parameters.AddWithValue("@dni", objCliente.DNI);
                cmd.Parameters.AddWithValue("@name", objCliente.name);
                cmd.Parameters.AddWithValue("@districtid", objCliente.districtID);
                cmd.Parameters.AddWithValue("@email", objCliente.email);
                cmd.Parameters.AddWithValue("@phone", objCliente.phone);
                cmd.Parameters.AddWithValue("@state", objCliente.state);
                cmd.Parameters.AddWithValue("@Direction", objCliente.direction);
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
    }
}
