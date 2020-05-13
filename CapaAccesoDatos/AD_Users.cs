using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class AD_Users:ConnectionToSql
    {
        private static AD_Users ADCliente = null;
        private AD_Users() { }
        public static AD_Users GetInstancia()
        {
            if (ADCliente == null)
            {
                ADCliente = new AD_Users();
            }
            return ADCliente;
        }

        private SqlConnection conexion = null;
        private SqlDataReader DataReader = null;
        private bool respuesta = false;

        public bool AccesoSistema(EUsers objUser)
        {
            try
            {
                conexion = ConexionToSql.GetInstancia().ConexionDB();
                SqlCommand cmd = new SqlCommand("select Id, Name, DNI, Email from SC_ADMIN.Users", conexion)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@dni", objUser.DNI);
                cmd.Parameters.AddWithValue("@email", objUser.Email);

                conexion.Open();
                DataReader = cmd.ExecuteReader();

                while (DataReader.Read())
                {
                    if (DataReader["DNI"].ToString() == objUser.DNI && DataReader["Email"].ToString() == objUser.Email)
                    {
                        respuesta = true;
                        objUser.Name = DataReader["Name"].ToString();
                        objUser.Id = Convert.ToInt32(DataReader["Id"]);
                    }
                }
            }
            catch (Exception error)
            {
                respuesta = false;
                objUser = null;
                throw error;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }

        public bool RecuperaPassword(EUsers users)
        {
            try
            {
                //conexion = ObtenerConexion();                
                SqlCommand cmd = new SqlCommand("select DNI, Name, Email, Password from SC_ADMIN.Users where DNI=@dni", conexion = ObtenerConexion())
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@dni", users.DNI);

                conexion.Open();
                DataReader = cmd.ExecuteReader();

                if(DataReader.Read() == true)
                {
                    if(DataReader["DNI"].ToString() == users.DNI)
                    {
                        users.Email = DataReader["email"].ToString();
                        users.Password = DataReader["Password"].ToString();
                        users.DNI = DataReader["DNI"].ToString();
                        users.Name = DataReader["Name"].ToString();

                        //Agregar todos los correos a la lista
                        //List<string> ListaCorreos = new List<string>();
                        //foreach (string Correo in Destinatarios)
                        //{
                        //    ListaCorreos.Add(Correo);
                        //}

                        var MailService = new SendMail.SistemaSoporteEmail();
                        MailService.EnviarCorreo(
                                        Asunto:"SYSTEM: Recuperación de Contraseña",
                                        Mesaje:"Hola " + users.Name + " has solicitado la recuperación de tu contraseña.\n Tu contraseña es: " + users.Password,
                                        Destinatarios: new List<string> { users.Email});
                        respuesta = true;
                    }
                }
            }
            catch (Exception error)
            {
                respuesta = false;
                users = null;
                throw error;
            }
            finally
            {
                conexion.Close();
            }
            return respuesta;
        }
    }
}
