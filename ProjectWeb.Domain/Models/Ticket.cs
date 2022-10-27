using System.ComponentModel.DataAnnotations;
using ProjectWeb.Domain.Models.Account;
using ProjectWeb.Domain.Models.Common;

namespace ProjectWeb.Domain.Models
{
    public class Ticket : BaseEntity
    {
        #region Properties

        public long UserId { get; set; }

        [Required]
        [MaxLength(150)]
        public string TicketSubject { get; set; }

        [Required]
        public string TicketContent { get; set; }

        #endregion

        #region Relations

        public User User { get; set; }

        #endregion
    }
}
