using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Account
{
    public class CreateAccountDTO
    {
        [EmailAddress(ErrorMessage ="Email is not valid")]
        public string Email { get; set; }

        public string HashPassword { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }
    }
}
