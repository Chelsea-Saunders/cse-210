


using System.Diagnostics;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        //declare scripture object
        Scripture scripture = null;
        string scriptureText = "";

        //input users own scripture or default one
        Console.WriteLine("Would you like to input your own scripture or use the one provided? 'enter'or 'provided' ");
        string scriptureChoice = Console.ReadLine().ToLower();

        if (scriptureChoice == "enter")
        {
            // ask for scripture reference
            Console.WriteLine("Enter the book of the scripture:  ");
            string book = Console.ReadLine();
            // if (!string.IsNullOrEmpty(book))
            // {
            //     book = char.ToUpper(book[0]) + book.Substring(1).ToLower();
            // }

            Console.WriteLine("Enter the chapter of the scripture:  ");
            string chapter = Console.ReadLine();

            Console.WriteLine("Enter the verse of the scripture:  ");
            string verse = Console.ReadLine();

            string endVerse = null;

            Console.WriteLine("is there more than one verse? 'yes' or 'no':  ");
            string moreThanOneVerse = Console.ReadLine().ToLower();

            if (moreThanOneVerse == "yes")
            {
                Console.WriteLine("Enter the number of the last verse:  ");
                endVerse = Console.ReadLine();
            }

            Console.WriteLine("Enter the scripture text:  ");
            scriptureText = Console.ReadLine();

            //create reference on whether there's more than one verse
            Reference userReference;
            if (string.IsNullOrEmpty(endVerse))
            {
                userReference = new Reference(book, chapter, verse);
            }
            else
            {
                userReference = new Reference(book, chapter, verse, endVerse);
            }

            // create scripture object
            scripture = new Scripture(userReference);
            scripture.ScriptureText = scriptureText;

            // scripture.userReference();
            scripture.DisplayVerse();

        }
        else if (scriptureChoice == "provided")
        {
            // prompt user for single or multiple verses
            Console.WriteLine("Enter 'single' for a single verse or 'multiple' for multiple verses.");
            string choice = Console.ReadLine().ToLower();

            if (choice == "single")
            {
                //single verse
                Reference singleVerseReference = new Reference("Doctrine and Covenants", "84", "88");
                scripture = new Scripture(singleVerseReference);

                //text for single verse        
                scriptureText = "And whoso receiveth you, there I will be also, for I will go before your face. I will be on your right hand and on your left, and my Spirit shall be in your hearts, and mine angels round about you, to bear you up.";
                scripture.ScriptureText = scriptureText;
                scripture.DisplayVerse();
            }
        else if (choice == "multiple")
        {
            //multiple verses
            Reference multipleVerseReference = new Reference ("Doctrine and Covenants", "84", "88", "90");
            scripture = new Scripture(multipleVerseReference);

            scriptureText = "88 And whoso receiveth you, there I will be also, for I will go before your face. I will be on your right hand and on your left, and my Spirit shall be in your hearts, and mine angels round about you, to bear you up."+
                            "89 Whoso receiveth you receiveth me; and the same will feed you, and clothe you, and give you money."+
                            "90 And he who feeds you, or clothes you, or gives you money, shall in nowise lose his reward.";
            scripture.ScriptureText = scriptureText;
            scripture.DisplayVerse();
        }
        else{
            Console.WriteLine("Invalid choice, type 'single' or 'multiple'.");
            return;
        }
    }
        else
        {
            Console.WriteLine("Invalid choice, type 'enter' or 'provided'.  ");
            return;
        }
        
        //create a loop so "enter" hides 3 more words on single verse 
        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press 'Enter' to hide 3 words, and 'Exit' to quit the program.");
            string input = Console.ReadLine();

            //quit?
            if (input.ToLower() == "exit")
            {
                break;
            }

            //hide 3 words
            scripture.HideWord(3);

            //clear display and update with new hidden words
            Console.Clear();
            scripture.DisplayVerse();
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine("All words are hidden.");
        }
    }
}


// i got a lot of help in the outline from a tutor and then worked 
//with ai/chatgpt to figure out what i was doing. By the end I was amazed i 
//actually felt like I was getting the hand of some of it....i have a long way to go!!
// https://chatgpt.com/share/671c517a-ac0c-800b-ab3a-9acfe26110f9
//https://chatgpt.com/c/671be21b-c9cc-800b-bbfb-74dce7e1ae5f