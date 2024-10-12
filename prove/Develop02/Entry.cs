

public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

<<<<<<< HEAD
// directions to try from tutor:
=======
//commit to github
>>>>>>> 34fd4d5 (Journal program submit)

//     //attributes
//     public string date; 
//     public string promptText;
//     public string entryText;

//     public void Display()
//     {
//         //display all the attributes
//         Console.WriteLine(date);
//         Console.WriteLine(promptText);
//         Console.WriteLine(entryText);
        
//     }
// }