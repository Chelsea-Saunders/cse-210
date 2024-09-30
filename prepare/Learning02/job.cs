
using System;
// Create a class (Hint this is the public class Job syntax)
public class Job
{
    // Create member variables in the class for each element that the class should contain
    // by convention these member variable should begin with an underscore and a lower case
    // letter such as _jobTitle.
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // Return to your Job.cs file and add a methos (member function) to display the job details.
    // This method should not have any parameters and does not need to return anything
    // By convention, this method should beging with a capitla letter such as Display nad if you have
    // Multiple words each word should be capitalized, such as DisplayJobDetails.

    // This method should display the job details on the screen in the correct format. Remember
    // that the method can access the member variables directly without needing them to be passed into it.
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear} - {_endYear}");
    }
}