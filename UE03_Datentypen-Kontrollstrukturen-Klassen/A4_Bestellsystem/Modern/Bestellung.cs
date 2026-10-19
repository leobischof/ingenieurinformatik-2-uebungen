// ============================================================================
// Bestellung.cs – die gesamte Bestellung eines Kunden (MODERNE Version)
// ----------------------------------------------------------------------------
// Unterschied zur klassischen "vereinfachten" Klasse:
//   - Kapselung: Die Liste ist PRIVAT. Von außen kann man nur über
//     Hinzufuegen(...) Positionen ergänzen und über Positionen (schreibgeschützte
//     Sicht, IReadOnlyList) lesen – niemand kann die Liste z. B. leeren.
//   - Gesamtpreis und maximale Zubereitungszeit sind BERECHNETE Properties (LINQ
//     Sum/Max). Sie sind damit immer aktuell und können nicht "vergessen" werden
//     – klassisch mussten sie in einer Schleife berechnet und gespeichert werden.
// ============================================================================

namespace UE03.A4.Bestellsystem.Modern;

public sealed class Bestellung
{
    // Collection-Expression "[]" (C# 12) = neue, leere Liste.
    private readonly List<Bestellposition> _positionen = [];

    public IReadOnlyList<Bestellposition> Positionen => _positionen;

    public bool IstLeer => _positionen.Count == 0;

    public void Hinzufuegen(Bestellposition position) => _positionen.Add(position);

    // LINQ Sum: addiert für jede Position p den Wert p.Preis.
    public decimal Gesamtpreis => _positionen.Sum(p => p.Preis);

    // LINQ Max liefert die LÄNGSTE Zeit (nicht die Summe – die Küche kocht parallel).
    // Max wirft bei einer leeren Liste eine Ausnahme -> vorher abfangen.
    public int MaximaleZubereitungszeitMinuten =>
        IstLeer ? 0 : _positionen.Max(p => p.ZubereitungszeitMinuten);
}
