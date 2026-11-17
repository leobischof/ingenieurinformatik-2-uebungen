// Teilüberprüfung 1 – Training 3 – Lösung Task 1: vollkommene Zahlen

namespace Teilueberpruefung_Training3
{
    public class TwoDimensionalArray
    {
        public static List<int> GetPerfectNumbers(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> perfectNumbers = new List<int>();

            // GetLength(0) = Anzahl Zeilen, GetLength(1) = Anzahl Spalten
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    int zahl = numbers[i, j];

                    // 0 und 1 (und negative Zahlen) ausschließen
                    if (zahl <= 1)
                    {
                        continue;
                    }

                    // alle echten Teiler aufsummieren
                    int teilerSumme = 0;
                    for (int teiler = 1; teiler < zahl; teiler++)
                    {
                        if (zahl % teiler == 0)
                        {
                            teilerSumme = teilerSumme + teiler;
                        }
                    }

                    if (teilerSumme == zahl)
                    {
                        perfectNumbers.Add(zahl);
                    }
                }
            }

            return perfectNumbers; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
