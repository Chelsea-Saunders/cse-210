using System;
using System.Diagnostics;
// Create a new file for your Resume class. Each class hould be in its own file and the 
// file name should match the name of that class.

// Create the Resume class
public class Resume
{
    // Create the member variable for the person's name
    public string _name;

    // Create the member variable for the list of Jobs. (Hint: the data type for this should be
    // List<Job>, and it is probably easiest to initialize this to a new list right when you declare it)
    public List<Job> _jobs = new List<Job>();

    // Add a methos to display it's details This method should have no parameters, return nothing
    public void Display()
    {   
        // in the method body, you should display the person's name and then iterate through 
        // each Job instance in the list of jobs and display them. 
        // HINT: you can call ech job's Display method that you created earlier.
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // juse custom data type "Job" for this loop
        foreach (Job job in _jobs)
        {
            // call Display method on each job
            job.Display();
        }
    }
}