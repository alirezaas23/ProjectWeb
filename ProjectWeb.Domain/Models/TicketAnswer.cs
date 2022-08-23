using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Domain.Models
{
    public class TicketAnswer
    {
        public int TicketAnswerId { get; set; }
        public string TicketAnswerDateTime { get; set; }
        public string TicketAnswerText { get; set; }
        public ICollection<Ticket_TicketAnswer> Ticket_TicketAnswers { get; set; }
    }
}
