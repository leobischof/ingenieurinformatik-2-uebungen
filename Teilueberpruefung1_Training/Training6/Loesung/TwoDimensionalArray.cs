// Teilüberprüfung 1 – Training 6 – Lösung Task 1: Fibonacci-Zahlen mit rekursiver Hilfsmethode

namespace Teilueberpruefung_Training6
{
    public class TwoDimensionalArray
    {
        public static List<int> GetFibonacciNumbers(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> fibonacciNumbers = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    if (IsFibonacci(numbers[i, j]))
                    {
                        fibonacciNumbers.Add(numbers[i, j]);
                    }
                }
            }

            return fibonacciNumbers; // ACHTUNG! Return Statement muss unverändert bleiben!
        }

        /// <summary>Liefert die n-te Fibonacci-Zahl (rekursiv).</summary>
        static int Fibonacci(int n)
        {
            // Abbruchbedingung: die ersten beiden Zahlen sind fest
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }

            // sonst: Summe der beiden vorherigen Zahlen
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        /// <summary>Liefert true, wenn die Zahl in der Fibonacci-Folge vorkommt.</summary>
        static bool IsFibonacci(int number)
        {
            int n = 0;

            // die Folge so lange weiterrechnen, bis wir die Zahl erreicht oder überschritten haben
            while (Fibonacci(n) < number)
            {
                n++;
            }

            // genau getroffen -> Fibonacci-Zahl, übersprungen -> nicht
            return Fibonacci(n) == number;
        }
    }
}
