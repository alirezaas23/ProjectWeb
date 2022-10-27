#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using System.Text;
using ProjectWeb.Domain.Models.Common;
using ProjectWeb.Domain.Models.Location;

namespace ProjectWeb.Domain.Models.Account
{
    public class User : BaseEntity
    {
        #region Properties

        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [MaxLength(100)]
        [Required]
        public string Password { get; set; }

        public string? Description { get; set; }

        public long? CountryId { get; set; }
        public long? CityId { get; set; }
        public string ActivationCode { get; set; }
        public string Avatar { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBan { get; set; }

        #endregion

        #region Relations

        [InverseProperty("UserCountries")]
        public State? Country { get; set; }

        [InverseProperty("UserCities")]
        public State? City { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }

        #endregion
    }
}
