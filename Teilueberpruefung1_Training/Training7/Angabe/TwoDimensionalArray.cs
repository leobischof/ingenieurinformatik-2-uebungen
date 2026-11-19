namespace Teilueberpruefung_Training7
{
    public class TwoDimensionalArray
    {
        // Erweitern Sie den Code derart, dass im übergebenen 2D Array ('int[,] numbers') alle ARMSTRONG-ZAHLEN gesucht werden.
        // Jede gefundene Armstrong-Zahl soll in die vorbereitete Liste ('List<int>') hinzugefügt werden.

        // Eine positive Zahl mit n Stellen ist eine Armstrong-Zahl, wenn die Summe ihrer Ziffern, jeweils hoch n genommen,
        // wieder die Zahl selbst ergibt. Negative Zahlen und 0 sind KEINE Armstrong-Zahlen.
        //   153  -> 3 Stellen: 1^3 + 5^3 + 3^3       = 1 + 125 + 27        = 153   -> Armstrong-Zahl
        //   1634 -> 4 Stellen: 1^4 + 6^4 + 3^4 + 4^4 = 1 + 1296 + 81 + 256 = 1634  -> Armstrong-Zahl
        //   7    -> 1 Stelle:  7^1                   = 7                         -> Armstrong-Zahl
        //   12   -> 2 Stellen: 1^2 + 2^2             = 5                         -> KEINE Armstrong-Zahl

        // Schreiben Sie dafür eigene statische Hilfsmethoden in dieser Klasse, mindestens:
        //   1) 'static int CountDigits(int number)'           -> Anzahl der Stellen einer positiven Zahl
        //   2) 'static int Power(int baseNumber, int exponent)' -> baseNumber hoch exponent, OHNE 'Math.Pow' (mit einer Schleife)

        // Tipp: 'number % 10' liefert die letzte Ziffer, 'number / 10' schneidet die letzte Ziffer ab (Ganzzahldivision).

        // Übergabeparameter:   int[,] numbers              -> 2D Array von ganzen Zahlen
        // Rückgabewert:        List<int> armstrongNumbers  -> Liste der Armstrong-Zahlen (in der Reihenfolge Zeile für Zeile)

        public static List<int> GetArmstrongNumbers(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> armstrongNumbers = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    // Code hier schreiben...

                }
            }

            return armstrongNumbers; // ACHTUNG! Return Statement muss unverändert bleiben!
        }

        // Hilfsmethoden hier schreiben...

    }
}
