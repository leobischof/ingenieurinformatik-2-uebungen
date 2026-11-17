namespace Teilueberpruefung_Training1
{
    public class TwoDimensionalArray
    {
        // Erweitern Sie den Code derart, dass für jede Zahl im übergebenen 2D Array ('int[,] numbers') die Quersumme berechnet wird.
        // Jede Zahl, deren Quersumme GERADE ist, soll in die vorbereitete Liste ('List<int>') hinzugefügt werden.

        // Die Quersumme ist die Summe aller Ziffern einer Zahl. Sie kann folgendermaßen berechnet werden:
        // Solange die Zahl größer als 0 ist, wird die letzte Ziffer (Rest der Division durch 10) zur Summe addiert
        // und danach die Zahl durch 10 dividiert (Ganzzahldivision -> die letzte Ziffer fällt weg).

        // Beispiel für die Zahl 58:
        // 58 % 10 = 8  -> Summe = 8,  58 / 10 = 5
        //  5 % 10 = 5  -> Summe = 13,  5 / 10 = 0  -> fertig
        // Die Quersumme 13 ist ungerade -> 58 wird NICHT hinzugefügt.

        // Tipp 1: der Modulo Operator ('%') gibt den Rest einer Division wieder.
        // Tipp 2: bei einer Division von zwei 'int' Werten fallen die Nachkommastellen automatisch weg (z.B. 58 / 10 = 5).

        // Hinweis: Achten Sie darauf, dass Sie die Zahl im Array NICHT verändern - rechnen Sie mit einer Kopie!
        // Hinweis: Es kommen nur positive Zahlen vor.

        // Übergabeparameter:   int[,] numbers              -> 2D Array von ganzen Zahlen
        // Rückgabewert:        List<int> evenDigitSums     -> Liste von Zahlen mit gerader Quersumme (in der Reihenfolge Zeile für Zeile)

        public static List<int> GetNumbersWithEvenDigitSum(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> evenDigitSums = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                // Code hier schreiben...

            }

            return evenDigitSums; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
