using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment student1 = new Assignment("John Doe", "Diagrams");
        Console.WriteLine(student1.GetSummary());

        MathAssignment mathAssignment1 = new MathAssignment("John Doe", "Fractions", "Section 4.3", "12-34, 36");
        Console.WriteLine(mathAssignment1.GetHomeworkList());

        WritingAssignment writingAssignment1 = new WritingAssignment("Jane Doe", "Inheritance Learning Activity", "Inheritance in C#");
        Console.WriteLine(writingAssignment1.GetWritingInformation());
    }
}