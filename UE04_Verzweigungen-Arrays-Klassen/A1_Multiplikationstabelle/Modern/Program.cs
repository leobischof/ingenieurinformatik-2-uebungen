// =====================================================================================
// UE04 – Aufgabe 1: Multiplikationstabelle (moderne Version, C# 12 / .NET 8)
// -------------------------------------------------------------------------------------
// Ziel:
//   Gleiche Funktion wie die klassische Version: das Einmaleins 1..10 wird in einem
//   2D-Array gespeichert und rechtsbündig ohne Kopfzeile/-spalte ausgegeben.
//
// Was ist hier "modern"?
//   - Top-Level-Statements: kein namespace/class/Main-Gerüst nötig – der Compiler
//     erzeugt die Klasse Program und die Main-Methode automatisch.
//   - String-Interpolation mit Alignment: $"{wert,4}" richtet rechtsbündig auf
//     4 Zeichen aus (entspricht wert.ToString().PadLeft(4)).
//   - Enumerable.Range + LINQ (Select) + string.Concat statt einer inneren Schleife
//     für die Ausgabe einer Zeile.
//   - static local functions: Hilfsfunktionen direkt in Program.cs, "static"
//     verhindert, dass sie versehentlich lokale Variablen von oben mitbenutzen.
//
// Was bleibt bewusst gleich?
//   - Die Angabe schreibt ein 2D-Array vor -> wir verwenden weiterhin int[,]
//     (und kein int[][] oder List<List<int>>).
//   - Befüllt wird mit verschachtelten for-Schleifen: Für das Schreiben in ein
//     2D-Array ist das nach wie vor die klarste Form; LINQ kann keine int[,] erzeugen.
// =====================================================================================

// Umlaute/Sonderzeichen in der Windows-Konsole korrekt darstellen (Standard ist
// eine alte Codepage wie 850, die "ü" falsch anzeigen würde).
Console.OutputEncoding = System.Text.Encoding.UTF8;

// const in Top-Level-Statements = lokale Konstante: steht nur an EINER Stelle.
const int TabellenGroesse = 10; // "von 1 bis 10"

int[,] tabelle = ErstelleMultiplikationstabelle(TabellenGroesse);

Console.WriteLine($"Multiplikationstabelle von 1 bis {TabellenGroesse}:");
Console.WriteLine();
GibTabelleAus(tabelle);

// -------------------------------------------------------------------------------------
// Lokale Funktionen (müssen in Top-Level-Programmen NACH den Anweisungen stehen)
// -------------------------------------------------------------------------------------

// Erstellt ein groesse × groesse großes 2D-Array mit tabelle[z, s] = (z + 1) * (s + 1).
// int[,] ist ein rechteckiges Array (ein Speicherblock, alle Zeilen gleich lang) –
// genau das, was eine Tabelle ist. int[][] ("jagged") bräuchte man nur für Zeilen
// unterschiedlicher Länge.
static int[,] ErstelleMultiplikationstabelle(int groesse)
{
    var tabelle = new int[groesse, groesse];

    // GetLength(0) = Anzahl Zeilen, GetLength(1) = Anzahl Spalten.
    // (tabelle.Length wäre die Gesamtzahl aller Elemente, hier 100.)
    for (var zeile = 0; zeile < tabelle.GetLength(0); zeile++)
    {
        for (var spalte = 0; spalte < tabelle.GetLength(1); spalte++)
        {
            // Indizes starten bei 0 -> "+ 1", damit die Tabelle bei 1 beginnt.
            tabelle[zeile, spalte] = (zeile + 1) * (spalte + 1);
        }
    }

    return tabelle;
}

// Gibt das 2D-Array zeilenweise aus. Pro Zeile baut LINQ die Zellen zusammen:
//   Enumerable.Range(0, n)        -> 0, 1, ..., n-1 (die Spaltenindizes)
//   .Select(s => $"{wert,4}")     -> jede Zahl rechtsbündig auf 4 Zeichen
//   string.Concat(...)            -> alle Zellen ohne Trennzeichen hintereinander
static void GibTabelleAus(int[,] tabelle)
{
    // Breite 4: größtes Produkt 100 hat 3 Ziffern + 1 Leerzeichen Abstand.
    const int Zellenbreite = 4;

    for (var zeile = 0; zeile < tabelle.GetLength(0); zeile++)
    {
        var zeilenText = string.Concat(
            Enumerable.Range(0, tabelle.GetLength(1))
                      .Select(spalte => $"{tabelle[zeile, spalte],Zellenbreite}"));

        // $"{wert,Zellenbreite}" ist das moderne Gegenstück zu
        // wert.ToString().PadLeft(Zellenbreite) aus dem Hinweis der Angabe:
        // positive Breite = rechtsbündig, negative Breite = linksbündig.
        // Die Breite muss eine KONSTANTE sein – deshalb "const int" oben.
        Console.WriteLine(zeilenText);
    }
}
