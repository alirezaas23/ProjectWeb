using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Services
{
    public class TicketAnswerService : ITicketAnswerInterface
    {
        private readonly ITicketAnswerRepository _ticketAnswerRepository;

        public TicketAnswerService(ITicketAnswerRepository ticketAnswerRepository)
        {
            _ticketAnswerRepository = ticketAnswerRepository;
        }

        public void AddTicketAnswer(TicketAnswer ticketAnswer)
        {
            _ticketAnswerRepository.AddTicketAsnwer(ticketAnswer);
        }
    }
}
