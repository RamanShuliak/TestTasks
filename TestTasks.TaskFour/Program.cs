using System.Diagnostics;

namespace TestTasks.TaskFour
{
    internal class Program
    {
        // Task 4.Высший сорт.
        static void Main(string[] args)
        {
            var list = GenerateTestInputStream();

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var sortedStream = Sort(list, 5, 2000);

            // Some test realization of data from sortedStream
            foreach (var item in sortedStream)
            {
                Console.WriteLine(item);
            }

            stopwatch.Stop();
            Console.WriteLine($"Sort method worked by {stopwatch.ElapsedMilliseconds} milliseconds.");
        }

        /// <summary>
        /// Возвращает отсортированный по возрастанию поток чисел
        /// </summary>
        /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
        /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
        /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
        /// <returns>Отсортированный по возрастанию поток чисел.</returns>
        public static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            var sortedStream = new List<int>();

            var minValue = 0;

            foreach (var item in inputStream)
            {
                if(sortedStream.Count < 1000000000)
                {
                    if (item >= minValue && item < (maxValue + 1) )
                    {
                        sortedStream.Add(item);

                        minValue = item - sortFactor;
                    }
                }
                else
                {
                    break;
                }
            }

            sortedStream.Sort();

            foreach (var item in sortedStream)
            {
                yield return item;
            }
        }

        public static List<int> GenerateTestInputStream()
        {
            Random rand = new Random();

            int[] array = new int[rand.Next(100, 1500000000)]; ;

            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(0, 3000);

            var list = array.ToList();

            return list;
        }
    }
}