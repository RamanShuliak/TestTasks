using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sentence:");
            string s = Console.ReadLine();

            var numberOfS = 0;

            var numberOfH = 0;

            var numberOfE = 0;

            var numberOfR = 0;

            var numberOfI = 0;

            var numberOfF = 0;

            var numberOfF2 = 0;

            foreach (var symbol in s)
            {
                if (symbol == 's')
                {
                    numberOfS++;
                }
                else if (symbol == 'h')
                {
                    numberOfH++;
                }
                else if (symbol == 'e')
                {
                    numberOfE++;
                }
                else if (symbol == 'r')
                {
                    numberOfR++;
                }
                else if (symbol == 'i')
                {
                    numberOfI++;
                }
                else if (symbol == 'f')
                {
                    if(numberOfF2 < numberOfF)
                    {
                        numberOfF2++;
                    }
                    else
                    {
                        numberOfF++;
                    }
                }
            }

            var numbersOfSymbolsList = new List<int>();
            numbersOfSymbolsList.Add(numberOfS);
            numbersOfSymbolsList.Add(numberOfH);
            numbersOfSymbolsList.Add(numberOfE);
            numbersOfSymbolsList.Add(numberOfR);
            numbersOfSymbolsList.Add(numberOfI);
            numbersOfSymbolsList.Add(numberOfF);
            numbersOfSymbolsList.Add(numberOfF2);

            numbersOfSymbolsList.OrderByDescending(x => x);

            int result = 0;

            foreach (var number in numbersOfSymbolsList)
            {
                if (number > 0)
                {
                    result = number;
                }
                else
                {
                    Console.WriteLine(0);
                    Process.GetCurrentProcess().Kill();
                }
            }

            Console.WriteLine(result);
        }
    }
}