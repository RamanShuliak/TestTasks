namespace TestTasks.TaskOne.FirstImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FailProcess();
            }
            catch { }

            Console.WriteLine("Failed to fail process!");
            Console.ReadKey();

        }

        static void FailProcess()
        {
            Console.WriteLine("FailProcess action start here.");

            Environment.Exit(0);
        }
    }
}