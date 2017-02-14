using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NUnit.Framework;
using SC.BL.Domain;

namespace SC.Mappings.Test
{
    [TestFixture]
    public class TicketMappingTest
    {
        private InMemoryDataBaseForXmlMappings db;
        private ISession session;

        [TestFixtureSetUp]
        public void SetUp()
        {
            db = new InMemoryDataBaseForXmlMappings();
            session = db.Session;
        }

        [Test]
        public void MapsPrimitivePropertiesForTicket()
        {
            object id = 0;
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new Ticket
                {
                    AccountId = 1,
                    DateOpened = DateTime.Today,
                    State = TicketState.Open,
                    Text = "Test for mapping",
                    TicketNumber = 1
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var ticket = session.Get<Ticket>(id);

                Assert.That(ticket.TicketNumber, Is.EqualTo(1));
                Assert.That(ticket.AccountId, Is.EqualTo(1));
                Assert.That(ticket.DateOpened, Is.EqualTo(DateTime.Today));
                Assert.That(ticket.State, Is.EqualTo(TicketState.Open));
                Assert.That(ticket.Text, Is.EqualTo("Test for mapping"));

                transaction.Commit();
            }
        }
    }

    
}
