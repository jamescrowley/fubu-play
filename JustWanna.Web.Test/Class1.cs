using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustWanna.Web.Models;
using Machine.Specifications;
using NUnit.Framework;
using Raven.Client.Document;

namespace JustWanna.Web.Tests
{
    public class RavenDbTest
    {
        static DocumentStore DocumentStore;
        Establish context = () =>
                                {
                                    DocumentStore = new DocumentStore {Url = "http://localhost:8080"};
                                    DocumentStore.Initialize();
                                };
        Cleanup cleanup = () => DocumentStore.Dispose();
    }
    public class Adding_activity 
    {
        [Test]
        public void Test()
        {
            //using (var documentStore = new EmbeddableDocumentStore  { RunInMemory = true, })
            using (var documentStore = new DocumentStore { Url="http://localhost:8080" })
            {
                documentStore.Initialize();
                string userId;
                using (var session = documentStore.OpenSession())
                {
                    var user = new User("James Crowley");
                    session.Store(user);
                    session.Store(new ReservationForUniqueFieldValue { Id =  "username/" + user.Name });
                    session.SaveChanges();
                    userId = user.Id;
                }
                using (var session = documentStore.OpenSession())
                {
                    var entity = session.Load<User>(userId);
                    Console.WriteLine(entity.Name);
                }
            }


        }
    }
}
