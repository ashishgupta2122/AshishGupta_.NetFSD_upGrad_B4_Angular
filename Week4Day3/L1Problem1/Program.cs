using System;

class Soln
{
    public static void Main(String[] args)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        int marks = int.Parse(Console.ReadLine());

        if (marks < 0 || marks > 100)
        {
            Console.WriteLine("Invalid Marks! Please Enter Marks b/w 0 and 100");
        }
        else
        {
            if (marks >= 90)
            {
                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: A");

            }
            else if (marks >= 80)
            {
                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: B");

            }
            else if (marks >= 70)
            {
                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: C");

            }
            else if (marks >= 60)
            {
                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: D");
            }
            else
            {
                Console.WriteLine("Student: " + name);
                Console.WriteLine("Grade: Fail");
            }
        }
    }
}