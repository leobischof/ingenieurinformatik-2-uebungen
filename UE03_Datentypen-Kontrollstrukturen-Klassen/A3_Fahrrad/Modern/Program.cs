// ============================================================================
// Ingenieurinformatik II – Übungsblock #3, Aufgabe 3: Erstes Objekt – Fahrrad
// (MODERNE Version)
// ----------------------------------------------------------------------------
// Ziel: identisch zur klassischen Version – zwei Fahrrad-Objekte erzeugen,
// ausgeben, Gangzahl eines Fahrrads korrigieren, erneut ausgeben.
//
// Was ist hier "modern"?
//   - Top-Level-Statements: Der Compiler erzeugt die Klasse "Program" und ihre
//     "Main"-Methode automatisch – die Objekte entstehen also weiterhin in
//     Program.Main, wie die Angabe es verlangt, man sieht es nur nicht mehr.
//   - Objekt-Initialisierer "new() { brand = ..., numberGears = ... }" mit
//     "required"-Properties (siehe Fahrrad.cs).
//   - Collection-Expression [a, b] (C# 12) für das Array.
//   - LINQ Select mit Index + string.Join statt doppelt kopierter Ausgabezeilen.
// ============================================================================

using UE03.A3.Fahrrad.Modern;

// UTF-8-Ausgabe für Umlaute (sonst alte Windows-Codepage, z. B. 850).
Console.OutputEncoding = System.Text.Encoding.UTF8;

// "new()" ohne Klassennamen ("target-typed new", C# 9): Der Typ ergibt sich aus
// dem Array-Typ Fahrrad[]. Der Objekt-Initialisierer { ... } setzt die Properties
// direkt beim Erzeugen. Fehlt eine required-Property, gibt es einen Compilerfehler.
Fahrrad[] fahrraeder =
[
    new() { brand = "Cube", numberGears = 18 },
    new() { brand = "Trek", numberGears = 21 }, // absichtlich falsch eingegeben
];

ZeigeFahrraeder("Informationen zu den Fahrrädern:", fahrraeder);
Console.WriteLine();

// Korrektur über den Property-Setter. Arrays beginnen bei Index 0 -> Fahrrad 2 = [1].
// fahrraeder[1] liefert eine REFERENZ auf das Objekt (Klassen sind Referenztypen),
// daher ändert die Zuweisung das Objekt im Array selbst – keine Kopie.
fahrraeder[1].numberGears = 24;
Console.WriteLine("Die Anzahl der Gänge von Fahrrad 2 wurde korrigiert.");
Console.WriteLine();

ZeigeFahrraeder("Aktualisierte Informationen zu den Fahrrädern:", fahrraeder);

// Lokale Funktion: gibt Überschrift + alle Fahrräder aus.
// Select((rad, index) => ...) liefert zu jedem Element auch dessen Position, daraus
// wird die laufende Nummer (index + 1). {rad} ruft automatisch rad.ToString() auf.
// string.Join("\n", ...) verbindet die Zeilen mit Zeilenumbrüchen ("\n" laut Hinweis).
static void ZeigeFahrraeder(string ueberschrift, IEnumerable<Fahrrad> fahrraeder)
{
    IEnumerable<string> zeilen = fahrraeder.Select((rad, index) => $"Fahrrad {index + 1}: {rad}");
    Console.WriteLine($"{ueberschrift}\n{string.Join("\n", zeilen)}");
}
