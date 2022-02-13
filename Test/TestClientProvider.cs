using backend_crud;
using Microsoft.AspNetCore.TestHost;

namespace backend_test
{
    internal class TestClientProvider
    {
        public HttpClient Client { get; set; }
        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            }).UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}