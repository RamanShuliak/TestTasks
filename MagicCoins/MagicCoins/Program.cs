namespace MagicCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the number of checks for each coin:");
            var numberOfCheks = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please, enter the number of magic coin:");
            var numberOfMagicCoins = Int32.Parse(Console.ReadLine());

            SortMagicCoins(numberOfCheks, numberOfMagicCoins);
        }

        public static void SortMagicCoins(int numberOfCheks, int numberOfMagicCoins)
        {
            var wonderfulCoinIsFounded = false;

            var numberOfSimpleCoins = 0;

            var random = new Random();

            for (var i = 1; i <= numberOfMagicCoins; i++)
            {
                if(!wonderfulCoinIsFounded)
                {
                    var numberOfTailsForThisCoin = 0;

                    for (var j = 0; j < numberOfCheks; j++)
                    {
                        var chek = random.Next(0, 2);

                        if (chek == 1)
                        {
                            numberOfTailsForThisCoin++;
                        }
                    }

                    var tailChanceForThisCoin = (double)(numberOfTailsForThisCoin) / numberOfCheks * 100;

                    if (tailChanceForThisCoin < 55 && tailChanceForThisCoin > 45)
                    {
                        numberOfSimpleCoins++;
                        Console.WriteLine($"Coin number {i} is one of the most regular.");

                        if(numberOfSimpleCoins == 4)
                        {
                            Console.WriteLine($"Coin number {i} is possibly wonderful, if the legend is to be believed.");

                            wonderfulCoinIsFounded = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Coin number {i} is very magic.");
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}