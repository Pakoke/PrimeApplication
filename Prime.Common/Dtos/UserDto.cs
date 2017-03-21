using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Common.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }
        
        public string Email { get; set; }

        public string TokenFacebook { get; set; }

        public string TokenGoogle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
