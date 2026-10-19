// =====================================================================================
// UE04 – Aufgabe 1: Multiplikationstabelle (klassische Version)
// -------------------------------------------------------------------------------------
// Ziel:
//   Das kleine Einmaleins (1..10 × 1..10) wird in einem ZWEIDIMENSIONALEN Array
//   gespeichert und danach rechtsbündig als Tabelle auf der Konsole ausgegeben.
//   Es gibt KEINE Kopfzeile und KEINE Kopfspalte – nur die Produkte selbst.
//
// Verwendete Konzepte (Lernziele UE3/UE4):
//   - 2D-Array (rechteckiges Array) int[,] und GetLength(0) / GetLength(1)
//   - verschachtelte for-Schleifen (äußere Schleife = Zeilen, innere = Spalten)
//   - Methoden mit Parametern und Rückgabewerten
//   - Konstanten statt "magischer Zahlen"
//   - rechtsbündige Formatierung mit int.ToString().PadLeft(...)
// =====================================================================================

namespace UE04.A1.Multiplikationstabelle.Klassisch
{
    internal class Program
    {
        // Größe der Tabelle: 10 bedeutet "von 1 bis 10".
        // Als Konstante, damit die Zahl nur an EINER Stelle steht (Single Source of Truth).
        // Will man das große Einmaleins (1..20), ändert man nur diese eine Zeile.
        private const int TabellenGroesse = 10;

        // Breite einer Tabellenzelle in Zeichen. Das größte Produkt ist 10 * 10 = 100
        // (3 Ziffern) – mit 4 Zeichen bleibt immer mindestens ein Leerzeichen als Abstand.
        private const int Zellenbreite = 4;

        static void Main(string[] args)
        {
            // Die Windows-Konsole verwendet standardmäßig eine alte Codepage (z. B. 850).
            // Mit UTF-8 werden Umlaute (ä, ö, ü) und Sonderzeichen korrekt dargestellt.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1) Daten erzeugen: Die Tabelle wird VOLLSTÄNDIG im Array gespeichert ...
            int[,] tabelle = ErstelleMultiplikationstabelle(TabellenGroesse);

            // 2) ... und erst danach ausgegeben. Berechnung und Ausgabe sind bewusst
            //    getrennt: So könnte man die Tabelle z. B. auch in eine Datei schreiben,
            //    ohne die Berechnung anzufassen.
            Console.WriteLine("Multiplikationstabelle von 1 bis " + TabellenGroesse + ":");
            Console.WriteLine();
            GibTabelleAus(tabelle);
        }

        /// <summary>
        /// Erstellt ein quadratisches 2D-Array, in dem an Position [zeile, spalte]
        /// das Produkt (zeile + 1) * (spalte + 1) steht.
        /// </summary>
        /// <param name="groesse">Anzahl der Zeilen bzw. Spalten (z. B. 10).</param>
        /// <returns>Das befüllte 2D-Array.</returns>
        static int[,] ErstelleMultiplikationstabelle(int groesse)
        {
            // WARUM int[,] und nicht int[][]?
            //   - int[,] ist ein RECHTECKIGES (mehrdimensionales) Array: ein einziger
            //     zusammenhängender Speicherblock, jede Zeile ist garantiert gleich lang.
            //     Das passt perfekt zu einer Tabelle mit fixer Zeilen- und Spaltenzahl.
            //   - int[][] wäre ein "jagged array" (verzweigtes Array): ein Array von
            //     Arrays, bei dem jede Zeile eine eigene Länge haben darf und einzeln
            //     angelegt werden muss. Das braucht man nur bei unterschiedlich langen
            //     Zeilen (z. B. ein Dreieck).
            int[,] tabelle = new int[groesse, groesse];

            // Array-Indizes beginnen in C# immer bei 0! Index 0 entspricht also der
            // Zahl 1, Index 9 der Zahl 10 – deshalb unten "+ 1".
            //
            // GetLength(0) liefert die Länge der 1. Dimension (Anzahl Zeilen),
            // GetLength(1) die Länge der 2. Dimension (Anzahl Spalten).
            // Achtung: tabelle.Length wäre die GESAMTZAHL der Elemente (hier 100)!
            for (int zeile = 0; zeile < tabelle.GetLength(0); zeile++)
            {
                // Verschachtelte Schleife: Für JEDE Zeile läuft die innere Schleife
                // einmal komplett über alle Spalten -> insgesamt 10 * 10 = 100 Durchläufe.
                for (int spalte = 0; spalte < tabelle.GetLength(1); spalte++)
                {
                    tabelle[zeile, spalte] = (zeile + 1) * (spalte + 1);
                }
            }

            return tabelle;
        }

        /// <summary>
        /// Gibt den Inhalt eines 2D-Arrays zeilenweise und rechtsbündig aus.
        /// </summary>
        /// <param name="tabelle">Das auszugebende 2D-Array.</param>
        static void GibTabelleAus(int[,] tabelle)
        {
            for (int zeile = 0; zeile < tabelle.GetLength(0); zeile++)
            {
                for (int spalte = 0; spalte < tabelle.GetLength(1); spalte++)
                {
                    // PadLeft(n) füllt einen String LINKS mit Leerzeichen auf, bis er
                    // n Zeichen lang ist -> die Zahl steht rechtsbündig, die Einer-,
                    // Zehner- und Hunderterstellen stehen sauber untereinander.
                    // Console.Write (ohne "Line") bleibt in derselben Zeile.
                    Console.Write(tabelle[zeile, spalte].ToString().PadLeft(Zellenbreite));
                }

                // Nach der letzten Spalte einer Zeile: Zeilenumbruch.
                Console.WriteLine();
            }
        }
    }
}
