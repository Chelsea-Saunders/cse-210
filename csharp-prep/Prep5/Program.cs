using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquaredNumber(userNumber);

        DisplayResult(squaredNumber, userName);
    }
    static void DisplayWelcomeMessage()
    //static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int SquaredNumber(int number)
    {
        int squared = number * number;
        return squared;
    }
    static void DisplayResult(int squared, string name )
    {
        Console.WriteLine($"{name}, the square of your number is {squared}");
    }
}