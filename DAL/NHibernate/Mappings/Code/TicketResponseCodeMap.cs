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
    public class TicketResponseCodeMap : ClassMapping<TicketResponse>
    {
        public TicketResponseCodeMap()
        {
            Id(tr=>tr.Id, mapper =>
            {
                mapper.Generator(Generators.HighLow);
                mapper.Column("Id");
                mapper.Length(10);
                mapper.UnsavedValue(0);
            });
            Property(tr => tr.Date);
            Property(tr => tr.Text);
            Property(tr => tr.IsClientResponse);
            ManyToOne(tr=>tr.Ticket, mapping => mapping.Class(typeof(Ticket)));
        }
    }
}
