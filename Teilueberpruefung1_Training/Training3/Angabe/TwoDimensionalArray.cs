namespace Teilueberpruefung_Training3
{
    public class TwoDimensionalArray
    {
        // Erweitern Sie den Code derart, dass die Zahlen im übergebenen 2D Array ('int[,] numbers') darauf überprüft werden,
        // ob sie vollkommene Zahlen sind. Jede gefundene vollkommene Zahl soll in die vorbereitete Liste ('List<int>') hinzugefügt werden.

        // Eine Zahl ist vollkommen, wenn die Summe aller ihrer echten Teiler genau die Zahl selbst ergibt.
        // Echte Teiler sind alle ganzen Zahlen von 1 bis (Zahl - 1), durch die die Zahl OHNE Rest teilbar ist.

        // Beispiel für die Zahl 6:
        // echte Teiler: 1, 2, 3 (6 % 4 und 6 % 5 haben einen Rest)  -> Summe = 1 + 2 + 3 = 6  -> vollkommen!
        // Beispiel für die Zahl 12:
        // echte Teiler: 1, 2, 3, 4, 6  -> Summe = 16  -> NICHT vollkommen.

        // Tipp: der Modulo Operator ('%') gibt den Rest einer Division wieder.

        // Hinweis: Zahlen kleiner oder gleich 1 sind NIE vollkommen und sollen ausgeschlossen werden
        //          (Achtung: bei 0 wäre die Teilersumme 0 und damit "gleich der Zahl"!).

        // Übergabeparameter:   int[,] numbers              -> 2D Array von ganzen Zahlen
        // Rückgabewert:        List<int> perfectNumbers    -> Liste von gefundenen vollkommenen Zahlen (in der Reihenfolge Zeile für Zeile)

        public static List<int> GetPerfectNumbers(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> perfectNumbers = new List<int>();

            // Code hier schreiben...


            return perfectNumbers; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
