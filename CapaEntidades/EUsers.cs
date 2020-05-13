using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EUsers
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Province { get; set; }
        public string Canton { get; set; }
        public string District { get; set; }
        public string Direction { get; set; }
        public Char State { get; set; }
        public EUsers() { }

        public EUsers(int Id, string Identification, string Name, string Password, string Email, int Phone, string Province, string Canton, string District, string Direction, Char State)
        {
            this.Id = Id;
            this.DNI = Identification;
            this.Name = Name;
            this.Password = Password;
            this.Email = Email;
            this.Phone = Phone;
            this.Province = Province;
            this.Canton = Canton;
            this.District = District;
            this.Direction = Direction;
            this.State = State;
        }
    }
}
