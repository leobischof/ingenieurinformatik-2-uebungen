namespace Teilueberpruefung_Training5
{
    public class TwoDimensionalArray
    {
        // Erweitern Sie den Code derart, dass im übergebenen 2D Array ('int[,] numbers') alle PRIMZAHLEN gesucht werden.
        // Jede gefundene Primzahl soll in die vorbereitete Liste ('List<int>') hinzugefügt werden.

        // Eine Primzahl ist eine ganze Zahl größer als 1, die nur durch 1 und durch sich selbst teilbar ist.
        // Beispiele: 2, 3, 5, 7, 11, 13 sind Primzahlen - 0, 1, 4, 9, 15 sind KEINE Primzahlen.

        // Schreiben Sie dafür eine eigene statische Hilfsmethode 'static bool IsPrime(int number)' in dieser Klasse,
        // die 'true' liefert, wenn 'number' eine Primzahl ist, und rufen Sie diese in der Schleife auf.

        // Tipp 1: 'a % b == 0' bedeutet: a ist ohne Rest durch b teilbar.
        // Tipp 2: Es reicht, die Teiler von 2 bis 'number - 1' zu probieren.

        // Übergabeparameter:   int[,] numbers          -> 2D Array von ganzen Zahlen
        // Rückgabewert:        List<int> primeNumbers  -> Liste der Primzahlen (in der Reihenfolge Zeile für Zeile)

        public static List<int> GetPrimeNumbers(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> primeNumbers = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    // Code hier schreiben...

                }
            }

            return primeNumbers; // ACHTUNG! Return Statement muss unverändert bleiben!
        }

        // Hilfsmethode hier schreiben...

    }
}
