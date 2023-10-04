using System;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 0, 1, 2, 3, 4 };
            var i = a.Length - 1;
            while (i >= 0)
            {
                Console.WriteLine(a[i]);
                i--;
            }

            Array.Resize(ref a, a.Length);
        }
    }
}