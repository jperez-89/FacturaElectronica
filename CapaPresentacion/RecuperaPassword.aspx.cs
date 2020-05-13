using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocios;

namespace CapaPresentacion
{
    public partial class RecuperaPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        bool respuesta = false;
        protected void BtnRecPass_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid & txtIdentificacion.Text != "")
            {
                EUsers objUser = new EUsers
                {
                    DNI = txtIdentificacion.Text
                };

                respuesta = LNUsers.GetInstacia().RecuperaPassword(objUser);

                if (respuesta)
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Se te a enviado tu contraseña al correo, por favor verifica.', 'success', 'zoomIn');", true);
                    //ClientScript.RegisterStartupScript(GetType(), "alert", "sw('Se te a enviado tu contraseña al correo, por favor verifica.');", true);
                    //Response.Redirect("Inicio.aspx");
                    //Response.Write("<script> alert('usuario correcto') </script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Identificación desconocida o no registrada en el sistema, intenta de nuevo!', 'error', 'zoomIn');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Complete campo de Identificación', 'error', 'zoomIn');", true);
            }
        }
    }
}