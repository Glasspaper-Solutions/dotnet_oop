using System;
using Xunit;

namespace BasicWebApi.Test
{
    public class ExtensionMethodsTests
    {

        [Fact]
        public void WhatIsExtensionMethods()
        {
            var myCar = new Car("Honda",4);
            myCar.DriveFast();
            myCar.DriveFast();
        }
    }

    public class Car
    {
        public Car(string type, int amountOfWheels)
        {
            Type = type;
            AmountOfWheels = amountOfWheels;
        }

        public string Type { get; set; }
        public int AmountOfWheels { get; set; }
    }

    public static class CarExtensions
    {
        public static void DriveFast(this Car car)
        {
            Console.WriteLine("Im going super fast");
        }
    }
}