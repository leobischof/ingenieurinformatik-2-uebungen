// ============================================================================
// Gericht.cs – "vereinfachte" Klasse für ein Gericht der Speisekarte
// (KLASSISCHE Version)
// ----------------------------------------------------------------------------
// Ein Gericht-Objekt beschreibt einen Eintrag der Speisekarte: Name, Preis und
// Zubereitungszeit. "Vereinfacht" heißt: nur öffentliche Attribute (Felder), kein
// selbst geschriebener Konstruktor, keine Getter/Setter, keine Methoden.
//
// WICHTIG – Klassen sind REFERENZTYPEN:
//   Eine Variable vom Typ Gericht enthält nicht das Gericht selbst, sondern nur
//   einen Verweis ("Referenz", vergleichbar mit einer Adresse) auf das Objekt im
//   Speicher. Schreibt man "Gericht g = burger;", zeigen g und burger danach auf
//   DASSELBE Objekt; "g.preis = 9;" ändert also auch burger.preis!
//   Deshalb verändert das Bestellsystem die Gerichte der Speisekarte NIE, sondern
//   kopiert die Werte in eine eigene Bestellposition (siehe Program.cs).
// ============================================================================

namespace UE03.A4.Bestellsystem.Klassisch
{
    internal class Gericht
    {
        // Name des Gerichts, z. B. "Burger". Startwert "" statt null, weil die
        // Nullable-Prüfung des Compilers sonst warnt (string ohne ? darf nie null sein).
        public string name = "";

        // Preis in Euro.
        // Warum double? Das ist der Kommazahl-Typ aus der Vorlesung. Für GELDBETRÄGE
        // wäre eigentlich "decimal" besser: double speichert Zahlen binär, darum
        // ist z. B. 0,1 nicht exakt darstellbar (0.1 + 0.2 ergibt 0.30000000000000004).
        // decimal rechnet im Zehnersystem und bildet Cent-Beträge exakt ab – siehe
        // die moderne Version. Für die Ausgabe auf 2 Nachkommastellen genügt double hier.
        public double preis;

        // Zubereitungszeit in ganzen Minuten -> int (keine Nachkommastellen nötig).
        public int zubereitungszeitMinuten;
    }
}
