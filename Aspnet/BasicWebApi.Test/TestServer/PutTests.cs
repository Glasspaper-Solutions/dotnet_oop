using Xunit;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using AspNetCore.Http.Extensions;
using BasicWebApi.Contracts.V1;

namespace BasicWebApi.Test.TestServer
{
    public class PutTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public PutTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async Task Put_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var createModel = new PersonCreateModel
            {
                Name = "Marit",
                Age = 22
            };
            var updateModel = new PersonUpdateModel
            {
                Name = "Marit",
                Age = 122
            };
            await client.PostAsJsonAsync("api/person",createModel);


            // act
            var httpResponse = await client.PutAsJsonAsync("api/person",updateModel);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task Put_WithPersonNotExists_ShouldReturn_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new PersonUpdateModel
            {
                Name = "Arnt",
                Age = 22
            };

            // act
            var httpResponse = await client.PutAsJsonAsync("api/person",body);

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

         [Fact]
        public async Task Put_WithAgeNull_ShouldReturn_BadRequest()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new PersonUpdateModel
            {
                Name = "Franz",
            };

            // act
            var httpResponse = await client.PutAsJsonAsync("api/person",body);

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_WithNameNull_ShouldReturn_BadRequest()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new PersonUpdateModel
            {
                Age = 22,
            };

            // act
            var httpResponse = await client.PutAsJsonAsync("api/person",body);

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}