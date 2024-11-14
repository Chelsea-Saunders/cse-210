using System;

public class Rectangle : Shape{
    private double _width;
    private double _side;

    //constructor
    public Rectangle (string color, double width, double side) : base(color)
    {
        _width = width;
        _side = side;
    }

    public override double GetArea()
    {
        return _width * _side;
    }
}