// ============================================================================
// Gericht.cs – ein Gericht der Speisekarte (MODERNE Version)
// ----------------------------------------------------------------------------
// "record" (C# 9+) mit "Primärkonstruktor": Die eine Zeile unten erzeugt
// automatisch eine Klasse mit drei Properties (Name, Preis,
// ZubereitungszeitMinuten), einem Konstruktor, Gleichheitsvergleich über die
// Werte und einem lesbaren ToString().
//
// Unterschied zur klassischen Version (vereinfachte Klasse mit public Feldern):
//   Die Properties eines solchen records sind "init-only" – nach dem Erzeugen
//   kann NIEMAND mehr den Preis eines Gerichts ändern. Das Problem der klassischen
//   Version ("Gericht ist ein Referenztyp – wer den Verweis hat, kann die
//   Speisekarte versehentlich verändern") ist damit vom Compiler ausgeschlossen:
//   gericht.Preis = 9m; wäre ein Compilerfehler.
//
// Warum decimal statt double für den Preis?
//   double speichert binär; Werte wie 0,1 oder 5,99 sind darin nicht exakt
//   darstellbar (0.1 + 0.2 == 0.30000000000000004). decimal rechnet im
//   Zehnersystem und bildet Cent-Beträge exakt ab – der Standard-Typ für Geld.
//   decimal-Literale brauchen das Suffix "m" (5.99m).
// ============================================================================

namespace UE03.A4.Bestellsystem.Modern;

public sealed record Gericht(string Name, decimal Preis, int ZubereitungszeitMinuten);
