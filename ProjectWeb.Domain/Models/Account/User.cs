using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text;
using ProjectWeb.Domain.Models.Common;

namespace ProjectWeb.Domain.Models.Account
{
    public class User : BaseEntity
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [MaxLength(100)]
        [Required]
        public string Password { get; set; }
        public string ActivationCode { get; set; }
        public string Avatar { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBan { get; set; }
    }
}
