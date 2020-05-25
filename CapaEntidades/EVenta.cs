using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EVenta
    {
        public char Action { get; set; }
        public int dFact { get; set; }
        public int UserID { get; set; }
        public int NumFact { get; set; }
        public DateTime FechaFact { get; set; }
        public string ClientDNI { get; set; }
        public int Plazo { get; set; }
        public string Moneda { get; set; }
        public string MedioPago { get; set; }
        public string EstadoHacienda { get; set; }
        public string Enviada { get; set; }
        public string Anulada { get; set; }

        public EVenta() { }
    }

    public class EVentaDetalle
    {
        public int Id_Nfact {get; set; }
        public int LineaVenta { get; set; }
        public string ProductID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnit { get; set; }
        public int PorceDesc { get; set; }
        public decimal MontDesc { get; set; }
        public int PorceIVA { get; set; }
        public decimal MontIVA { get; set; }

        public EVentaDetalle() { }
    }
}
