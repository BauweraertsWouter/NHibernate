using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using SC.BL.Domain;
using SC.DAL.NHibernate.Configuration;

namespace SC.DAL.NHibernate
{
    public class NH_TicketRepository : ITicketRepository
    {
        private ISession session = new SC_NhibernateConf().Session;
        public IEnumerable<Ticket> ReadTickets()
        {
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    IEnumerable<Ticket> tickets = session.Query<Ticket>();
                    tx.Commit();
                    return tickets;
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
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
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public Ticket ReadTicket(int ticketNumber)
        {
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    Ticket t = session.Get<Ticket>(ticketNumber);
                    tx.Commit();
                    return t;
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void UpdateTicket(Ticket ticket)
        {
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    session.Update(ticket);
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void UpdateTicketStateToClosed(int ticketNumber)
        {
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    Ticket t = session.Get<Ticket>(ticketNumber);
                    t.State = TicketState.Closed;
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void DeleteTicket(int ticketNumber)
        {
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    session.Delete(session.Get<Ticket>(ticketNumber));
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
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
