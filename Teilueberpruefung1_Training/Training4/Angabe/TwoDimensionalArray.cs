namespace Teilueberpruefung_Training4
{
    public class TwoDimensionalArray
    {
        // Erweitern Sie den Code derart, dass im übergebenen 2D Array ('int[,] numbers') alle "lokalen Maxima" gesucht werden.
        // Jedes gefundene lokale Maximum soll in die vorbereitete Liste ('List<int>') hinzugefügt werden.

        // Eine Zahl ist ein lokales Maximum, wenn sie ECHT GRÖSSER ist als alle ihre direkten Nachbarn.
        // Direkte Nachbarn sind nur die Zahlen OBEN, UNTEN, LINKS und RECHTS (keine Diagonalen!).
        // Am Rand des Arrays gibt es weniger Nachbarn - es werden nur die Nachbarn verglichen, die tatsächlich existieren.

        // Beispiel mit dem Array aus Program.cs:
        //   { 1, 5, 2, 3 }
        //   { 4, 3, 8, 1 }
        //   { 9, 2, 1, 7 }
        // Die 8 (Zeile 1, Spalte 2) hat die Nachbarn 2 (oben), 1 (unten), 3 (links), 1 (rechts) -> lokales Maximum.
        // Die 9 (Zeile 2, Spalte 0) hat nur die Nachbarn 4 (oben) und 2 (rechts) -> lokales Maximum.
        // Die 4 (Zeile 1, Spalte 0) hat den Nachbarn 9 (unten) -> KEIN lokales Maximum.

        // Tipp 1: 'numbers.GetLength(0)' liefert die Anzahl der Zeilen, 'numbers.GetLength(1)' die Anzahl der Spalten.
        // Tipp 2: Prüfen Sie VOR dem Zugriff auf einen Nachbarn, ob der Index noch im Array liegt (z.B. i > 0 für "oben"),
        //         sonst gibt es eine 'IndexOutOfRangeException'.

        // Übergabeparameter:   int[,] numbers          -> 2D Array von ganzen Zahlen (muss NICHT quadratisch sein!)
        // Rückgabewert:        List<int> localMaxima   -> Liste der lokalen Maxima (in der Reihenfolge Zeile für Zeile)

        public static List<int> GetLocalMaxima(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> localMaxima = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    // Code hier schreiben...

                }
            }

            return localMaxima; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
