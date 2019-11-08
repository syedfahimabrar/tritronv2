using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("env is ");
            Console.WriteLine(Environment.GetEnvironmentVariable("TritronTemp"));
        }
    }
}
