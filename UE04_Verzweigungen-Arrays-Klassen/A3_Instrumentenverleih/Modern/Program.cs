// =====================================================================================
// UE04 – Aufgabe 3: Instrumentenverleih – Hauptprogramm (moderne Version)
// -------------------------------------------------------------------------------------
// Ziel: wie klassisch – Inventar anzeigen, per Seriennummer ausleihen, Eingaben
// prüfen; Ende bei "e", wenn nichts mehr verfügbar ist, oder bei Eingabeende (EOF).
//
// Was ist hier "modern"?
//   - Top-Level-Statements, static local functions
//   - Collection-Expression für das Instrumenten-Array
//   - LINQ: Any(), FirstOrDefault(), All()
//   - Pattern Matching: "is null", "is not { } instrument"
//   - String-Interpolation mit Alignment: {wert,-30} = linksbündig auf 30 Zeichen
//   - string.Equals(..., StringComparison.OrdinalIgnoreCase) statt ToLower()-Vergleich
// =====================================================================================

using UE04.A3.Instrumentenverleih.Modern;

// Umlaute/Sonderzeichen in der Windows-Konsole korrekt darstellen.
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Lokale Konstanten (Single Source of Truth für Befehl und Spaltenbreiten).
// Spaltenbreiten MÜSSEN Konstanten sein, damit sie im Alignment {x,Breite} stehen dürfen.
const string BeendenBefehl = "e";
const int BreiteBezeichnung = 30;
const int BreiteSeriennummer = 12;
const string Spaltentrenner = "| ";

// Vier Instrumente, direkt befüllt. Array statt List<T>, weil die Anzahl fix ist
// und die Angabe ein Array verlangt.
Instrument[] instrumente =
[
    new("Yamaha YCL Klarinette", "494773"),
    new("Olds Recording Trompete", "324385"),
    new("Stradivari Geige", "654435"),
    new("Pearl Roadshow Schlagzeug", "847473"),
];

Console.WriteLine("Willkommen beim Instrumentenverleih!");
Console.WriteLine();
ZeigeInventar(instrumente);

// while(true) + break: drei gleichwertige Abbruchgründe, jeder mit eigener Meldung.
// break verlässt sofort die innerste Schleife.
while (true)
{
    // Abbruch 1: Nichts mehr verfügbar -> automatisches Ende (laut Angabe).
    if (!instrumente.Any(instrument => instrument.IstVerfuegbar))
    {
        Console.WriteLine("Alle Instrumente sind verliehen. Das Programm wird automatisch beendet.");
        break;
    }

    // ReadLine() liefert null bei Eingabeende (EOF, z. B. umgeleitete Eingabe ist
    // aufgebraucht). Ohne diesen Abbruch liefe die Schleife endlos.
    // "?." ruft Trim() nur auf, wenn nicht null – sonst bleibt das Ergebnis null.
    var eingabe = LiesZeile()?.Trim();

    // Abbruch 2: Eingabeende.
    if (eingabe is null)
    {
        Console.WriteLine();
        Console.WriteLine("Keine weitere Eingabe vorhanden. Das Programm wird beendet.");
        break;
    }

    // Abbruch 3: manuelles Beenden mit "e" (Groß-/Kleinschreibung egal).
    if (eingabe.Equals(BeendenBefehl, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Sie haben das Programm beendet.");
        break;
    }

    // Nur nach ERFOLGREICHEM Verleih wird das Inventar erneut aufgelistet.
    if (VersucheZuVerleihen(instrumente, eingabe))
    {
        Console.WriteLine();
        ZeigeInventar(instrumente);
    }
}

// -------------------------------------------------------------------------------------
// Lokale Funktionen
// -------------------------------------------------------------------------------------

// Liest eine Zeile; bei umgeleiteter Eingabe (Pipe/Datei) wird sie zusätzlich
// ausgegeben, damit ein Testprotokoll wie eine echte Sitzung aussieht.
static string? LiesZeile()
{
    var zeile = Console.ReadLine();
    if (zeile is not null && Console.IsInputRedirected)
    {
        Console.WriteLine(zeile);
    }
    return zeile;
}

// Prüft die Eingabe mit Guard-Clauses und verleiht bei Erfolg das Instrument.
static bool VersucheZuVerleihen(Instrument[] instrumente, string eingabe)
{
    // Fehler 1: keine Zahl. All(char.IsAsciiDigit) prüft JEDES Zeichen auf 0–9
    // (IsAsciiDigit statt IsDigit, weil IsDigit auch z. B. arabische Ziffern akzeptiert).
    // Ein leerer String würde All() bestehen ("alle 0 Zeichen sind Ziffern") –
    // deshalb zusätzlich die Längenprüfung.
    if (eingabe.Length == 0 || !eingabe.All(char.IsAsciiDigit))
    {
        Console.WriteLine($"Ungültige Eingabe: Bitte geben Sie eine Seriennummer (nur Ziffern) oder {BeendenBefehl} ein.");
        return false;
    }

    // Fehler 2: unbekannte Seriennummer.
    // FirstOrDefault liefert das erste passende Element oder null.
    // "is not { } instrument" = "ist null" ODER, falls nicht null, wird es in die
    // Variable instrument (Typ Instrument, nicht nullable) übernommen.
    if (instrumente.FirstOrDefault(i => i.Seriennummer == eingabe) is not { } instrument)
    {
        Console.WriteLine($"Es gibt kein Instrument mit der Seriennummer {eingabe}.");
        return false;
    }

    // Fehler 3: bereits verliehen – die Regel prüft das Objekt selbst.
    if (!instrument.Verleihen())
    {
        Console.WriteLine($"Das Instrument {instrument.Name} ({instrument.Seriennummer}) ist bereits verliehen. "
            + "Bitte wählen Sie ein anderes Instrument.");
        return false;
    }

    Console.WriteLine($"Sie haben {instrument.Name} ausgeliehen. Vielen Dank.");
    return true;
}

// Hinweistext + Tabelle "Bezeichnung | Seriennummer | Status".
// {x,-30}: negatives Alignment = linksbündig, mit Leerzeichen auf 30 Zeichen aufgefüllt.
// Der enum-Status wird automatisch per ToString() als "ReadyToRent"/"RentedOut" ausgegeben.
static void ZeigeInventar(IEnumerable<Instrument> instrumente)
{
    // Die Überschrift "Seriennummer" steht über dem Trenner, ihre Spalte ist also um
    // die Länge von "| " breiter. Spaltentrenner.Length ist keine Compile-Zeit-
    // Konstante und darf daher nicht ins Alignment {x,...} -> hier PadRight.
    var seriennummerKopf = "Seriennummer".PadRight(BreiteSeriennummer + Spaltentrenner.Length);

    Console.WriteLine("Hier sind unsere verfügbaren Instrumente. Bitte geben Sie die Seriennummer "
        + "des Instruments an, das Sie entlehnen möchten.");
    Console.WriteLine($"Wenn Sie das Programm beenden möchten, drücken Sie {BeendenBefehl}.");
    Console.WriteLine();
    Console.WriteLine($"{"Bezeichnung",-BreiteBezeichnung}{seriennummerKopf}Status");
    Console.WriteLine();

    foreach (var instrument in instrumente)
    {
        Console.WriteLine(
            $"{instrument.Name,-BreiteBezeichnung}{Spaltentrenner}{instrument.Seriennummer,-BreiteSeriennummer}{Spaltentrenner}{instrument.Status}");
    }

    Console.WriteLine();
}
