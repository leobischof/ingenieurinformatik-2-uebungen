// ============================================================================
// Bestellposition.cs – "vereinfachte" Klasse für EIN bestelltes Gericht
// (KLASSISCHE Version)
// ----------------------------------------------------------------------------
// Warum eine eigene Klasse und nicht einfach das Gericht-Objekt der Speisekarte?
//   Ein bestelltes Gericht kann einen Sonderwunsch haben und kostet dann 10 % mehr
//   und braucht 5 Minuten länger. Diese geänderten Werte dürfen NICHT in das
//   Gericht der Speisekarte geschrieben werden (Referenztyp – siehe Gericht.cs),
//   sonst wäre der Burger für alle folgenden Bestellungen teurer.
//   Eine Bestellposition speichert daher ihre EIGENE Kopie der Werte:
//   Name, (ggf. erhöhter) Preis, (ggf. verlängerte) Zeit und den Sonderwunsch-Text.
// ============================================================================

namespace UE03.A4.Bestellsystem.Klassisch
{
    internal class Bestellposition
    {
        // Name des bestellten Gerichts (kopiert aus der Speisekarte).
        public string name = "";

        // Text des Sonderwunsches, z. B. "extra Käse".
        // Leerer Text "" bedeutet: kein Sonderwunsch.
        public string sonderwunsch = "";

        // Preis dieser Position in Euro (inkl. eventuellem Sonderwunsch-Aufschlag).
        // double wie in Gericht.cs (decimal wäre für Geld genauer, siehe dort).
        public double preis;

        // Zubereitungszeit dieser Position in Minuten (inkl. eventueller Zusatzzeit).
        public int zubereitungszeitMinuten;
    }
}
