#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ProjectWeb.Domain.Models.Account;
using ProjectWeb.Domain.Models.Common;

namespace ProjectWeb.Domain.Models.Location
{
    public class State : BaseEntity
    {
        #region Properties

        public string Title { get; set; }
        public long? ParentId { get; set; }

        #endregion

        #region Relations

        public State? Parent { get; set; }

        [InverseProperty("Country")]
        public ICollection<User> UserCountries { get; set; }

        [InverseProperty("City")]
        public ICollection<User> UserCities { get; set; }

        #endregion
    }
}
