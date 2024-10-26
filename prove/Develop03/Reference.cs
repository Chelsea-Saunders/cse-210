public class Reference
{
    private string _book;

    private string _chapter;

    private string _verse;
    
    private string _endVerse;

    //default constructor
    public Reference()
    {
        //create a reference with no values
        _book = "Unknown";
        _chapter = "0";
        _verse = "0";
        _endVerse = null; //default value = null
    }
    
    //One verse constructor
    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null; //no end verse
    }

    //multiple verse constructor (verse to endVerse)
    public Reference (string book, string chapter, string verse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse; //this will show the ending verse
    }

    public void DisplayReference()
    {
        if (string.IsNullOrEmpty(_endVerse))
        {
            //display single verse
            Console.WriteLine($"{_book} {_chapter}:{_verse}");
        }
        else
        {
            //display multiple verses
            Console.WriteLine($"{_book} {_chapter}:{_verse}-{_endVerse}");
        }  
    }
}