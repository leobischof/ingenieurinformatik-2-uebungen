// ============================================================================
// Ingenieurinformatik II – Übungsblock #3, Aufgabe 1: Datentypen (MODERNE Version)
// ----------------------------------------------------------------------------
// Ziel: identisch zur klassischen Version –
//   Eingabe, bis genau EIN Zeichen kommt -> char -> int (Codepunkt) ausgeben ->
//   double * 1,3 + float 2,56 -> Summe (double) ausgeben -> (int)-Konversion ausgeben.
//
// Was ist hier "modern" (C# 12 / .NET 8)?
//   - Top-Level-Statements: Kein "namespace { class Program { static void Main ... } }"
//     mehr nötig. Der Compiler erzeugt Klasse und Main-Methode im Hintergrund selbst.
//   - char.TryParse(..., out zeichen): prüft "genau ein Zeichen?" UND wandelt um –
//     in einem einzigen Aufruf, ohne Ausnahme bei falscher Eingabe.
//   - Pattern Matching "is null" statt "== null" (kann nicht durch einen
//     überladenen ==-Operator verfälscht werden).
//   - String-Interpolation $"..." mit Format-Spezifizierern (z. B. {x:F2}, {x:X4}).
//
// Bewusst NICHT verwendet: "var". Die Aufgabe dreht sich gerade um Datentypen –
// darum stehen die Typen (char, int, double, float) hier ausdrücklich im Code.
// ============================================================================

// UTF-8-Ausgabe, damit Umlaute und Sonderzeichen korrekt erscheinen. Die Windows-
// Konsole nutzt sonst eine alte Codepage (z. B. 850), in der z. B. "€" zu "?" wird
// (so wie im Screenshot der Angabe).
Console.OutputEncoding = System.Text.Encoding.UTF8;

// ---------------------------------------------------------------------------
// Schritt 1: Einlesen, bis genau EIN Zeichen eingegeben wurde
// ---------------------------------------------------------------------------
// while (true) + break: Die Schleife läuft, bis wir sie gezielt verlassen. Das ist
// hier übersichtlicher als do-while, weil es ZWEI Ausgänge gibt (Erfolg und EOF).
char zeichen;
while (true)
{
    Console.Write("Bitte geben Sie ein einzelnes Zeichen ein: ");
    string? eingabe = Console.ReadLine();

    // EOF-Schutz: ReadLine() liefert null, wenn keine Eingabe mehr kommt (Strg+Z,
    // umgeleitete Datei/Pipe zu Ende). Ohne diesen Ausgang liefe die Schleife ewig.
    if (eingabe is null)
    {
        Console.WriteLine();
        Console.WriteLine("Keine weitere Eingabe vorhanden – das Programm wird beendet.");
        return; // In Top-Level-Statements beendet "return" das Programm.
    }

    // TryParse liefert true, wenn der string GENAU ein Zeichen enthält, und schreibt
    // das Ergebnis über den out-Parameter in "zeichen". Bei "", "ab" usw. -> false.
    if (char.TryParse(eingabe, out zeichen))
    {
        break;
    }

    Console.WriteLine($"Ungültige Eingabe: \"{eingabe}\" besteht aus {eingabe.Length} Zeichen. Bitte genau EIN Zeichen eingeben.");
}

// ---------------------------------------------------------------------------
// Schritt 2: char -> int (Unicode-Codepunkt), separat gespeichert
// ---------------------------------------------------------------------------
// Expliziter Cast für die Lesbarkeit (implizit wäre char -> int auch erlaubt,
// da jeder char-Wert 0..65535 verlustfrei in einen int passt).
int numerischeRepraesentation = (int)zeichen;

// {..:X4} = hexadezimal, 4-stellig -> klassische Unicode-Schreibweise "U+0061".
Console.WriteLine($"Numerische Repräsentation von '{zeichen}': {numerischeRepraesentation} (Unicode U+{numerischeRepraesentation:X4})");

// ---------------------------------------------------------------------------
// Schritt 3: double * 1,3 + float 2,56
// ---------------------------------------------------------------------------
double kommazahl = numerischeRepraesentation; // implizit int -> double (verlustfrei)
kommazahl *= 1.3;                              // Kurzform von kommazahl = kommazahl * 1.3
float kleineKommazahl = 2.56f;                 // "f"-Suffix nötig, sonst wäre 2.56 ein double
double summe = kommazahl + kleineKommazahl;    // float wird implizit zu double erweitert

Console.WriteLine($"double-Wert ({numerischeRepraesentation} * 1,3): {kommazahl}");
Console.WriteLine($"float-Wert: {kleineKommazahl}");
// Ohne Format-Spezifizierer sieht man den vollen double-Wert (inkl. float-Rundungsfehler),
// mit {summe:F2} die auf 2 Nachkommastellen GERUNDETE Darstellung (nur Anzeige!).
Console.WriteLine($"Summe (double + float): {summe} (gerundet angezeigt: {summe:F2})");

// ---------------------------------------------------------------------------
// Schritt 4: double -> int (explizit, schneidet Nachkommastellen ab)
// ---------------------------------------------------------------------------
int summeGanzzahl = (int)summe;
Console.WriteLine($"Summe als int: {summeGanzzahl}");

// ============================================================================
// ANTWORTEN auf die Fragen der Angabe (*)
// ============================================================================
//
// ANTWORT 1 – Warum haben Zeichen eine numerische Repräsentation?
//   Computer speichern ausschließlich Zahlen (Bits). Eine Zeichenkodierung ordnet
//   jedem Zeichen eine Zahl zu. ASCII (7 Bit, 128 Zeichen: 'A' = 65, 'a' = 97,
//   '0' = 48) war der erste verbreitete Standard; Unicode erweitert das auf alle
//   Schriften der Welt (die ersten 128 Codepunkte = ASCII). Ein C#-char ist eine
//   16-Bit-UTF-16-Codeeinheit (0..65535), z. B. 'ä' = 228, '€' = 8364. Dadurch kann
//   man Zeichen vergleichen, sortieren und mit ihnen rechnen ('7' - '0' == 7).
//   Zeichen außerhalb von 16 Bit (viele Emojis) bestehen in UTF-16 aus ZWEI chars
//   (Surrogat-Paar) – char.TryParse lehnt sie deshalb als "zwei Zeichen" ab.
//
// ANTWORT 2 – Welcher Datentyp für die Summe ohne explizite Konversion, und warum?
//   double. Bei "double + float" erweitert C# den float automatisch (implizit) zu
//   double: double hat den größeren Wertebereich und mehr Genauigkeit (ca. 15–16
//   statt ca. 7 signifikante Stellen), die Umwandlung ist also verlustfrei – darum
//   darf der Compiler sie selbst durchführen. Für eine float-Summe bräuchte man
//   einen expliziten Cast (float), weil double -> float Genauigkeit verlieren kann.
//   Dass die Summe "krumm" aussieht (z. B. 128,65999994277956 statt 128,66), liegt
//   daran, dass 2,56 als float (und 1,3 als double) binär nicht exakt darstellbar ist.
//
// ANTWORT 3 – Was beobachtet man bei der Konversion nach int?
//   Die Nachkommastellen werden ABGESCHNITTEN, nicht gerundet (Richtung 0):
//   128,66 -> 128, 128,99 -> 128, -2,7 -> -2. Zum Runden: (int)Math.Round(summe).
//   Der Cast ist Pflicht, weil Information verloren geht (Nachkommastellen,
//   kleinerer Wertebereich) – der Programmierer muss das ausdrücklich bestätigen.
