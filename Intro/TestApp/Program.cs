using System;

namespace TestApp
{

    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Hello world!");
        }

        public string[] NumbersToStringArray(int a, int b)
        {
            var array = new string[2];
            array[0] = a.ToString();
            array[1] = b.ToString();
            return array;
        }
    }
}
// function numbersToStringArray(a,b)
// {
//     var array = [];
//     array[0] = a.toString();
//     array[1] = b.toString();
//     return array;
// } 