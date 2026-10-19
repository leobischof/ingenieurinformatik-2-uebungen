// ============================================================================
// Ingenieurinformatik II – Übungsblock #3, Aufgabe 2: Multi-Massenkonverter
// (MODERNE Version)
// ----------------------------------------------------------------------------
// Ziel: identisch zur klassischen Version – Masse in kg/lbs/st einlesen, in die
// beiden anderen Einheiten umrechnen, ungültige Eingaben erneut abfragen, danach
// "Weitere Umrechnung? (Ja/Nein)".
//
// Was ist hier "modern"?
//   - Top-Level-Statements statt Klasse Program + Main.
//   - enum Masseneinheit (eigene Datei) statt loser int-Konstanten 1/2/3.
//   - Rechenlogik + Konstanten in eigener Klasse Massenumrechnung (Trennung von
//     Ein-/Ausgabe und Berechnung).
//   - Lokale Funktionen (LiesEinheit, LiesMasse, LiesJaNein) mit nullable
//     Rückgabewert: null bedeutet "Eingabe zu Ende" (EOF).
//   - Pattern Matching: "is not Masseneinheit einheit" prüft auf null UND legt in
//     einem Schritt eine Variable an.
//   - LINQ (Where) + Enum.GetValues<T>() statt drei einzelner if-Abfragen.
//   - Switch-Ausdrücke mit "or"-Mustern, String-Interpolation mit {wert:F2}.
//   - Guard Clauses (früher Ausstieg mit continue/return) statt verschachtelter ifs.
// ============================================================================

using UE03.A2.Massenkonverter.Modern;

// UTF-8-Ausgabe: sonst würden Umlaute/€ in der Windows-Konsole (Codepage 850)
// falsch bzw. als "?" angezeigt (vgl. Screenshot der Angabe).
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Willkommen zum Masseneinheitenkonverter!");

// Endlosschleife mit gezielten Ausstiegen (EOF -> return, "Nein" -> break).
while (true)
{
    // EOF-Schutz: Jede Lese-Funktion liefert null, wenn Console.ReadLine() null
    // liefert (Eingabe zu Ende, z. B. Strg+Z oder umgeleitete Datei/Pipe). Dann
    // beenden wir sauber, statt endlos auf eine Eingabe zu warten, die nie kommt.
    if (LiesEinheit() is not Masseneinheit einheit)
    {
        MeldeEingabeende();
        return;
    }

    if (LiesMasse() is not double masse)
    {
        MeldeEingabeende();
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Die Masse in den anderen Einheiten:");

    // Alle Einheiten AUSSER der gewählten (LINQ-Where mit Lambda "e => e != einheit").
    // Die Reihenfolge entspricht der Reihenfolge im enum: kg, lbs, st.
    foreach (Masseneinheit ziel in Enum.GetValues<Masseneinheit>().Where(e => e != einheit))
    {
        double umgerechnet = Massenumrechnung.Umrechnen(masse, einheit, ziel);
        Console.WriteLine($"{ziel}: {umgerechnet:F2} {ziel.Abkuerzung()}");
    }
    Console.WriteLine();

    bool? weitere = LiesJaNein("Möchten Sie eine weitere Umrechnung durchführen? (Ja/Nein): ");
    if (weitere is null)
    {
        MeldeEingabeende();
        return;
    }
    if (weitere == false)
    {
        break;
    }
    Console.WriteLine();
}

Console.WriteLine("Das Programm wird beendet.");

// ============================================================================
// Lokale Funktionen
// "static" = sie greifen auf keine Variablen des umgebenden Codes zu. Das macht
// sie leichter verständlich (alles, was sie brauchen, kommt über Parameter).
// ============================================================================

// Gibt eine Frage aus und liest die Antwortzeile (null bei EOF).
static string? Frage(string text)
{
    Console.Write(text);
    return Console.ReadLine();
}

static void MeldeEingabeende()
{
    Console.WriteLine();
    Console.WriteLine("Keine weitere Eingabe vorhanden – das Programm wird beendet.");
}

// Zeigt das Menü und fragt so lange, bis eine gültige Einheit gewählt wurde.
static Masseneinheit? LiesEinheit()
{
    Console.WriteLine("Wählen Sie eine Masseneinheit aus:");
    foreach (Masseneinheit einheit in Enum.GetValues<Masseneinheit>())
    {
        // (int)einheit liefert die Menünummer, die im enum hinterlegt ist.
        Console.WriteLine($"{(int)einheit}. {einheit} ({einheit.Abkuerzung()})");
    }
    Console.WriteLine();

    while (true)
    {
        string? text = Frage("Ihre Auswahl: ");
        if (text is null)
        {
            return null;
        }

        // "out int nummer" deklariert die Variable direkt im Aufruf.
        // Enum.IsDefined prüft, ob die Zahl wirklich zu einem enum-Wert gehört (1–3).
        if (int.TryParse(text, out int nummer) && Enum.IsDefined((Masseneinheit)nummer))
        {
            return (Masseneinheit)nummer;
        }

        Console.WriteLine("Ungültige Auswahl. Bitte geben Sie 1, 2 oder 3 ein.");
    }
}

// Fragt so lange nach einer Masse, bis eine gültige, nicht-negative Zahl kommt.
static double? LiesMasse()
{
    while (true)
    {
        string? text = Frage("Geben Sie die Masse in der ausgewählten Einheit ein: ");
        if (text is null)
        {
            return null;
        }

        // Guard Clauses: Jeder Fehlerfall wird sofort behandelt und mit "continue"
        // zur nächsten Runde gesprungen – der "gute Weg" bleibt unverschachtelt.
        // double.TryParse nutzt die Culture des Rechners (Deutsch: Komma "2,5").
        if (!double.TryParse(text, out double masse))
        {
            Console.WriteLine($"Ungültige Eingabe: \"{text}\" ist keine Zahl.");
            continue;
        }

        // double.TryParse akzeptiert auch "NaN" und "∞" – IsFinite schließt sie aus.
        if (!double.IsFinite(masse))
        {
            Console.WriteLine("Ungültige Masse: Bitte eine endliche Zahl eingeben.");
            continue;
        }

        // Relationales Muster "is < 0" (C# 9+): liest sich wie "masse ist kleiner 0".
        if (masse is < 0)
        {
            Console.WriteLine("Ungültige Masse: Die Masse darf nicht negativ sein.");
            continue;
        }

        return masse;
    }
}

// Fragt so lange, bis "Ja" oder "Nein" (auch "j"/"n", Groß-/Kleinschreibung egal) kommt.
static bool? LiesJaNein(string frage)
{
    while (true)
    {
        string? antwort = Frage(frage);
        if (antwort is null)
        {
            return null;
        }

        // Switch-Ausdruck mit "or"-Mustern; "_" = alles andere.
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

        Console.WriteLine("Bitte antworten Sie mit \"Ja\" oder \"Nein\".");
    }
}
