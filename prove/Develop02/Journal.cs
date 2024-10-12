
public class Journal 
{
    //attribute/variable (list to store all journal entries in)
    public List<Entry> entries = new List<Entry>();

    //prompt generator instance
    private PromptGenerator promptGenerator;

    public void AddEntry()
    {
        //Get random prompt from PromptGenerator
        string selectPrompt = promptGenerator.GetRandomPrompt();

        //show user their random prompt and ask for their response
        Console.WriteLine("Journal prompt: " + selectPrompt);
        string userResponse = Console.ReadLine();

        //Get current date and time
        DateTime currentDate = DateTime.Now;

        //Create a new entry with the prompt, response and date
        Entry newEntry = new Entry
        {
            Prompt = selectPrompt, 
            Response = userResponse, 
            Date = currentDate
        };

        //Add this entry to the list of entries
        entries.Add(newEntry);
        Console.WriteLine($"Number of entries: {entries.Count}");
        Console.WriteLine("Entry added successfully.");
    }

    //constructor to initialize the PromptGenerator
    public Journal()
    {
        promptGenerator = new PromptGenerator();
    }
    public void Display()
    {
        Console.WriteLine("Display method called");
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\n");
            }
        }
    }
    //Method to save entries to a file
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var entry in entries)
            {
                string sanitizePrompt = entry.Prompt.Replace("\n", "").Replace("\r", "");
                string sanitizeResponse = entry.Response.Replace("\n", "").Replace("\r", "");

                writer.WriteLine($"{entry.Date}|{sanitizePrompt}|{sanitizeResponse}");  //{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }
        //Method ot load entries from file
    
    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            entries.Clear(); //clears current entries before loading new ones
            string[] lines = File.ReadAllLines(file);

            Console.WriteLine($"Reading {lines.Length} lines from file...");

            foreach (var line in lines)
            {
                Console.WriteLine($"Processing line: {line}");

                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry
                    {
                        Date = DateTime.Parse(parts[0]),
                        Prompt = parts[1],
                        Response = parts[2],
                    };
                    entries.Add(entry);
                    }
                }
            }

            if (entries.Count == 0)
            {
                Console.WriteLine("Journal loaded successfully.");
            }
    }      
}
<<<<<<< HEAD

=======
//Commit to github!!
>>>>>>> 34fd4d5 (Journal program submit)















    // //List of random prompts
    // private List<string> prompts = new List<string>

    // //function that adds an entry
    // //stub
    // public void AddEntry(Entry entry)
    // {
    //     // create an instance of entry
    //     // set the variables (like in program)
    //     // add it to 'entries" - at the top
    //     entries.Add(new Entry());
    //     Console.WriteLine("Entry added:  ");
    // }
    
    // public void DisplayAll()
    // {
    //     //display list of entries
    //     //loop through the list and print each one
    //     Console.WriteLine("Entries:  ");
    //     foreach (var entry in entries)
    //     {
    //         Console.WriteLine(entry);
    //     }
    // }

    // public void SaveToFile(string file)
    // {
    //     //hint in problem overview...under video...writing text files
    // }

    // public void LoadFromFile(string file)
    // {
    //     //retreiving data from file
    //     //hint under video...reading text files
    // }













// public class Journal 
// {
//     //attribute/variable
//     public List<Entry> entries = new List<Entry>();
//     //list is a class...built in

//     //function that adds an entry
//     //stub
//     public void AddEntry()
//     {
//         //create an instance of entry
//         //set the variables (like in program)
//         //add it to 'entries" - at the top
//     }
    
//     public void DisplayAll()
//     {
//         //display list of entries
//         //loop through the list and print each one
//     }

//     public void SaveToFile(string file)
//     {
//         //hint in problem overview...under video...writing text files
//     }

//     public void LoadFromFile(string file)
//     {
//         //retreiving data from file
//         //hint under video...reading text files
//     }
// }