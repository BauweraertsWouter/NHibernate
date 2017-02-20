using FluentNHibernate.Mapping;
using SC.BL.Domain;

namespace SC.DAL.NHibernate.Mappings.Fluent
{
    public class TicketFluentMap : ClassMap<Ticket>
    {
        public TicketFluentMap()
        {
            Id(t => t.TicketNumber).GeneratedBy.Identity();
            Map(t => t.AccountId);
            Map(t => t.Text);   
            Map(t => t.DateOpened);
            Map(t => t.State);
            HasMany<TicketResponse>(t => t.Responses).Cascade.DeleteOrphan();
        }
    }

    public class HardwareTicketFluentMap : SubclassMap<HardwareTicket>
    {
        public HardwareTicketFluentMap()
        {  
            DiscriminatorValue("HWT");
            Map(ht => ht.DeviceName);
        }
    }
}
