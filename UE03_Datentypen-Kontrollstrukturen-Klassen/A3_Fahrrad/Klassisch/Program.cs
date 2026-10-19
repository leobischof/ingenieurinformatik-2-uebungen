// ============================================================================
// Ingenieurinformatik II – Übungsblock #3, Aufgabe 3: Erstes Objekt – Fahrrad
// (KLASSISCHE Version)
// ----------------------------------------------------------------------------
// Ziel:
//   - In Main zwei Objekte der vereinfachten Klasse "Fahrrad" (siehe Fahrrad.cs)
//     erzeugen, ihre Attribute setzen und beide Fahrräder ausgeben.
//   - Danach (wegen eines "Eingabefehlers") die Gangzahl eines Fahrrads ändern
//     und die korrigierten Informationen erneut ausgeben.
//
// Verwendete Konzepte:
//   - Klasse vs. Objekt, Instanziierung mit "new"
//   - Zugriff auf öffentliche Attribute mit dem Punkt-Operator (objekt.attribut)
//   - Zuweisungsoperator "=" zum Setzen/Ändern eines Attributs
//   - Zeilenumbruch "\n" innerhalb eines Strings (Hinweis der Angabe)
// ============================================================================

namespace UE03.A3.Fahrrad.Klassisch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // UTF-8-Ausgabe, damit "ä" in "Fahrräder"/"Gänge" korrekt erscheint
            // (die Windows-Konsole nutzt sonst eine alte Codepage, z. B. 850).
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ----------------------------------------------------------------
            // Zwei Objekte erzeugen (instanziieren)
            // ----------------------------------------------------------------
            // "Fahrrad fahrrad1" deklariert eine Variable vom Typ Fahrrad.
            // "new Fahrrad()" legt ein NEUES Objekt im Speicher an. Da die Klasse
            // keinen eigenen Konstruktor hat, verwendet C# automatisch den
            // parameterlosen Standardkonstruktor -> alle Felder haben ihre
            // Startwerte (brand = "", numberGears = 0).
            Fahrrad fahrrad1 = new Fahrrad();
            // Attribute setzen: Punkt-Operator + Zuweisung.
            fahrrad1.brand = "Cube";
            fahrrad1.numberGears = 18;

            Fahrrad fahrrad2 = new Fahrrad();
            fahrrad2.brand = "Trek";
            // Absichtlich FALSCHER Wert – simuliert den "Fehler bei der Dateneingabe".
            fahrrad2.numberGears = 21;

            // ----------------------------------------------------------------
            // Ausgabe beider Fahrräder (Attribute lesen)
            // ----------------------------------------------------------------
            // "\n" im String erzeugt einen Zeilenumbruch. Am Ende jedes Blocks
            // steht ein zusätzliches "\n", damit eine Leerzeile folgt.
            // (Detail: "\n" ist das Zeichen "Line Feed". WriteLine hängt dagegen
            // Environment.NewLine an – unter Windows "\r\n". In der Konsole sieht
            // beides gleich aus.)
            Console.WriteLine("Informationen zu den Fahrrädern:\n"
                + "Fahrrad 1: Marke: " + fahrrad1.brand + ", Anzahl der Gänge: " + fahrrad1.numberGears + "\n"
                + "Fahrrad 2: Marke: " + fahrrad2.brand + ", Anzahl der Gänge: " + fahrrad2.numberGears + "\n");

            // ----------------------------------------------------------------
            // Korrektur: Gangzahl von Fahrrad 2 ändern
            // ----------------------------------------------------------------
            // Weil das Feld public ist, genügt eine einfache Zuweisung – es braucht
            // keine Setter-Methode. Nur DIESES Objekt ändert sich; fahrrad1 bleibt
            // unverändert, denn jedes Objekt hat seine eigenen Attributwerte.
            fahrrad2.numberGears = 24;
            Console.WriteLine("Die Anzahl der Gänge von Fahrrad 2 wurde korrigiert.\n");

            Console.WriteLine("Aktualisierte Informationen zu den Fahrrädern:\n"
                + "Fahrrad 1: Marke: " + fahrrad1.brand + ", Anzahl der Gänge: " + fahrrad1.numberGears + "\n"
                + "Fahrrad 2: Marke: " + fahrrad2.brand + ", Anzahl der Gänge: " + fahrrad2.numberGears);

            // Hinweis: Die beiden Ausgabeblöcke sind fast gleich. Später (mit
            // Methoden und Arrays/Schleifen) würde man das in eine Methode bzw.
            // Schleife auslagern – die moderne Version zeigt, wie das aussieht.
        }
    }
}
