using Xunit;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using BasicWebApi;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BasicWebApi.Test.TestServer
{
    public class GetTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public GetTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async Task Get_OnRoot_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/person");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task Get_WithId_ShouldReturn_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/person/Per");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}