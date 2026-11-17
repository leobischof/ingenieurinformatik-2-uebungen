// Teilüberprüfung 1 – Training 4 – Lösung Task 1: lokale Maxima

namespace Teilueberpruefung_Training4
{
    public class TwoDimensionalArray
    {
        public static List<int> GetLocalMaxima(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> localMaxima = new List<int>();

            int zeilen = numbers.GetLength(0);
            int spalten = numbers.GetLength(1);

            for (int i = 0; i < zeilen; i++)
            {
                for (int j = 0; j < spalten; j++)
                {
                    int zahl = numbers[i, j];
                    bool istMaximum = true;

                    // jeden Nachbarn nur prüfen, wenn es ihn gibt (sonst sind wir am Rand)
                    if (i > 0 && numbers[i - 1, j] >= zahl)               // oben
                    {
                        istMaximum = false;
                    }
                    if (i < zeilen - 1 && numbers[i + 1, j] >= zahl)      // unten
                    {
                        istMaximum = false;
                    }
                    if (j > 0 && numbers[i, j - 1] >= zahl)               // links
                    {
                        istMaximum = false;
                    }
                    if (j < spalten - 1 && numbers[i, j + 1] >= zahl)     // rechts
                    {
                        istMaximum = false;
                    }

                    if (istMaximum)
                    {
                        localMaxima.Add(zahl);
                    }
                }
            }

            return localMaxima; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
