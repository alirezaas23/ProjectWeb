using ProjectWeb.Domain.Interfaces;
using ProjectWeb.Domain.Models;
using ProjectWeb.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectWeb.Infra.Data.Repositories
{
    public class TicketsCollectionRepository : ITicketsCollectionRepository
    {
        private readonly ApplicationContext _ctx;

        public TicketsCollectionRepository(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public void AddTicketCollection(TicketsCollection ticketsCollection)
        {
            _ctx.TicketsCollections.Add(ticketsCollection);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
