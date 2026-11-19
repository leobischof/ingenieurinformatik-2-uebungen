namespace Teilueberpruefung_Training8
{
    public class TwoDimensionalArray
    {
        // Erweitern Sie den Code derart, dass für JEDE ZEILE des übergebenen 2D Arrays ('int[,] numbers') der größte
        // gemeinsame Teiler (ggT) ALLER Zahlen dieser Zeile berechnet wird.
        // Der ggT jeder Zeile soll in die vorbereitete Liste ('List<int>') hinzugefügt werden - die Liste hat also
        // genau so viele Einträge wie das Array Zeilen hat.

        // Beispiel: Zeile { 12, 18, 24 } -> ggT(12, 18) = 6, danach ggT(6, 24) = 6 -> Ergebnis 6.

        // Schreiben Sie dafür eine eigene statische Hilfsmethode 'static int Gcd(int a, int b)', die den ggT von ZWEI Zahlen
        // REKURSIV mit dem Euklidischen Algorithmus berechnet:
        //   - Ist b == 0, dann ist der ggT gleich a.
        //   - Sonst gilt: ggT(a, b) = ggT(b, a % b).
        // Den ggT einer ganzen Zeile erhält man, indem man die Hilfsmethode Schritt für Schritt mit dem bisherigen Ergebnis
        // und der nächsten Zahl aufruft.

        // Tipp: Das Gerüst hat hier nur EINE Schleife über die Zeilen - die Schleife über die Spalten schreiben Sie selbst.

        // Übergabeparameter:   int[,] numbers      -> 2D Array von positiven ganzen Zahlen (jede Zeile hat mindestens 1 Zahl)
        // Rückgabewert:        List<int> rowGcds   -> Liste mit dem ggT jeder Zeile (Zeile 0 zuerst)

        public static List<int> GetRowGcds(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> rowGcds = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                // Code hier schreiben...

            }

            return rowGcds; // ACHTUNG! Return Statement muss unverändert bleiben!
        }

        // Hilfsmethode hier schreiben...

    }
}
