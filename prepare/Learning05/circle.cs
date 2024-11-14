using System;

public class Circle : Shape
{
    private double _radius;

    //constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return (float)Math.PI * _radius * _radius;
    }
}