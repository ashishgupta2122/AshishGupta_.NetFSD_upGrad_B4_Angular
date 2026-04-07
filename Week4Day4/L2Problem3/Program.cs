using System;

class StudentResult
{
    public void CalculateResult(int m1, int m2, int m3, out int totalMarks, out double averageMarks)
    {
        totalMarks = m1 + m2 + m3;
        averageMarks = totalMarks / 3.0;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        StudentResult resultAnalyzer = new StudentResult();

        while (true)
        {
            Console.WriteLine("\nEnter marks for three subjects (0-100)");
            Console.Write("Subject 1: ");
            int m1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Subject 2: ");
            int m2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Subject 3: ");
            int m3 = Convert.ToInt32(Console.ReadLine());

            if (m1 < 0 || m1 > 100 || m2 < 0 || m2 > 100 || m3 < 0 || m3 > 100)
            {
                Console.WriteLine("Invalid marks! Please enter values between 0 and 100.");
                continue;
            }

            int total;
            double average;

            // Method call with out parameters
            resultAnalyzer.CalculateResult(m1, m2, m3, out total, out average);

            Console.WriteLine("Total Marks: " + total);
            Console.WriteLine("Average Marks: " + average);

            if (average >= 40)
            {
                Console.WriteLine("Result: Pass");
            }
            else
            {
                Console.WriteLine("Result: Fail");
            }

            Console.Write("\nDo you want to enter another student? (y/n): ");
            string choice = Console.ReadLine().ToLower();

            if (choice != "y")
                break;
        }
    }
}