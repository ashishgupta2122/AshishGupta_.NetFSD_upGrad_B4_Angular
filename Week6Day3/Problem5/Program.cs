using System;

namespace Problem5
{
    class Program
    {
        public static void Main(string[] args)
        {
            var config1 = ConfigurationManager.GetInstance();

            Console.WriteLine("First Call:");
            Console.WriteLine(config1.ApplicationName);
            Console.WriteLine(config1.Version);
            Console.WriteLine(config1.DatabaseConnectionString);

            Console.WriteLine();

            var config2 = ConfigurationManager.GetInstance();

            Console.WriteLine("Second Call:");
            Console.WriteLine(config2.ApplicationName);
            Console.WriteLine(config2.Version);
            Console.WriteLine(config2.DatabaseConnectionString);

            Console.WriteLine();

            Console.WriteLine("Same Instance? " + (config1 == config2));

        }
    }
}