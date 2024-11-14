using System;

public class Square: Shape
{
    private double _side;
    //constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    //override the GetArea() method from base class and fill in the body of this functin to return the area
    public override double GetArea()
    {
        return _side * _side;
    }
}