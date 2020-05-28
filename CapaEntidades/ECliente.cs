namespace CapaEntidades
{
    public class ECliente
    {
        public int Id { get; set; }
        public char Action { get; set; }
        public char TypeDNI { get; set; }
        public string DNI { get; set; }
        public string Name { get; set; }
        public int DistrictID { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public bool State { get; set; }
        public string Direction { get; set; }

        public ECliente() { }
    }
}
