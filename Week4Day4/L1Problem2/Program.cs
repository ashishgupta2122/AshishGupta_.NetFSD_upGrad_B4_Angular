using System;

class Student
{
    public double CalculateAverage(int m1, int m2, int m3)
    {
        double avg = (m1 + m2 + m3) / 3.0;
        return avg;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter Marks 1: ");
        int m1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Marks 2: ");
        int m2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Marks 3: ");
        int m3 = Convert.ToInt32(Console.ReadLine());

        Student s1 = new Student();

        double avg = s1.CalculateAverage(m1, m2, m3);
        string grade;

        if (avg >= 90)
        {
            grade = "A";
        }
        else if (avg >= 75)
        {
            grade = "B";
        }
        else if (avg >= 60)
        {
            grade = "C";
        }
        else
        {
            grade = "Fail";
        }

        Console.WriteLine("Average = " + avg);
        Console.WriteLine("Grade = " + grade);

    }
}