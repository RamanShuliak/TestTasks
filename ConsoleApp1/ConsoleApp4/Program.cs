using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter amount of money, that Jo need, and number of banknotes of each nomination:");

            string[] input = Console.ReadLine().Split();

            int n = int.Parse(input[0]);

            int m = int.Parse(input[1]);

            Console.WriteLine("Enter all nominations of banknotes in this bank:");

            var nominations = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            var allBanknotesWithNominations = new List<int>();
            allBanknotesWithNominations.AddRange(nominations);
            allBanknotesWithNominations.AddRange(nominations);

            allBanknotesWithNominations.Sort();

            var k = 0;

            var stolenAmountOfMoney = 0;

            var stolenBanknotes = new List<int>();

            var uses = 0;

            foreach (int banknote in allBanknotesWithNominations)
            {
                while(stolenAmountOfMoney <= n && k <= allBanknotesWithNominations.Count && uses == 0)
                {
                    stolenAmountOfMoney += banknote;
                    k++;
                    stolenBanknotes.Add(banknote);
                    uses++;

                    if (stolenAmountOfMoney == n)
                    {
                        Console.WriteLine("Answer:");
                        Console.WriteLine(k);
                        foreach(var stolenBanknote in stolenBanknotes)
                        {
                            Console.Write(stolenBanknote + " ");
                        }

                        Process.GetCurrentProcess().Kill();
                    }

                    if(stolenAmountOfMoney > n)
                    {
                        foreach(var i in stolenBanknotes)
                        {
                            while(stolenAmountOfMoney > n)
                            {
                                stolenAmountOfMoney -= i;

                                stolenBanknotes.RemoveAt(0);

                                k--;

                                if (stolenAmountOfMoney == n)
                                {
                                    Console.WriteLine("Answer:");
                                    Console.WriteLine(k);
                                    foreach (var stolenBanknote in stolenBanknotes)
                                    {
                                        Console.Write(stolenBanknote + " ");
                                    }

                                    Process.GetCurrentProcess().Kill();
                                }
                            }
                            break;
                        }
                    }
                }

                uses = 0;
            }
            Console.WriteLine("Answer:");
            Console.WriteLine(-1);
        }
    }
}