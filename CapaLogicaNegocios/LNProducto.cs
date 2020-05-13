using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class LNProducto
    {
        #region SINGLETON
        private static LNProducto objLNProducto = null;
        private LNProducto() { }

        public static LNProducto GetInstacia()
        {
            if (objLNProducto == null)
            {
                objLNProducto = new LNProducto();
            }
            return objLNProducto;
        }

        #endregion
        public bool RegistrarProducto(EProducto objProducto)
        {
            try
            {
                return AD_Producto.GetInstacia().RegistrarProducto(objProducto);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public List<EProducto> MostarProductos()
        {
            try
            {
                return AD_Producto.GetInstacia().MostarProductos();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public bool ActualizarProducto(EProducto objProducto)
        {
            try
            {
                return AD_Producto.GetInstacia().ActualizarProducto(objProducto);
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public bool EliminarProducto(EProducto objProducto)
        {
            try
            {
                return AD_Producto.GetInstacia().EliminarProducto(objProducto);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public bool ActivarProducto(EProducto objProducto)
        {
            try
            {
                return AD_Producto.GetInstacia().ActivarProducto(objProducto);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public int ListarCantProductos()
        {
            try
            {
                return AD_Producto.GetInstacia().ListarCantProductos();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
