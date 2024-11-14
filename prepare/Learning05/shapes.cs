using System;

public class Shape
{
    //private memeber variable to store the color of the shape
    private string color;

    //constructor: a constructor that allows setting the color when a shape is created
    public Shape(string color)
    {
        this.color = color;
    }

    //property: a property to get and set the color of the shape
    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    
    //a virtual method for GetArea()
    public virtual double GetArea()
    {
        return 0;
    }
}