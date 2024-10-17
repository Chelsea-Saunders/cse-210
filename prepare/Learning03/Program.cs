using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"Using first constructor: {fraction1.Numerator}/{fraction1.Denominator}");

        Fraction fraction2 = new Fraction(6);
        Console.WriteLine($"Fraction only using a whole number 6: {fraction2.Numerator}/{fraction2.Denominator}");

        Fraction fraction3 = new Fraction(6, 7);
        Console.WriteLine($"Fraction using 3rd constructor: {fraction3.Numerator}/{fraction3.Denominator}");

        Fraction fraction = new Fraction(3, 4);
        Console.WriteLine($"new fraction: {fraction.Numerator}/{fraction.Denominator}");

        //call GetFractionString to display fraction as string
        Console.WriteLine(fraction.GetFractionString()); //output: 3/4

        // change the numerator and denominator using setters
        fraction.Numerator = 5;
        fraction.Denominator = 6;
        //Console.WriteLine($"changed numerator and denominator using setters: {fraction.Numerator}/{fraction.Denominator}");
        Console.WriteLine(fraction.GetFractionString()); //output: 5/6

        //create a method (GetDecimalValue) that returns a double that is the result of dividing numerator/denominator
        Console.WriteLine(fraction.GetDecimalValue());
        fraction.Numerator = 3;
        fraction.Denominator = 4;
        //convert a fraction to a decimal
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
        // double is used to represent numbers with decimal points.
        // Integer division (int / int) results in an integer, so casting to double ensures you get a decimal result when dividing.

        try
        {
                fraction.Denominator = 0; //throws exception
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}