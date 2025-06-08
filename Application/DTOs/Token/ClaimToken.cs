﻿using Application.DTOs.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Token
{
    public class ClaimToken : IdRequest
    {
        public long UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public long PlanID { get; set; }
    }
}
