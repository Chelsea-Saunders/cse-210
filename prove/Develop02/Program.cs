

using System;
using System.IO;


class Program
{
    static void Main()
    {
        //creating and instance of a class
        Journal newJournal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Select an option (1-5)");

            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    newJournal.AddEntry();
                    break;
                case "2":
                    newJournal.Display();
                    break;
                case "3":
                    Console.Write("Enter filename to save journal: ");
                    string saveFile = Console.ReadLine();
                    newJournal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load journal:  ");
                    string loadFile = Console.ReadLine();
                    if (!string.IsNullOrEmpty(loadFile))
                    {
                        newJournal.LoadFromFile(loadFile);
                    }
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("We'll see you tomorrow.");
                    break;
                default:
                    Console.WriteLine("Invalid option: pick a number between 1-5");
                    break;
            }

            //commit to git hub
        }
    }
}




//chatgpt: I wasn't able to figure this out on my own AT ALL! I spent all week with tutors and asking class mates for help and I regret that I didn't know i had to hit save to save all my chat bot converstations but here is the last one that's still on my computer: https://chatgpt.com/share/670a93e2-1164-800b-971f-e8e71c0ba8ac

        // PromptGenerator promptGenerator = new PromptGenerator();

        // //list of prompts
        // promptGenerator.prompts.Add("What is one thing you're grateful for today?  ");
        // promptGenerator.prompts.Add("What tender mercy from God did ou experience today?  ");
        // promptGenerator.prompts.Add("What was the strongest emotion you felt today and how did you work through it?  ");
        // promptGenerator.prompts.Add("If there was one thing you could do over today with hindsight, what would it be?  ");
        // promptGenerator.prompts.Add("How were you a blessing to someone else today?  ");
        // promptGenerator.prompts.Add("What is one thing you'd like to improve upon tomorrow?  ");

        // //retrieve and display the random script
        // string randomPrompt = promptGenerator.GetRandomPrompt();
        // Console.WriteLine("Random Prompt: " + randomPrompt);











// //creating and instance of a class
        // Entry entry1 = new Entry();

        // //setting the hard variables
        // entry1.date = "10/10/2024";//can hard code date
        // entry1.promptText = "Hello";
        // entry1.entryText = "Hi";

        // entry1.Display();



















// using System;
// using System.ComponentModel.Design;
// using System.Reflection.Metadata;
// using System.Runtime.InteropServices;
// using System.Xml.Serialization;

// namespace JournalApp
// {
//     class Program
//     {
//         static void Journal(string[] args)
//         {
//             //promptGenerator class 
//             private class promptGenerator()
//             {
//                 //prompt list
//                 List<string> prompt = new List<string>();
//                 prompt.Add("How did I see the hand of God in my life today?  ");
//                 prompt.Add("What is a Tender Mercy of God that I saw today?  ");
//                 prompt.Add("What is one thing you're grateful for today?  ");
//                 prompt.Add("What was a strong emotion I saw today and how did I work through it?  ");
//                 prompt.Add("If there was one part of my day I could re-do, what would it be and what would I do differently?  ");
//                 prompt.Add("What miracle did I see today that helped strengthen my faith:  ");
//                 prompt.Add("What made you smile today?  ");
//                 prompt.Add("Who did God put in your path today to be an instrument in his hands?  ");
//             }
//             public static void Write()
//             {

//             }
//         }
//     }
// };













// private static List<(string userEntry, DateTime timestamp)> journalEntries = new List<(string entry, DateTime timestamp)>();
//     //Journal class: write
//     public static void Write() 
//     {
//         //Write a journal entry using a random prompt 
//         Console.WriteLine("Write a Journal Entry using this prompt:  " + prompt);

//         //Read the input
//         string userEntry = Console.ReadLine();

//         //Date
//         DateTime currentTime = DateTime.Now;

//         //where the journal entry will be stored
//         List<string> journalEntry = new List<string>();

//         //Journal Entry with date
//         journalEntry.Add(currentTime + " " + userEntry);
        
//         Console.WriteLine("*****Journal*****");

//         // //create random object 
//         // Random random = new Random();

//         // //generate a random index based on prompts below
//         // int randomIndex = random.Next(prompt.Count);
        
//         // //select a random sentence from list
//         // string selectPrompt = prompt[randomIndex];

//         // //display random prompt for user
//         // Console.WriteLine("Here's a prompt to start writing:  " + selectedPrompt);

//         // //read users' journal entry
//         // string userEntry = Console.ReadLine();

//         // //add entry and tiemstamp to the list of journal entries
//         // journalEntries.Add((userEntry, currentTime));

//         // Console.WriteLine("*****Journal Entry Added*****");
//     }
//     //Random prompts from a list 
//     private static Prompt()
//     {
//         "How did I see the hand of God in my life today?  ",
//         "What is a Tender Mercy of God that I saw today?  ",
//         "What was a strong emotion I saw today and how did I work through it?  ", 
//         "If there was one part of my day I could re-do, what would it be and what would I do differently?  ", 
//         "What miracle did I see today that helped strengthen my faith:  ",
//         "What made you smile?  ",
//         "Who did God put in your path today to be an instrument in his hands?  "
//     };
    

//     public static void Display()
//     {
//         //Display the journal Entry
//         if (journalEntry.Count == 0)
//         {
//             Console.WriteLine("No Journal Entries Yet.");
//         }
//         else
//         {
//             foreach (var entry in journalEntry)
//             {
//                 Console.WriteLine(entry);
//             }
//         }
//     }

//     public static void Save()
//     {
//         //file name
//         Console.WriteLine("file name:  ");
//         string fileName = Console.ReadLine();

//         //write to file
//         List<string> journalEntry = new List<string>();
//         foreach (var (userEntry, DateTime) in journalEntry)
//         {
//             List.Add(${DateTime} {entry});
//         }
//         File.WriteAllLines(fileName, journalEntry);
//         Console.WriteLine("Journal Entry Saved");
//     }
//     public static void Load()
//     {
//         //Load journal entry from file
//         Console.WriteLine("file name:  ");
//         string fileName = Console.ReadLine();

        
//     }
// }
// class Main
// {
//     static void Menu(string[] args)
//     {
//         //create them menu options
//         Console.WriteLine("1. Write");
//         Console.WriteLine("2. Display");
//         Console.WriteLine("3. Save");
//         Console.WriteLine("4. Load");
//         Console.WriteLine("5. Exit");
//     }
//     //while loop to keep menu running
//     while(true)
//     {
//         Console.WriteLine("Welcome to Journaling!  ");
//         foreach (var choice in menuChoice)
//         {
//             console.WriteLine(choice);
//         }
//         Console.WriteLine("Which option would you like to start with (1-5)?  ");
//         string menuChoice = Console.ReadLine();

//         //create a switch arguement for menu options
//         switch (menuChoice)
//         {
//             case "1":
//                 Journal.Write();
//                 break;
//             case "2":
//                 Journal.Display();
//                 break;
//             case "3":
//                 Journal.Save();
//                 break;
//             case "4":
//                 Journal.Load();
//                 break;
//             case "5":
//                 Console.WriteLine("Goodbye!");
//                 return;
//             default:
//                 Console.WriteLine("Please enter a valid option (1-5)");
//                 break;
//         }
//     }