// ============================================================================
// Bestellposition.cs – EIN bestelltes Gericht, optional mit Sonderwunsch
// (MODERNE Version)
// ----------------------------------------------------------------------------
// Unterschied zur klassischen Version:
//   Klassisch werden Name, Preis und Zeit in die Position KOPIERT und dort
//   erhöht. Hier merkt sich die Position nur das (unveränderliche) Gericht und
//   den Sonderwunsch; Preis und Zeit werden bei Bedarf daraus BERECHNET
//   (berechnete Properties mit "=>"). Es gibt also keine zweite, eventuell
//   abweichende Kopie der Werte – und das Gericht der Speisekarte bleibt
//   garantiert unverändert, weil der record Gericht unveränderlich ist.
//
// "string? Sonderwunsch": null bedeutet "kein Sonderwunsch". Das "?" macht im
// Typ sichtbar, dass der Wert fehlen darf (statt eines "magischen" Leertexts "").
// ============================================================================

namespace UE03.A4.Bestellsystem.Modern;

public sealed record Bestellposition(Gericht Gericht, string? Sonderwunsch = null)
{
    // Sonderwunsch-Regeln: genau einmal definiert (const -> unveränderlich).
    public const decimal SonderwunschPreisfaktor = 1.10m; // +10 %
    public const int SonderwunschZusatzminuten = 5;

    public bool HatSonderwunsch => Sonderwunsch is not null;

    // Bedingungsoperator "Bedingung ? A : B" = kompaktes if/else, das einen Wert liefert.
    public decimal Preis => HatSonderwunsch
        ? Gericht.Preis * SonderwunschPreisfaktor
        : Gericht.Preis;

    public int ZubereitungszeitMinuten => HatSonderwunsch
        ? Gericht.ZubereitungszeitMinuten + SonderwunschZusatzminuten
        : Gericht.ZubereitungszeitMinuten;

    // Anzeigetext für die Zusammenfassung, z. B. "Burger (extra Käse)".
    public string Bezeichnung => HatSonderwunsch
        ? $"{Gericht.Name} ({Sonderwunsch})"
        : Gericht.Name;
}
