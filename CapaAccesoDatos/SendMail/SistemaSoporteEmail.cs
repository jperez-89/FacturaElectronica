using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos.SendMail
{
    class SistemaSoporteEmail:MailServer
    {
        public SistemaSoporteEmail()
        {
            De = "jrwc1989@gmail.com";
            Password = "pinky1989";
            Host = "smtp.gmail.com";
            Puerto = 587;
            Ssl = true;
            IniciarClienteSmtp();
        }
    }
}
