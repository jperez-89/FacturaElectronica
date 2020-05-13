using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EProducto
    {
        public int Id { get; set; }
        public char action { get; set; }
        public string ProductId { get; set; }
        public string name { get; set; }
        public string measure { get; set; }
        public decimal unitPriceC { get; set; }
        public decimal unitPriceD { get; set; }
        public int CategoryID { get; set; }
        public bool state { get; set; }

        public EProducto() { }
    }
}
