using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class LNImpuestos
    {
        #region SINGLETON
        private static LNImpuestos objLNImpuestos = null;
        private LNImpuestos() { }
        public static LNImpuestos GetInstacia()
        {
            if (objLNImpuestos == null)
            {
                objLNImpuestos = new LNImpuestos();
            }
            return objLNImpuestos;
        }
        #endregion

        public List<EImpuestos> ListarImpuestos()
        {
            try
            {
                return AD_Impuestos.GetInstacia().ListarImpuestos();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
