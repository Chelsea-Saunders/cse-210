using System;

class Program
{
    static void Main(string[] args)
    {
        // Add code to your Main function
        // Create a new job instance named job1
        Job job1 = new Job();

        // Set the member variables using hte dot notation (ex: job1_jobTitle = "Software Engineer";)
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // Varify that you can display the company of this job on the screen, again using the dot
        // notation to access the member variable.

        // Create a second job, set it's variables, display this company on the screen as well
        Job job2 = new Job();

        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        // Remove the lines of code where you displayed the company earlier and replace them with calls
        // to your new method. Remember that you call the method using the same dot dotation such as job1.Display();

        // Add the end of the main function, create a new instance for the Resume class
        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        // Add the two jobs you created earlier, to the list of jobs in the resume object.
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        // Varify that you can display the first job title using dot notation similar to myResume._jobs[0]._jobTitle
        myResume.Display();

    }
}