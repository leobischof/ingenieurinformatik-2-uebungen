// ============================================================================
// Bestellung.cs – "vereinfachte" Klasse für die gesamte Bestellung eines Kunden
// (KLASSISCHE Version)
// ----------------------------------------------------------------------------
// Attribute (laut Angabe "nach eigener Meinung"):
//   - positionen:                alle bestellten Gerichte
//   - gesamtpreis:               Summe aller Positionspreise
//   - maximaleZubereitungszeit:  längste Zubereitungszeit (NICHT die Summe – die
//                                Küche bereitet die Gerichte parallel zu)
//
// Warum List<Bestellposition> und kein Array?
//   Ein Array hat eine FESTE Größe, die man beim Anlegen kennen muss. Wie viele
//   Gerichte ein Kunde bestellt, weiß man aber vorher nicht. Mit einem Array
//   bräuchte man ein "ausreichend großes" Array, einen extra Zähler für die
//   belegten Plätze und eine Prüfung, ob das Array schon voll ist. Eine List<T>
//   wächst automatisch mit: Add(...) hängt hinten an, Count liefert die Anzahl,
//   positionen[i] greift (wie beim Array) auf das i-te Element zu. Für Anfänger
//   ist das klarer und weniger fehleranfällig.
//   <Bestellposition> in spitzen Klammern legt fest, welchen Typ die Elemente
//   haben – die Liste nimmt nur Bestellposition-Objekte an.
//
// Hinweis: gesamtpreis und maximaleZubereitungszeit lassen sich eigentlich aus den
// Positionen berechnen. Eine vereinfachte Klasse hat aber keine Methoden, darum
// berechnet Program.cs die Werte am Ende der Bestellung und speichert sie hier.
// (Die moderne Version berechnet sie stattdessen über Properties.)
// ============================================================================

namespace UE03.A4.Bestellsystem.Klassisch
{
    internal class Bestellung
    {
        // "= new List<Bestellposition>()" legt die (anfangs leere) Liste gleich beim
        // Erzeugen der Bestellung an. Ohne diesen Startwert wäre das Feld null und
        // der erste Add-Aufruf würde abstürzen (NullReferenceException).
        public List<Bestellposition> positionen = new List<Bestellposition>();

        // Summe in Euro (double – siehe Hinweis zu decimal in Gericht.cs).
        public double gesamtpreis;

        // Längste Zubereitungszeit aller Positionen in Minuten.
        public int maximaleZubereitungszeit;
    }
}
