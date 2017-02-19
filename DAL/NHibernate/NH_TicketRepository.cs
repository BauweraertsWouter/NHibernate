﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using SC.BL.Domain;
using SC.DAL.NHibernate.Configuration;

namespace SC.DAL.NHibernate
{
    public class NH_TicketRepository : ITicketRepository
    {
        private ISession session = new SC_NhibernateConf().Session;
        public IEnumerable<Ticket> ReadTickets()
        {
            throw new NotImplementedException();
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            using (var tx = session.BeginTransaction())
            {
                object id = 0;
                try
                {
                    id = session.Save(ticket);
                    tx.Commit();
                    return session.Get<Ticket>(id);
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public Ticket ReadTicket(int ticketNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public void UpdateTicketStateToClosed(int ticketNumber)
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket(int ticketNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TicketResponse> ReadTicketResponsesOfTicket(int ticketNumber)
        {
            throw new NotImplementedException();
        }

        public TicketResponse CreateTicketResponse(TicketResponse response)
        {
            throw new NotImplementedException();
        }
    }
}
