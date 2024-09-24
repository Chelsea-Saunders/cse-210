using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain = true;
        int min = 1;
        int max = 100;
        int guess;
        int number;
        int guesses;
        string response;

        while(playAgain)
        {
            guess = 0;
            guesses = 0;
            response = "";
            number = random.Next(min, max + 1);

            while(guess != numnber)
            {
                console.WriteLine ("Guess a number between" + min + " - " + max + ":");
                guess = convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Guess: " + guess);

                if (guess > number)
                {
                    Console.WriteLine(guess + " is to high!");
                }
                else if (guess < number)
                {
                    Console.WriteLine(guess + " is to low!");
                }
                guesses++;

            }

            Console.WriteLine("Number: " + number);
            Console.WriteLine("YOU WIN!!")
            Console.WriteLine("Guesses: " + guesses); 

            Console.WriteLine("Would you like to play again (Y/N): ")
            response = console.ReadLine();
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

        Console.WriteLine("Thanks for playing! ... I guess");

        Console.ReadyKey();

    }
}