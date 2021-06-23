using System;

namespace ConsoleApp
{

    class Program2
    {
        public static void Run()
        {
            var me = new Person();
            me.Age = 26;
            me.Name = "Mats";
            me.DayIWasBornOn = DaysOfTheWeek.Monday;

            var myDog = new Dog();            
            myDog.Age = 2;
            myDog.Name = "Skippy";
   
            CallAllPrints(myDog);
            CallAllPrints(me);


            var today = DaysOfTheWeek.Monday;
            switch (today)
            {
                case DaysOfTheWeek.Monday:
                case DaysOfTheWeek.Tuesday:
                case DaysOfTheWeek.Wednesday:
                case DaysOfTheWeek.Thursday:
                case DaysOfTheWeek.Friday:
                Console.WriteLine("its a weekday");
                break;

                case DaysOfTheWeek.Saturday:
                case DaysOfTheWeek.Sunday:
                Console.WriteLine("Its weekend");
                break;
            }

        }

        private static void CallAllPrints(IPrintable printable )
        {
            printable.Print();
        }
    }

    
    public enum DaysOfTheWeek
    {
        Monday,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6
    }

    public class Person  : IPrintable
    {
        public DaysOfTheWeek DayIWasBornOn {get;set;}
        public int Age { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    public class Dog  : IPrintable
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    public interface IPrintable
    {
        void Print();
    }

    public struct Point 
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}