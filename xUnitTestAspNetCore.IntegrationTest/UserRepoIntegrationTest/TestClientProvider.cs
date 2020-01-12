using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace xUnitTestAspNetCore.IntegrationTest.UserRepoIntegrationTest
{
    public class TestClientProvider : IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            // add reference to xUnitTestAspNetCore (asp net core project)
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = server.CreateClient();
        }

        public void Dispose()
        {
            // if server and Client is not null dispose them
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
