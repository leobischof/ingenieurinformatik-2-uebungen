// Teilüberprüfung 1 – Training 8 – Lösung Task 1: ggT jeder Zeile mit rekursiver Hilfsmethode

namespace Teilueberpruefung_Training8
{
    public class TwoDimensionalArray
    {
        public static List<int> GetRowGcds(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> rowGcds = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                // mit der ersten Zahl der Zeile anfangen
                int ggt = numbers[i, 0];

                // dann Schritt für Schritt mit jeder weiteren Zahl den ggT bilden
                for (int j = 1; j < numbers.GetLength(1); j++)
                {
                    ggt = Gcd(ggt, numbers[i, j]);
                }

                rowGcds.Add(ggt);
            }

            return rowGcds; // ACHTUNG! Return Statement muss unverändert bleiben!
        }

        /// <summary>Berechnet den ggT von zwei Zahlen rekursiv (Euklid).</summary>
        static int Gcd(int a, int b)
        {
            // Abbruchbedingung: kein Rest mehr -> a ist der ggT
            if (b == 0)
            {
                return a;
            }

            // sonst mit b und dem Rest weiterrechnen
            return Gcd(b, a % b);
        }
    }
}
