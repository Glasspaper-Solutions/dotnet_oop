using Xunit;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using BasicWebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using AspNetCore.Http.Extensions;

namespace BasicWebApi.Test.TestServer
{
    public class DeleteTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public DeleteTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Delete_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new Person
            {
                Name = "per",
                Age = 22
            };
            await client.PostAsJsonAsync("api/person",body);


            // act
            var httpResponse = await client.DeleteAsync("api/person/Per");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task Delete_WithPersonNotExists_ShouldReturn_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.DeleteAsync("api/person/frank");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}