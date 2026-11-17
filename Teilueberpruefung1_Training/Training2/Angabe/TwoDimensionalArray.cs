namespace Teilueberpruefung_Training2
{
    public class TwoDimensionalArray
    {
        // Erweitern Sie den Code derart, dass die Zahlen im übergebenen 2D Array ('int[,] numbers') darauf überprüft werden,
        // ob sie Zahlen-Palindrome sind. Jedes gefundene Palindrom soll in die vorbereitete Liste ('List<int>') hinzugefügt werden.

        // Ein Zahlen-Palindrom ist eine Zahl, die von vorne und von hinten gelesen gleich ist (z.B. 121, 88, 1331).
        // Dazu wird die Zahl Ziffer für Ziffer "umgedreht" und danach mit der ursprünglichen Zahl verglichen:
        // Solange die Zahl größer als 0 ist, wird die letzte Ziffer (Zahl % 10) hinten an die umgedrehte Zahl angehängt
        // (umgedreht = umgedreht * 10 + letzteZiffer) und danach die Zahl durch 10 dividiert.

        // Beispiel für die Zahl 123:
        // umgedreht = 0 * 10 + 3 = 3,     Zahl = 12
        // umgedreht = 3 * 10 + 2 = 32,    Zahl = 1
        // umgedreht = 32 * 10 + 1 = 321,  Zahl = 0  -> fertig
        // 321 ist ungleich 123 -> KEIN Palindrom.

        // Tipp 1: der Modulo Operator ('%') gibt den Rest einer Division wieder.
        // Tipp 2: bei einer Division von zwei 'int' Werten fallen die Nachkommastellen automatisch weg.

        // Hinweis: einstellige Zahlen (kleiner als 10) zählen NICHT als Palindrom und sollen ausgeschlossen werden!

        // Übergabeparameter:   int[,] numbers          -> 2D Array von positiven ganzen Zahlen
        // Rückgabewert:        List<int> palindromes   -> Liste von gefundenen Palindromen (in der Reihenfolge Zeile für Zeile)

        public static List<int> GetPalindromeNumbers(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> palindromes = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                // Code hier schreiben...

            }

            return palindromes; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
