using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace SC.Mappings.Test
{
    public class InMemoryDataBaseForXmlMappings : IDisposable
    {
        protected Configuration config;
        protected ISessionFactory sessionFactory;

        public InMemoryDataBaseForXmlMappings()
        {
            config = new Configuration()
                .SetProperty(NHibernate.Cfg.Environment.ReleaseConnections, "on_close")
                .SetProperty(NHibernate.Cfg.Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                .SetProperty(NHibernate.Cfg.Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                .SetProperty(NHibernate.Cfg.Environment.ConnectionString, "data source=:memory:")
                .AddAssembly("DAL");

            sessionFactory = config.BuildSessionFactory();

            Session = sessionFactory.OpenSession();
        }

        public ISession Session { get; set; }

        public void Dispose()
        {
            Session.Dispose();
            sessionFactory.Dispose();
        }
    }
}
