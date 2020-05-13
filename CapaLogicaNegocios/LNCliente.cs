using CapaEntidades;
using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaLogicaNegocios
{
    public class LNCliente
    {
        #region SINGLETON
        private static LNCliente objLNCliente = null;
        private LNCliente() { }
        public static LNCliente GetInstacia()
        {
            if (objLNCliente == null)
            {
                objLNCliente = new LNCliente();
            }
            return objLNCliente;
        }
        #endregion

        public bool RegistrarCliente(ECliente objCliente)
        {
            try
            {
                return AD_Cliente.GetInstacia().RegistrarCliente(objCliente);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public List<ECliente> MostarClientes()
        {
            try
            {
                return AD_Cliente.GetInstacia().MostarClientes();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public int ListarCantClientes()
        {
            try
            {
                return AD_Cliente.GetInstacia().ListarCantClientes();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }       

        public bool EliminarCliente(ECliente objCliente)
        {
            try
            {
                return AD_Cliente.GetInstacia().EliminarCliente(objCliente);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public bool ActualizarCliente(ECliente objCliente)
        {
            try
            {
                return AD_Cliente.GetInstacia().ActualizarCliente(objCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActivarCliente(ECliente objCliente)
        {
            try
            {
                return AD_Cliente.GetInstacia().ActivarCliente(objCliente);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
