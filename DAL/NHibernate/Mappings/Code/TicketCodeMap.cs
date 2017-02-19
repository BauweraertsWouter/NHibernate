using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using SC.BL.Domain;

namespace SC.DAL.NHibernate.Mappings.Code
{
    public class TicketCodeMap : ClassMapping<Ticket>
    {
        public TicketCodeMap()
        {
            Id(t=>t.TicketNumber, mapper =>
            {
                mapper.Generator(Generators.HighLow);
                mapper.Column(("ticketNbr"));
                mapper.Length(10);
                mapper.UnsavedValue(0);
            });
            Property(t=>t.AccountId, mapper =>
            {
                mapper.NotNullable(true);
                mapper.Unique(false);
            });
            Property(t=>t.Text);
            Property(t => t.DateOpened);
            Property(t => t.State);
            Set(t=>t.Responses, mapper =>
            {
                mapper.Key(k=>k.Column("ticketNbr"));
                mapper.Cascade(Cascade.All);
            }, relation=>relation.OneToMany(
            mapping=>mapping.Class(typeof(TicketResponse))));
        }
    }
}
