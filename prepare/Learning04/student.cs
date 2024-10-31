using System;

class Student{
    private string _studentName;

    public Student(string studentName)
    {
        _studentName = studentName;
    }
    public string GetStudentName()
    {
        return _studentName;
    }

    public void SetStudentName(string studentName)
    {
        _studentName = studentName;
    }

    public string GetStudent()
    {
        return $"{_studentName}";
    }
}