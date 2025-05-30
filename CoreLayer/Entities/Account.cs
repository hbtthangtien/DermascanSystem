using CoreLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string HashPassword { get; set; }

        public UserRole Role { get; set; }

        public User? User { get; set; }

        public Doctor? Doctor { get; set; }
    }
}
