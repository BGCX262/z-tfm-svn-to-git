using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Srida.DAL;

namespace Zelenjava.Tests.DAL
{
    [TestClass]
    public class test1_CanGenerateSchema
    {
        [TestMethod]
        public void CanGenerateSchema()
        {
            Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(m => m.Server(@".\SQLEXPRESS")
                                                         .Database("ZelenjavaDB")
                                                         .TrustedConnection()))
                .Mappings(m =>
                          m.FluentMappings.AddFromAssemblyOf<NHibernateHelper>())
                .ExposeConfiguration((Configuration config) => new SchemaExport(config).Create(false, true))
                .BuildSessionFactory();
        }
    }
}
