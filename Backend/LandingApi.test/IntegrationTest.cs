using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LandingApi.test
{
    public class IntegrationTest
    {
        protected readonly HttpClient httpTestClient;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();

            httpTestClient = appFactory.CreateClient();
            httpTestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}