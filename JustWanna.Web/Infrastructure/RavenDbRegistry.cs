using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using Raven.Client.Document;
using StructureMap.Configuration.DSL;

namespace JustWanna.Web.Infrastructure
{
    public class RavenDbRegistry : Registry
    {
        public RavenDbRegistry()
        {
            var documentStore = new DocumentStore
            {
                ConnectionStringName = "RavenDb"
            }.Initialize();

            For<IDocumentSession>().Use(documentStore.OpenSession);
            For<IDocumentStore>().Singleton().Use(documentStore);
        }
    }
}