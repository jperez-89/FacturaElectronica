using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security.Authentication;

namespace CapaAccesoDatos.SendMail
{
    // Clase para enviar el correo. Es abstracta para que no pueda ser modificada.
    public abstract class MailServer
    {
        private SmtpClient SmtpClient;
        protected string De { get; set; }
        protected string Password { get; set; }
        protected string Host { get; set; }
        protected int Puerto { get; set; }
        protected bool Ssl { get; set; }

        protected void IniciarClienteSmtp()
        {
            // Instancia el protocolo para envio de correos
            SmtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential(De, Password),
                Host = Host,
                Port = Puerto,
                EnableSsl = Ssl
            };
        }

        // Proceso para enviar el correo, puede ser accesible por otra clase
        public void EnviarCorreo(string Asunto, string Mesaje, List<string> Destinatarios)
        {
            var MensajeCorreo = new MailMessage(); // Instancia de un mensaje
            try
            {
                MensajeCorreo.From = new MailAddress(De); // Agrega el remitente
                foreach (string Direccion in Destinatarios) // Agrega la lista de destinatarios
                {
                    MensajeCorreo.To.Add(Direccion);
                }
                MensajeCorreo.Subject = Asunto; // Agrega el asunto
                MensajeCorreo.Body = Mesaje; // Agrega el mensaje
                MensajeCorreo.Priority = MailPriority.Normal; // Agrega la prioridad

                //Envia el correo
                SmtpClient.Send(MensajeCorreo);
                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                MensajeCorreo.Dispose();
                SmtpClient.Dispose();
            }
        }
    }
}
