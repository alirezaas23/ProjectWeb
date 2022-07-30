using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public string TicketSubject { get; set; }
        public string TicketDateTime { get; set; }
        public string TicketText { get; set; }
    }
}
