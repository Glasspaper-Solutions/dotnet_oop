using FluentAssertions;
using Xunit;
using System.Linq;

namespace BasicWebApi.Test
{
    public class PersonServiceTests
    {


        [Fact]
        public void GetByName_Result_ShouldNotBeNull()
        {
            // arrange
            var service = new PersonService();
            service.CreateNewPerson(
                new Person
                {
                    Name = "per",
                    Age = 22
                });

            // act
            var result = service.GetByName("per");

            // assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void GetByName_Result_ShouldReturnCorrectPerson()
        {
            // arrange
            var service = new PersonService();
            service.CreateNewPerson(
                new Person
                {
                    Name = "per",
                    Age = 22
                });
            service.CreateNewPerson(
                new Person
                {
                    Name = "arne",
                    Age = 55
                });

            // act
            var result = service.GetByName("per");

            // assert
            result.Name.Should().Be("per");
            result.Age.Should().Be(22);
        }
   
        [Fact]
        public void Delete_Result_ShouldNotBeNull()
        {
            // arrange
            var service = new PersonService();
            service.CreateNewPerson(
                new Person
                {
                    Name = "per",
                    Age = 22
                });
            service.CreateNewPerson(
                new Person
                {
                    Name = "arne",
                    Age = 55
                });

            // act
            var result = service.DeleteByName("per");

            // assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void Delete_AfterRemovingPer_GetAll_ShouldResultInEmptyList()
        {
            // arrange
            var service = new PersonService();
            service.CreateNewPerson(
                new Person
                {
                    Name = "per",
                    Age = 22
                });

            // act
            var result = service.DeleteByName("per");

            // assert
            service.GetAll().Count().Should().Be(0);
        }

        [Fact]
        public void Delete_WhenPersonIsnotFound_Should_ReturnNull()
        {
            // arrange
            var service = new PersonService();

            // act
            var result = service.DeleteByName("per");

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public void Delete_Result_ShouldMatchCreatedPerson()
        {
            // arrange
            var service = new PersonService();
            service.CreateNewPerson(
                new Person
                {
                    Name = "per",
                    Age = 22
                });

            // act
            var result = service.DeleteByName("Per");

            // assert
            result.Age.Should().Be(22);
            result.Name.Should().Be("per");
        }
    }
}