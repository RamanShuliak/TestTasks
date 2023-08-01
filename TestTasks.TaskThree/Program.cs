namespace TestTasks.TaskThree
{
    internal class Program
    {
        // Task 3.Мне только спросить!
        static void Main(string[] args)
        {
            int[] values = { 1, 2, 3, 4, 5, 6, 7 };

            var result = values.EnumerateFromTail(5);

            // If we want to realize console output of IEnumerable collection
            // with only one it iteration, we can use two options:
            // First - made console output after each element adding for new collection (I chose that variant);
            // Second - realize specific fixed-size ring buffer
            // that will be filled with enumeration values
            // and returned when the EnumerateFromTail method is called.

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"({item.item} - {item.tail})");
            //}
        }
    }
}