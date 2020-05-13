using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaAccesoDatos;

namespace CapaLogicaNegocios
{
    public class LNUsers
    {
        #region SINGLETON
        private static LNUsers objLNUsers = null;
        private LNUsers() { }
        public static LNUsers GetInstacia()
        {
            if(objLNUsers == null)
            {
                objLNUsers = new LNUsers();
            }
            return objLNUsers;
        }
        #endregion

        public bool AccesoSistema(EUsers objUser)
        {
            try
            {
                return AD_Users.GetInstancia().AccesoSistema(objUser);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool RecuperaPassword(EUsers objUser)
        {
            try
            {
                return AD_Users.GetInstancia().RecuperaPassword(objUser);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
