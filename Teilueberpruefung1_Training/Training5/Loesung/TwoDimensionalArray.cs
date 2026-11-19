// Teilüberprüfung 1 – Training 5 – Lösung Task 1: Primzahlen mit eigener Hilfsmethode

namespace Teilueberpruefung_Training5
{
    public class TwoDimensionalArray
    {
        public static List<int> GetPrimeNumbers(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> primeNumbers = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    // die Prüfung macht die Hilfsmethode, hier nur noch aufrufen
                    if (IsPrime(numbers[i, j]))
                    {
                        primeNumbers.Add(numbers[i, j]);
                    }
                }
            }

            return primeNumbers; // ACHTUNG! Return Statement muss unverändert bleiben!
        }

        /// <summary>Liefert true, wenn die Zahl eine Primzahl ist.</summary>
        static bool IsPrime(int number)
        {
            // 0, 1 und negative Zahlen sind keine Primzahlen
            if (number < 2)
            {
                return false;
            }

            // sobald ein Teiler gefunden wird, ist es keine Primzahl
            for (int teiler = 2; teiler < number; teiler++)
            {
                if (number % teiler == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
