using System.Diagnostics;

namespace TestTasks.TaskOne.ThirdImplementation
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

            Environment.FailFast("Application finished here.");

            // Here we can use any different kind of logic, that throws an exception,
            // instead Environment.FailFast().
            // Because each exception terminates the process without proper handling in the cath block.
            // For example: DivideByZeroException, FormatException, NullReferenceException, etc.
        }
    }
}