using static System.Net.Mime.MediaTypeNames;

namespace TestTasks.TaskFive
{
    internal class Program
    {
        // Task 5.Слон из мухи.
        static void Main(string[] args)
        {
            TransformToElephant();
            Console.WriteLine("Fly");

            CustomAppCode();
        }

        static void TransformToElephant()
        {
            Console.WriteLine("Elephant");
            Console.SetOut(new MyWriter());
        }

        static void CustomAppCode()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}