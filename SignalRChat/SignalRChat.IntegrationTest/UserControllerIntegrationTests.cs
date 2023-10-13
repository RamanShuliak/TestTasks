using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SignalRChat.DataBase.Entities;
using System.Collections;
using System.Net;
using System.Text;

namespace SignalRChat.IntegrationTest
{
    public class UserControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UserControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task FindChats_ReturnsOkWithChatList()
        {

            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/User/FindChats");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var chats = JsonConvert.DeserializeObject<List<Chat>>(responseContent);

            Assert.NotEmpty(chats);
        }

        [Fact]
        public async Task CreateUser_WithValidUserName_ReturnsOkWithUserId()
        {
            var client = _factory.CreateClient();

            var name = "newTestUser";

            var content = new StringContent($"\"{name}\"", Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/User/CreateUser", content);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var responseContent = await response.Content.ReadAsStringAsync();

            Assert.StartsWith("Id of new User =", responseContent);
        }
    }
}