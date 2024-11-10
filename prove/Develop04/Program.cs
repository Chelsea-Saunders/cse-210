using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");

        //welcome message
        Console.WriteLine("Welcome to the Mindfullness App!");
        Console.WriteLine("Please pick from the Main Menu options below:");

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            // Console.Clear(); //clear the console each time
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Breath Activity");
            Console.WriteLine("2. Reflect Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            string input = Console.ReadLine();
            int choice;

            if (int.TryParse(input, out choice))
            {
                if (choice == 1)
                {
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.StartBreathingActivity();
                }
                else if (choice == 2)
                {
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.StartReflectingActivity();
                }
                else if (choice == 3)
                {
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.StartListingActivity();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Exiting Mindfullness App. Goodbye!");
                    exit = true;
                }
                else{
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try a number between 1-4.");
            }
        }
    }
}