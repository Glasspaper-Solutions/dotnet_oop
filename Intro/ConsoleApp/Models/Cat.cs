using System;

namespace ConsoleApp.Models
{

    public class Animal
    {
        public Animal(string name)
        {
            Name = name;
        }
        public string Name {get;}

        protected string GetName()
        {
            return Name;
        }
       
    }

    public class Cat : Animal
    {

        public void PrintName()
        {
            var name = GetName();
            Console.WriteLine(name);

        }

        public Cat(string name) : base(name)
        {
        }
    }
}