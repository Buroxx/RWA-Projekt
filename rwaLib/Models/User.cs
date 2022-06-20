using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    [Serializable]
    public class User
    {
        private const char DELIMITER = '|';

        public int Id { get; set; }
        [Required(ErrorMessage = "Username can't be empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't be empty")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [EmailAddress(ErrorMessage ="Wrong e-mail type")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone can't be empty")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address can't be empty")]
        public string Address { get; set; }

        public string FirstName
        {
            get
            {
                return UserName.Split(' ')[0];
            }
        }

        public string LastName
        {
            get
            {
                return UserName.Split(' ')[1];
            }
        }

        public override string ToString()
        {
            return $"{Id}{DELIMITER}{UserName}";
        }

    }
}
