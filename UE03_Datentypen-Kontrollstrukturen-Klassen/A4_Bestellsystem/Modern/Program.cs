// ============================================================================
// Ingenieurinformatik II – Übungsblock #3, Aufgabe 4: Bestellsystem
// (MODERNE Version)
// ----------------------------------------------------------------------------
// Ziel: identisch zur klassischen Version – Begrüßung, Speisekarte, Gerichte
// wählen (optional mit Sonderwunsch: +10 % Preis, +5 Minuten), mit 0 abschließen,
// danach Zusammenfassung (Gerichte, Gesamtpreis, LÄNGSTE Zubereitungszeit).
//
// Was ist hier "modern"?
//   - Top-Level-Statements, file-scoped namespaces in den Klassendateien
//   - records (Gericht, Bestellposition) mit unveränderlichen Properties
//   - decimal für Geldbeträge (exakt im Zehnersystem)
//   - Collection-Expression [ ... ] für die Speisekarte (Array)
//   - Lokale Funktionen mit nullable Rückgabe (null = Eingabe zu Ende, EOF)
//   - Pattern Matching ("is not int auswahl"), Switch-Ausdrücke mit "or"
//   - LINQ (Select, Sum, Max) und string.Join statt Zählschleifen
// ============================================================================

using UE03.A4.Bestellsystem.Modern;

// UTF-8-Ausgabe: Die Windows-Konsole (Codepage 850) zeigt "€" sonst als "?"
// (genau das sieht man im Screenshot der Angabe).
Console.OutputEncoding = System.Text.Encoding.UTF8;

const int AuswahlAbschliessen = 0;

// Speisekarte als Array. "new(...)" ruft den Primärkonstruktor des records auf
// (Typ ergibt sich aus Gericht[]). Das "m" macht die Literale zu decimal.
Gericht[] speisekarte =
[
    new("Burger", 5.99m, 15),
    new("Pizza", 7.99m, 20),
    new("Salat", 4.49m, 10),
];

Console.WriteLine("Willkommen im Restaurant! Hier ist unsere Speisekarte:");
// Select mit Index: liefert zu jedem Gericht auch seine Position (0, 1, 2).
// {..:C} = Währungsformat der eingestellten Culture (de-DE: "5,99 €", de-AT: "€ 5,99").
foreach (string zeile in speisekarte.Select((gericht, index) => $"{index + 1}. {gericht.Name} - {gericht.Preis:C}"))
{
    Console.WriteLine(zeile);
}

Bestellung bestellung = new();

// Bestellschleife: läuft, bis der Kunde 0 wählt (break) oder die Eingabe endet (return).
while (true)
{
    // EOF-Schutz: Jede Lese-Funktion liefert null, wenn Console.ReadLine() null
    // liefert (Strg+Z bzw. umgeleitete Eingabe zu Ende). Ohne diese Prüfungen
    // würde das Programm endlos auf eine Eingabe warten, die nie kommt.
    // "is not int auswahl" prüft auf null UND legt bei Erfolg die Variable an.
    if (LiesGerichtauswahl(speisekarte.Length) is not int auswahl)
    {
        BrichWegenEingabeendeAb();
        return;
    }

    if (auswahl == AuswahlAbschliessen)
    {
        break;
    }

    // Menünummern beginnen bei 1, Array-Indizes bei 0.
    Gericht gericht = speisekarte[auswahl - 1];

    if (LiesJaNein("Haben Sie einen Sonderwunsch? (ja/nein):") is not bool hatSonderwunsch)
    {
        BrichWegenEingabeendeAb();
        return;
    }

    string? sonderwunsch = null;
    if (hatSonderwunsch)
    {
        sonderwunsch = LiesNichtLeerenText("Geben Sie Ihren Sonderwunsch ein:");
        if (sonderwunsch is null)
        {
            BrichWegenEingabeendeAb();
            return;
        }
    }

    // Die Position verweist auf das unveränderliche Gericht der Speisekarte;
    // Aufpreis und Zusatzzeit werden in Bestellposition berechnet, nicht gespeichert.
    bestellung.Hinzufuegen(new Bestellposition(gericht, sonderwunsch));
}

