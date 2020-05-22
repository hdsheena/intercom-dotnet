using NUnit.Framework;
using System;
using Intercom.Core;
using Intercom.Data;
using Intercom.Clients;
using Intercom.Exceptions;
using Intercom.Factories;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using Newtonsoft.Json;
using Moq;

namespace Intercom.Test
{
    [TestFixture()]
    public class TeamsClientTest : TestBase
    {
        private TeamsClient teamsClient;

        public TeamsClientTest()
            : base()
        {
            var auth = new Authentication(AppId, AppKey);
            var restClientFactory = new RestClientFactory(auth);
            teamsClient = new TeamsClient(restClientFactory);
        }

        [Test()]
        public void View_WithEmptyString_ThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => teamsClient.View(String.Empty));
        }

        [Test()]
        public void View_NoId_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => teamsClient.View(new Team()));
        }
    }
}