using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LandingApi.ViewModels;
using Xunit;

namespace LandingApi.test
{

    public class LeadControllerTest : IntegrationTest
    {
        [Fact]
        public async Task Get_AllLanding_ReturnAllLanding()
        {
            var response = await httpTestClient.GetAsync("/api/Lead");
            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task Post_CreateLeadind_ReturnNotFound()
        {
            ClientViewModel client = TestDataFactory.CreateClientViewModel();

            client.Birthday = "2022-02-30";

            var response = await httpTestClient.PostAsJsonAsync("/api/Lead", client);
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Post_CreateLeadind_ReturnCreatedLanding()
        {
            var client = TestDataFactory.CreateClientAsDictionary();
            var encodedContent = new FormUrlEncodedContent(client);
            var response = await httpTestClient.PostAsync("/api/Lead", encodedContent);

            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
