public class Word
{
    private string _singleWord;

    //private field to hold the hidden status
    private bool _isHidden;

    //constructor to intialize the word and hidden status
    public Word(string singleWord, bool isHidden = false)
    {
        _singleWord = singleWord;
        _isHidden = isHidden;
    }

    public bool GetIsHidden()
    {
        // GetIsHidden get the isHidden variable/attribute
        return _isHidden;
    }

    public void SetIsHidden(bool isHidden) // this is what it takes to call this function...recipe
    {
        _isHidden = isHidden; // setting the isHidden value
    }

    public string GetSingleWord()
    {
        return _isHidden ? "_____" : _singleWord;
    }
}