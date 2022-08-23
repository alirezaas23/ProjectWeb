using ProjectWeb.Application.Interfaces;
using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Application.Services
{
    public class TicketsCollectionService : ITicketsCollectionInterface
    {
        private readonly ITicketsCollectionRepository _ticketsCollectionRepository;

        public TicketsCollectionService(ITicketsCollectionRepository ticketsCollectionRepository)
        {
            _ticketsCollectionRepository = ticketsCollectionRepository;
        }

        public void AddTicketCollection(TicketsCollection ticketsCollection)
        {
            _ticketsCollectionRepository.AddTicketCollection(ticketsCollection);
        }
    }
}
