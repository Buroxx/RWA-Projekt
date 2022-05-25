using System;
using System.Collections.Generic;
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
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
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
