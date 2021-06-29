using Xunit;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using BasicWebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using AspNetCore.Http.Extensions;
using System;

namespace BasicWebApi.Test.TestServer
{
    public class PostTests 
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public PostTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async Task Post_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new Person
            {
                Name = "Kari",
                Age = 22
            };

            // act
            var httpResponse = await client.PostAsJsonAsync("api/person",body);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task Post_WithAgeNull_ShouldReturn_BadRequest()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new Person
            {
                Name = "Kent",
            };

            // act
            var httpResponse = await client.PostAsJsonAsync("api/person",body);

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_WithNameNull_ShouldReturn_BadRequest()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new Person
            {
                Age = 22,
            };

            // act
            var httpResponse = await client.PostAsJsonAsync("api/person",body);

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        public async Task Post_Twice_ShouldReturn_BadRequest()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new Person
            {
                Name = "Gunnar",
                Age = 35
            };

            // act
            var httpResponse = await client.PostAsJsonAsync("api/person",body);
            var httpResponse2 = await client.PostAsJsonAsync("api/person",body);

            // assert
            httpResponse2.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

    }
}