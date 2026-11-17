// Teilüberprüfung 1 – Training 2 – Lösung Task 1: Zahlen-Palindrome

namespace Teilueberpruefung_Training2
{
    public class TwoDimensionalArray
    {
        public static List<int> GetPalindromeNumbers(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> palindromes = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    int zahl = numbers[i, j];

                    // einstellige Zahlen sind laut Angabe ausgeschlossen
                    if (zahl < 10)
                    {
                        continue;
                    }

                    // Zahl Ziffer für Ziffer umdrehen (mit einer Kopie, das Original brauchen wir noch)
                    int rest = zahl;
                    int umgedreht = 0;
                    while (rest > 0)
                    {
                        umgedreht = umgedreht * 10 + rest % 10;
                        rest = rest / 10;
                    }

                    // vorwärts gleich rückwärts -> Palindrom
                    if (umgedreht == zahl)
                    {
                        palindromes.Add(zahl);
                    }
                }
            }

            return palindromes; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
