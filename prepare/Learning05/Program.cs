using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        //create a list of shapes
        List<Shape> shapes = new List<Shape>();

        //add shapes to the above list
        shapes.Add(new Square("red", 5));
        shapes.Add(new Rectangle("purple", 2, 5));
        shapes.Add(new Circle("green", 3));

        //iterate through list and display information for each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.Color} shape has an area of {shape.GetArea()}");
        }

        // //create a new square instance, call the getColor() and getARea() methods and make sure they return the values you expect
        // Square square = new Square("red", 5);
        // Console.WriteLine($"The square is {square.Color} and has an area of {square.GetArea()}");

        // //create a new rectangle instance
        // Rectangle rectangle = new Rectangle("purple", 2, 5);
        // Console.WriteLine($"This rectangle is {rectangle.Color} and has an area of {rectangle.GetArea()}");

        // //create a new circle instance
        // Circle circle = new Circle("green", 3);
        // Console.WriteLine($"The circle is {circle.Color} and has an area of")
    }
}