using System.ComponentModel.DataAnnotations;

namespace MVCBank.Models
{
    public class User
    {
        public int IdUser { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        public string Phone { get; set; }


        public string Role { get; set; }

        public string DNI { get; set; }
    }

}
