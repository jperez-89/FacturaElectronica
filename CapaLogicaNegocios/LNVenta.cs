using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class LNVenta
    {
        #region SINGLETON
        private static LNVenta objLNCliente = null;
        private LNVenta() { }
        public static LNVenta GetInstacia()
        {
            if (objLNCliente == null)
            {
                objLNCliente = new LNVenta();
            }
            return objLNCliente;
        }
        #endregion

        public bool RegistrarVenta(EVenta objVenta)
        {
            try
            {
                return AD_Venta.GetInstacia().RegistrarVenta(objVenta);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public bool RegistrarDetalleVenta(List<EVentaDetalle> objDetalleVenta)
        {
            try
            {
                return AD_Venta.GetInstacia().RegistrarDetalleVenta(objDetalleVenta);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public int ObtenerNum_Factura()
        {
                try
                {
                    return AD_Venta.GetInstacia().ObtenerNum_Factura();
                }
                catch (Exception Error)
                {
                    throw Error;
                }
        }
    }
}
