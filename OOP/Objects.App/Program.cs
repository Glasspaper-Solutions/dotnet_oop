using System;

namespace Objects.App
{
    
    // domain = geometric shapes
    
    abstract class Shape
    {
        public abstract double GetArea();
    }
    class Triangle : Shape
    {
        public Triangle(double length, double height)
        {
            Length = length;
            Height = height;
        }

        public double Length { get; set; }
        public double Height { get; set; }

        public override double GetArea()
        {
            return (Length * Height) / 2;
        }
    }
    class Square : Shape
    {
        public Square(double length, double height)
        {
            Length = length;
            Height = height;
        }

        public double Length { get; set; }
        public double Height { get; set; }
        public override double GetArea()
        {
            return Length * Height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Triangle myTriangle = new Triangle(10,10);
            Square mySquare = new Square(10,10);

            PrintAreaOfShape(mySquare);
            PrintAreaOfShape(myTriangle);
        }

        public static void PrintAreaOfShape(Shape shape)
        {
            Console.WriteLine(shape.GetArea());
        }
    }
}
