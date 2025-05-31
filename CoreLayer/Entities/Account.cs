using Domain.Commons;
using Domain.Enums;

namespace Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Email { get; set; }

        public string HashPassword { get; set; }

        public UserRole Role { get; set; }

        public User? User { get; set; }

        public Doctor? Doctor { get; set; }

        public ICollection<AccountToken> Tokens { get; set; } = new List<AccountToken>();
    }
}
