using System;
using CapaEntidades;
using CapaLogicaNegocios;

namespace CapaPresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        bool respuesta = false;

        protected void Btnigresar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid & txtDNI.Text != "" & txtEmail.Text != "")
            {
                EUsers objUser = new EUsers
                {
                    DNI = txtDNI.Text,
                    Email = txtEmail.Text
                };

                respuesta = LNUsers.GetInstacia().AccesoSistema(objUser);

                if (respuesta)
                {
                    Session["UserName"] = objUser.Name;
                    Session["UserId"] = objUser.Id;
                    Response.Redirect("Inicio.aspx");
                    //Response.Write("<script> alert('usuario correcto') </script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Usuario o contraseña incorrectos', 'error', 'zoomIn');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "Swalert('Complete los campos correctamente', 'error', 'zoomIn');", true);
            }
        }
    }
}