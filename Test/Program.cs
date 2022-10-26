using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double d = 100.0 / 3;
            int c = (int) Math.Ceiling(d);

            Console.WriteLine(d + " " + c);

        }
    }
}