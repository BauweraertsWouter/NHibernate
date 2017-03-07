using FluentNHibernate.Mapping;
using SC.BL.Domain;

namespace SC.DAL.NHibernate.Mappings.Fluent
{
    public class TicketResponseFluentMap : ClassMap<TicketResponse>
    {
        public TicketResponseFluentMap()
        {
            Id(tr => tr.Id).GeneratedBy.HiLo("1000");
            Map(tr => tr.Text);
            Map(tr => tr.Date);
            Map(tr => tr.IsClientResponse);
            References(tr => tr.Ticket);
        }
    }
}
