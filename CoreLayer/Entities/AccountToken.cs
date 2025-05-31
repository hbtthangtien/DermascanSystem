using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AccountToken : BaseEntity
    {
        public required string Token { get; set; }

        public DateTime ExpiryTime { get; set; }

        public long AccountId { get; set; }

        public Account? Account { get; set; }
    }
}
