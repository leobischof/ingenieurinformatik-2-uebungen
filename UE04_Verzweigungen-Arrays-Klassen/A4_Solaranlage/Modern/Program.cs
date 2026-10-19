// =====================================================================================
// UE04 – Aufgabe 4: Leistungsübersicht einer Solaranlage – Hauptprogramm
//                   (moderne Version)
// -------------------------------------------------------------------------------------
// Ziel: wie klassisch – Anlage instanziieren, Menü bis zur Eingabe 0, Menüpunkt 3
// ermittelt zusätzlich die schwächste Reihe; ungültige Eingaben und EOF abfangen.
//
// Was ist hier "modern"?
//   - Top-Level-Statements, static local functions (Klasse: file-scoped namespace)
//   - switch-AUSDRUCK, der jeder Eingabe eine Aktion (Action-Delegate) zuordnet
//   - Pattern Matching: "eingabe is null or MenueBeenden"
//   - LINQ MinBy für die schwächste Reihe
//   - String-Interpolation mit Format und Alignment: {wert:F2}, {text,-16}
// =====================================================================================

using UE04.A4.Solaranlage.Modern;

// Umlaute/Sonderzeichen (ä in "Schwächste") in der Windows-Konsole korrekt darstellen.
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Anlagendaten laut Angabe.
const string Standort = "Dach Halle A";
const int Modulnennleistung = 400; // W

// Menüpunkte als Konstanten. Als string, weil wir die Eingabe direkt vergleichen:
// Alles, was nicht exakt "0".."3" ist (auch "abc" oder "7"), ist ungültig – ein
// int.TryParse ist dafür nicht nötig.
const string MenueBeenden = "0";
const string MenueAnlageAnzeigen = "1";
const string MenueGesamtleistung = "2";
const string MenueReihenleistung = "3";

// Instanziierung: aus der Klasse (Bauplan) wird ein konkretes Objekt.
var anlage = new Solaranlage(Standort, Modulnennleistung);

// Endlosschleife mit break statt do-while: Die Abbruchbedingung (0 oder EOF) steht
// so direkt dort, wo die Eingabe geprüft wird. Das Menü erscheint trotzdem
// mindestens einmal – derselbe Effekt wie do-while in der klassischen Version.
while (true)
{
    ZeigeMenue();
    Console.Write("Auswahl: ");
    var eingabe = LiesZeile()?.Trim();

    // ReadLine() liefert null bei Eingabeende (EOF). Ohne diesen Abbruch würde das
    // Menü endlos erscheinen, weil jeder weitere Lesevorgang wieder null liefert.
    if (eingabe is null)
    {
        Console.WriteLine();
        Console.WriteLine("Keine weitere Eingabe vorhanden.");
    }

    // "is null or MenueBeenden": Pattern mit "or" – trifft bei EOF UND bei "0" zu.
    if (eingabe is null or MenueBeenden)
    {
        Console.WriteLine("Programm beendet.");
        break;
    }

    // switch-AUSDRUCK (C# 8+): liefert einen Wert – hier die auszuführende Aktion.
    // Der Discard "_" fängt alle übrigen Eingaben ab (wie default im switch).
    // Lambdas "() => ..." verpacken den Aufruf samt Argument in ein Action-Objekt.
    Action aktion = eingabe switch
    {
        MenueAnlageAnzeigen => () => ZeigeAnlage(anlage),
        MenueGesamtleistung => () => ZeigeGesamtleistungUndAuslastung(anlage),
        MenueReihenleistung => () => ZeigeReihenleistung(anlage),
        _ => ZeigeUngueltigeAuswahl,
    };

    aktion();
    Console.WriteLine();
}

// -------------------------------------------------------------------------------------
// Lokale Funktionen
// -------------------------------------------------------------------------------------

static void ZeigeMenue()
{
    Console.WriteLine("========== PV-Monitoring ==========");
    Console.WriteLine($"{MenueAnlageAnzeigen} ... Anlage anzeigen");
    Console.WriteLine($"{MenueGesamtleistung} ... Gesamtleistung und Auslastung");
    Console.WriteLine($"{MenueReihenleistung} ... Leistung pro Reihe");
    Console.WriteLine($"{MenueBeenden} ... Programm beenden");
}

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

// Menüpunkt 1: Leerzeile + Messwerttabelle.
static void ZeigeAnlage(Solaranlage anlage)
{
    Console.WriteLine();
    anlage.MesswerteAnzeigen();
}

// Menüpunkt 2: Gesamtleistung in kW (2 Nachkommastellen) und Auslastung in %
// (1 Nachkommastelle). {x:F2} = Festkommaformat; das Dezimaltrennzeichen kommt von
// der Systemsprache (Deutsch -> Komma). 1000.0 (double) verhindert Ganzzahl-Division.
static void ZeigeGesamtleistungUndAuslastung(Solaranlage anlage)
{
    const double WattProKilowatt = 1000.0;
    const int BreiteBeschriftung = 16;

    var gesamtleistungInKw = anlage.BerechneGesamtleistung() / WattProKilowatt;
    Console.WriteLine($"{"Gesamtleistung:",-BreiteBeschriftung}{gesamtleistungInKw:F2} kW");
    Console.WriteLine($"{"Auslastung:",-BreiteBeschriftung}{anlage.BerechneGesamtauslastung():F1} %");
}

// Menüpunkt 3: Leistung jeder Reihe + schwächste Reihe (1-basiert ausgegeben).
static void ZeigeReihenleistung(Solaranlage anlage)
{
    const int BreiteReihenleistung = 7;

    var reihenleistung = anlage.BerechneReihenleistung();
    for (var reihe = 0; reihe < reihenleistung.Length; reihe++)
    {
        Console.WriteLine($"Reihe {reihe + 1}:{reihenleistung[reihe],BreiteReihenleistung} W");
    }

    // MinBy liefert das Element mit dem kleinsten Schlüssel – hier den INDEX r,
    // dessen Reihenleistung am kleinsten ist (bei Gleichstand der erste).
    var schwaechsteReihe = Enumerable.Range(0, reihenleistung.Length).MinBy(r => reihenleistung[r]);
    Console.WriteLine($"Schwächste Reihe: {schwaechsteReihe + 1}");
}

static void ZeigeUngueltigeAuswahl() =>
    Console.WriteLine(
        $"Ungültige Auswahl! Bitte {MenueAnlageAnzeigen}, {MenueGesamtleistung}, {MenueReihenleistung} oder {MenueBeenden} eingeben.");
