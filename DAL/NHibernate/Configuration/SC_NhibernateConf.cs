using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using SC.DAL.NHibernate.Mappings.Fluent;

namespace SC.DAL.NHibernate.Configuration
{
    public class SC_NhibernateConf
    {
        private static ISessionFactory _session;

        private static ISessionFactory Session
        {
            get
            {
                if (_session == null)
                    LoadDb();

                return _session;
            }
        }

        private static void LoadDb()
        {
            _session = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                        c => c.FromConnectionStringWithKey("SC_NHibernate"))
                    .Dialect(typeof(MsSql2012Dialect).AssemblyQualifiedName)
                    .Driver(typeof(SqlClientDriver).AssemblyQualifiedName))
                .Mappings(mapper =>
                {
                    mapper.FluentMappings.Add<TicketFluentMap>();
                    mapper.FluentMappings.Add<HardwareTicketFluentMap>();
                    mapper.FluentMappings.Add<TicketResponseFluentMap>();
                })
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                    .Create(true, true))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return Session.OpenSession();
        }

    }


    //public class SC_NhibernateConf
    //{
    //    public ISession Session { get; private set; }

    //    public SC_NhibernateConf()
    //    {
    //        LoadDb();
    //    }

    //    private void LoadDb()
    //    {
    //        var fluentConfig = Fluently.Configure()
    //            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
    //                    c => c.FromConnectionStringWithKey("SC_NHibernate"))
    //                .Dialect(typeof(MsSql2012Dialect).AssemblyQualifiedName)
    //                .Driver(typeof(SqlClientDriver).AssemblyQualifiedName))
    //            .Mappings(mapper =>
    //            {
    //                mapper.FluentMappings.Add<TicketFluentMap>();
    //                mapper.FluentMappings.Add<HardwareTicketFluentMap>();
    //                mapper.FluentMappings.Add<TicketResponseFluentMap>();
    //            });
    //        var nhConfiguration = fluentConfig.BuildConfiguration();
    //        var sessionFactory = nhConfiguration.BuildSessionFactory();
    //        Session = sessionFactory.OpenSession();
    //        using (var tx = Session.BeginTransaction())
    //        {
    //            new SchemaUpdate(nhConfiguration).Execute(Console.WriteLine, true);
    //            tx.Commit();
    //        }
    //    }
    //}
}