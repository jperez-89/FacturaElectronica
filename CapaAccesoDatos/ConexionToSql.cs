using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class ConexionToSql
    {
        //Patron singleton
        private static ConexionToSql conexion = null; // crea un atributo de tipo ConexionToSql        

        private ConexionToSql() { } // oculta el constructor
        public static ConexionToSql GetInstancia() // crea metodo para retornar conexion en caso de que sea null
        {
            if(conexion == null)
            {
                conexion = new ConexionToSql();
            }
            return conexion;
        }

        //acceder a los metodos de sql conexion
        public SqlConnection ConexionDB()
        {
            SqlConnection conexion = new SqlConnection
            {
                //ConnectionString = "Data Source=JPEREZ\\JPEREZ;Initial Catalog=FactElectronica;User ID=jperez;Password=pinky1989"
                ConnectionString = "Data Source=JPEREZ;Initial Catalog=Market;User ID=jperez;Password=Vsmora1989"
            };
            return conexion;
        }        
    }

    public abstract class ConnectionToSql
    {
        private readonly string StringConexion;

        public ConnectionToSql()
        {
            StringConexion = "Data Source=JPEREZ;Initial Catalog=Market;User ID=jperez;Password=Vsmora1989";
        }
        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(StringConexion);
        }
    }
}