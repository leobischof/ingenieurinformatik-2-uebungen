// Teilüberprüfung 1 – Training 1 – Lösung Task 1: Quersumme

namespace Teilueberpruefung_Training1
{
    public class TwoDimensionalArray
    {
        public static List<int> GetNumbersWithEvenDigitSum(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> evenDigitSums = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                // zweite Schleife geht durch die Spalten der Zeile i
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    // mit einer Kopie rechnen, damit die Zahl selbst erhalten bleibt
                    int rest = numbers[i, j];
                    int quersumme = 0;

                    // letzte Ziffer dazuzählen und dann abschneiden
                    while (rest > 0)
                    {
                        quersumme = quersumme + rest % 10;
                        rest = rest / 10;
                    }

                    // gerade = Rest 0 bei Division durch 2
                    if (quersumme % 2 == 0)
                    {
                        evenDigitSums.Add(numbers[i, j]);
                    }
                }
            }

            return evenDigitSums; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
