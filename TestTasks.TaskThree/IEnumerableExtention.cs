using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTasks.TaskThree
{
    public static class IEnumerableExtention
    {
        /// <summary>
        /// <para> Отсчитать несколько элементов с конца </para>
        /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
        /// </summary> 
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
        /// <returns></returns>
        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            var items = new List<(T item, int? tail)>();

            var count = enumerable.Count();

            if (tailLength >= count)
            {
                foreach (var item in enumerable)
                {
                    items.Add((item, --count));

                    Console.WriteLine($"{item} - {count}");

                }
            }
            else
            {
                var i = 0;
                var resultOfSubtraction = count - tailLength;
                foreach (var item in enumerable)
                {
                    //items.Add((item, i >= resultOfSubtraction
                    //    ? --tailLength
                    //    : null));

                    if(i >= resultOfSubtraction)
                    {
                        items.Add((item, --tailLength));
                        Console.WriteLine($"({item} - {tailLength})");
                    }
                    else
                    {
                        items.Add((item, null));
                        Console.WriteLine($"({item} - {null})");
                    }

                    i++;
                }
            }
            return items;
        }
    }
}
