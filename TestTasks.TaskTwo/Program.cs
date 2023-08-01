using System.Globalization;

namespace TestTasks.TaskTwo
{
    internal partial class Program
    {
        // Task 2.Операция «Ы».

        static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

        public class Number
        {
            readonly int _number;

            public Number(int number)
            {
                _number = number;
            }

            public override string ToString()
            {
                return _number.ToString(_ifp);
            }

            public static Number operator +(Number number1, int number2)
            {
                return new Number(number1._number + number2);
            }
        }

        static void Main(string[] args)
        {
            int someValue1 = 10;
            int someValue2 = 5;

            // We get a string as a result of executing the original code.
            // If we want to change it, we need to do overload of + operator.
            string result = new Number(someValue1) + someValue2.ToString(_ifp);
            Console.WriteLine(result);

            string result2 = (new Number(someValue1) + someValue2).ToString();
            Console.WriteLine(result2);

            Console.ReadKey();
        }

    }
}