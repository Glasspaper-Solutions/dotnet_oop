using Xunit;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;

namespace BasicWebApi.Test
{
    public class DependencyInjectionTests
    {
        public DependencyInjectionTests()
        {
            // service lifetime
            
            // servicesCollection.AddSingleton();
            // only one can exists and is forever
            // always returns reference to the same object of type
            // always the same

            // servicesCollection.AddTransient();
            // create a new instance everytime someone asks for the service
            // always return new instance of same type
            // always new

            // servicesCollection.AddScoped();
            // most used one
            // acts like singleton until scope is exited
            // new per httprequest (ish)
        }

        [Fact]
        public void BasicUsage()
        {
            var servicesCollection = new ServiceCollection();
            servicesCollection.AddSingleton<IAnimalService,AnimalService>();

            // usage
            var serviceProvider = servicesCollection.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IAnimalService>();
            var animals = service.GetAnimals();
        }

        [Fact]
        public void TwoLevelsOfDependencies()
        {
            var servicesCollection = new ServiceCollection();
            servicesCollection.AddSingleton<IAnimalService,AnimalService>();
            servicesCollection.AddSingleton<AnimalController>();
            var serviceProvider = servicesCollection.BuildServiceProvider();

            // usage
            var animalController = serviceProvider.GetRequiredService<AnimalController>();
            animalController.Should().BeOfType<AnimalController>();
            animalController.Should().NotBeNull();
        }

        [Fact]
        public void TwoLevelsOfDependencies_WithFakeIAnimalService()
        {
            var servicesCollection = new ServiceCollection();
            servicesCollection.AddSingleton<IAnimalService,FakeAnimalService>();
            servicesCollection.AddSingleton<AnimalController>();
            var serviceProvider = servicesCollection.BuildServiceProvider();

            // usage
            var animalController = serviceProvider.GetRequiredService<AnimalController>();
            animalController.Should().BeOfType<AnimalController>();
            animalController.Should().NotBeNull();
        }

        [Fact]
        public void GetRequiredService_Twice_WithSingleton_HasSameHashCode()
        {
            // arrange
            var servicesCollection = new ServiceCollection();
            servicesCollection.AddSingleton<IAnimalService,FakeAnimalService>();
            var serviceProvider = servicesCollection.BuildServiceProvider();

            // act
            var result = serviceProvider.GetRequiredService<IAnimalService>();
            var result2 = serviceProvider.GetRequiredService<IAnimalService>();

            // assert
            var result1HashCode = result.GetHashCode();
            var result2HashCode = result2.GetHashCode();

            result1HashCode.Should().Be(result2HashCode);
        }

        [Fact]
        public void GetRequiredService_Twice_WithTransient_HasDifferentHashCodes()
        {
            // arrange
            var servicesCollection = new ServiceCollection();
            servicesCollection.AddTransient<IAnimalService,FakeAnimalService>();
            var serviceProvider = servicesCollection.BuildServiceProvider();

            // act
            var result = serviceProvider.GetRequiredService<IAnimalService>();
            var result2 = serviceProvider.GetRequiredService<IAnimalService>();

            // assert
            var result1HashCode = result.GetHashCode();
            var result2HashCode = result2.GetHashCode();

            result1HashCode.Should().NotBe(result2HashCode);
        }
    }
    //inversion of controll
    public class AnimalController
    {
        private readonly IAnimalService _service;

        // var controller = new AnimalController(new AnimalService())
        public AnimalController(IAnimalService service) 
        {
            _service = service;
        }
    }

    public class Animal 
    {
        public string Type { get; set; }
    }

    public interface IAnimalService
    {
        List<Animal> GetAnimals();
    }

    public class FakeAnimalService : IAnimalService
    {
        public List<Animal> GetAnimals()
        {
            return new List<Animal>{new Animal{Type="fake"}};
        }
    }

    public class AnimalService : IAnimalService
    {
        public List<Animal> GetAnimals()
        {
            return new List<Animal>
            {
                new Animal{Type = "Cat"},
                new Animal{Type = "Dog"},
                new Animal{Type = "Tiger"}
            };
        }
    }
}