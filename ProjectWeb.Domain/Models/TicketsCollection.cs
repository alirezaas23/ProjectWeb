using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Models
{
    public class TicketsCollection
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int TicketAnswerId { get; set; }
        public Ticket Ticket { get; set; }
        public TicketAnswer TicketAnswer { get; set; }
    }
}
