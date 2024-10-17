using Microsoft.VisualBasic;

public class Fraction{  //Create a class to hold fraction
    //The class should be in its own file
    // 2 attribute/variable for top and bottom: make sure they are private
    private int numerator; //get allows you to retrieve the value of the denominator from outside the class.
    private int denominator;// set allows you to set the value of the denominator while ensuring the logic inside set (e.g., checking if the value is 0) is respected.

    //constructor w/ no parameters and when no values/number provided, defaults to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    //a constructor that has 1 perameter for the numerator and initializes the denominator to 1 so if a whole number is passed in, it creates a fraction of that number
    public Fraction(int wholeNumber)
    {
        this.numerator = wholeNumber;
        this.denominator = 1; //initializes (makes) denominator = 1
    }

    //a constructor that has 2 parameters, one for the top, one for the bottom
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        if (denominator == 0) //needs to have validation in case denominator input is 0
        {
            throw new ArgumentException("Denominator can't be zero.");
        }
        this.denominator = denominator;
    }
    
    // //constructor to initialize the fraction
    // public Fraction(int numerator, int denominator)
    // {
    //     this.numerator = numerator;
    //     this.denominator =  denominator != 0 ? denominator : throw new ArgumentException("Denominator cannot be zero.");
    // }

    // public property to get the numerator (with no setter to keep it read-only)
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    //public property to get/set the denominator with validation
    public int Denominator
    {
        get {return denominator;}
        set 
        {
            if (value == 0)
                throw new ArgumentException("Denominator can't be 0");
            denominator = value;
        }
    }
    //return the fraction as a string
    public string GetFractionString() 
    {
        return $"{Numerator}/{Denominator}";
    }
    //could also be done like this: 
    //public string GetFractionString()
    //{
        //this isn't stored as member variable. it's temporary, and will be recomputed each time it's called
        //string text = $"{numerator}/{denominator}";
        //return text;
    //}


    //returns fraction as a decimal
    public double GetDecimalValue() 
    {
        return (double)Numerator / Denominator;
    }
}

//chatgpt url: https://chatgpt.com/share/67113c23-af70-800b-9e62-3f3d3d1ff7ba