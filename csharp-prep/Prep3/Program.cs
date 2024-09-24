using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("What is the magic number?");
        //int magicNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100 + 1);

        int guess = -1;
        int guesses;
        string response;
        bool playAgain = true;

        while(playAgain)
        {
                guess = 0;
                guesses = 0 - 1;
                response = "";

            while (guess != magicNumber)
            {
                Console.Write("What is your guess?");
                guess = int.Parse(Console.ReadLine());
            
                if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else if  (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }

                ++ guesses;

            }

            Console.WriteLine("Number: " + magicNumber);
            Console.WriteLine("YOU WIN!!");
            Console.WriteLine("Guesses: " + ++ guesses);

            Console.WriteLine("Would you like to play again (Y/N):  ");
            response = Console.ReadLine();
            response = response.ToUpper();

            if (response == "Y")
            {
                playAgain = true;
            }
            else
            {
                playAgain = false;
            }
        }
        Console.WriteLine("Thanks for playing!!");

        Console.Read();
    }
}