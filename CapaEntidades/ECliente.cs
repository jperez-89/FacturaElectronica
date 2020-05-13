using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ECliente
    {
        public int Id { get; set; }
        public char action { get; set; }
        public char typeDNI { get; set; }
        public string DNI { get; set; }
        public string name { get; set; }
        public Int32 districtID { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public bool state { get; set; }
        public string direction { get; set; }

        public ECliente() { }
    }
}
