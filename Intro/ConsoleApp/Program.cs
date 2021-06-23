using System;
using ConsoleApp.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var myAnimal = new Cat("skippy");
            myAnimal.PrintName();
        }
    }
}
