using System;
using System.Collections.Generic;

public class Scripture
{
    private List<string> scriptureText = new List<string>();
    private List<int> hiddenWordIndices = new List<int>();

    //create a public property to get and set the scripture text and reference
    public Reference ReferenceObject { get; set; }
    public string ScriptureText
    {
        set 
        {
            scriptureText = new List<string>(value.Split(' '));
        }
    }
    public Scripture (Reference reference)
    {
        this.ReferenceObject = reference;
    }

    //method to print each word in the scripture
    public void DisplayVerse()
    {
        // _reference.DisplayReference();

        // foreach (string word in scriptureText)
        // {
        //     Console.Write(word + " ");
        // }
        // Console.WriteLine();
        
        //Display reference
        ReferenceObject.DisplayReference();
        
        for (int i = 0; i < scriptureText.Count; i++)
        {
            if (hiddenWordIndices.Contains(i))
            {
                Console.Write("____ ");
            }
            else{
                Console.Write(scriptureText[i] + " ");
            }
        }
        Console.WriteLine();
    }
    

   public void HideWord(int count = 3) 
   {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < count && hiddenWordIndices.Count < scriptureText.Count) 
        {
            //get random word index
            int index = random.Next(scriptureText.Count);

            // check if word is already hidden
            if (!hiddenWordIndices.Contains(index)) //add to list
            {
                hiddenWordIndices.Add(index);
                hiddenCount++;
            }
        }
    }
   
   public bool IsCompletelyHidden()
   {
    return hiddenWordIndices.Count == scriptureText.Count; //return false = place holder
   }
}