// ---------------------------------------------------------------------------
// Bestellzusammenfassung
// ---------------------------------------------------------------------------
if (bestellung.IstLeer)
{
    Console.WriteLine("Sie haben nichts bestellt. Auf Wiedersehen!");
    return;
}

Console.WriteLine("Ihre Bestellung:");
// string.Join setzt ",\n" nur ZWISCHEN die Einträge -> kein Komma nach dem letzten.
Console.WriteLine(string.Join(",\n", bestellung.Positionen.Select(p => p.Bezeichnung)));
Console.WriteLine();
Console.WriteLine($"Gesamtpreis: {bestellung.Gesamtpreis:C}");
Console.WriteLine($"Maximale Zubereitungszeit: {bestellung.MaximaleZubereitungszeitMinuten} Minuten");

// ============================================================================
// Lokale Funktionen
// "static": greifen auf keine Variablen des umgebenden Codes zu (nur Konstanten
// und Parameter) – dadurch sind sie in sich abgeschlossen und leicht verständlich.
// ============================================================================

static void BrichWegenEingabeendeAb() =>
    Console.WriteLine("Keine weitere Eingabe vorhanden – die Bestellung wird abgebrochen.");

// Fragt so lange, bis eine Zahl von 0 bis anzahlGerichte eingegeben wird.
static int? LiesGerichtauswahl(int anzahlGerichte)
{
    while (true)
    {
        Console.WriteLine($"Bitte wählen Sie ein Gericht (1-{anzahlGerichte}) oder {AuswahlAbschliessen}, um die Bestellung abzuschließen:");
        string? text = Console.ReadLine();
        if (text is null)
        {
            return null;
        }

        // "out int auswahl" deklariert die Variable direkt im Aufruf.
        // Hinweis: Ein relationales Muster wie "auswahl is >= 0 and <= 3" ginge nur
        // mit KONSTANTEN Grenzen – anzahlGerichte ist ein Parameter, darum hier
        // normale Vergleichsoperatoren mit && (UND).
        if (int.TryParse(text, out int auswahl) && auswahl >= AuswahlAbschliessen && auswahl <= anzahlGerichte)
        {
            return auswahl;
        }

        Console.WriteLine($"Ungültige Eingabe. Bitte geben Sie eine Zahl von {AuswahlAbschliessen} bis {anzahlGerichte} ein.");
    }
}

// Fragt so lange, bis "ja"/"nein" (auch "j"/"n", Groß-/Kleinschreibung egal) kommt.
static bool? LiesJaNein(string frage)
{
    while (true)
    {
        Console.WriteLine(frage);
        string? antwort = Console.ReadLine();
        if (antwort is null)
        {
            return null;
        }

        // Switch-Ausdruck mit "or"-Mustern; "_" = jede andere Eingabe.
        bool? entscheidung = antwort.Trim().ToLowerInvariant() switch
        {
            "ja" or "j" => true,
            "nein" or "n" => false,
            _ => null,
        };

        if (entscheidung is not null)
        {
            return entscheidung;
        }

        Console.WriteLine("Bitte antworten Sie mit \"ja\" oder \"nein\".");
    }
}

// Fragt so lange, bis ein nicht-leerer Text eingegeben wird.
static string? LiesNichtLeerenText(string frage)
{
    while (true)
    {
        Console.WriteLine(frage);
        string? text = Console.ReadLine()?.Trim(); // "?." : Trim nur, wenn nicht null
        if (text is null)
        {
            return null;
        }

        // string.IsNullOrWhiteSpace wäre die Alternative; nach Trim genügt die Längenprüfung.
        if (text.Length > 0)
        {
            return text;
        }

        Console.WriteLine("Der Sonderwunsch darf nicht leer sein.");
    }
}
