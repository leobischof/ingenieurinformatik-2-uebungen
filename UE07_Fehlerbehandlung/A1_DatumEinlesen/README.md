# UE07 – Aufgabe 1: Datum einlesen

> Ausführliche Erklärung (Konzepte, Lösungsweg, Python-Vergleiche): [ERKLAERUNG.md](../ERKLAERUNG.md#aufgabe-1--datum-einlesen)

## Was macht das Programm?

Man gibt ein Datumsformat ein (z. B. `dd_MM~yyyy`) und danach ein Datum in diesem Format
(z. B. `10_12~2023`). Das Programm gibt das Datum im ISO-Format aus (`2023-12-10`). Passt das Datum
nicht zum Format, kommt eine Fehlermeldung und das Programm fragt neu, statt abzustürzen.

## So zeigst du den Code

1. `while (!erfolgreich)`: wiederholt alles, bis die Umwandlung einmal geklappt hat.
2. Format und Datum einlesen, das kann nicht schiefgehen, darum steht es vor dem `try`.
3. `try`: `DateTime.ParseExact(datum, format, null)` ist die riskante Zeile. Danach Ausgabe und `erfolgreich = true`.
4. Drei `catch`-Blöcke: `FormatException`, `ArgumentNullException` (die zwei laut Dokumentation)
   und zur Sicherheit `Exception`.

## Wahrscheinliche Fragen

- **Was ist eine Exception?** Ein Fehler, der während das Programm läuft auftritt. Ohne `catch` stürzt das
  Programm ab. `try`/`catch` ist dasselbe wie `try`/`except` in Python.
- **Warum steht `catch (Exception)` ganz unten?** Die Blöcke werden von oben geprüft. Stünde der allgemeine
  oben, kämen die speziellen nie dran.
- **Was ist `ParseExact`?** Wie `datetime.strptime` in Python: liest ein Datum genau nach Muster.
  `dd` = Tag, `MM` = Monat (klein `mm` wären Minuten), `yyyy` = Jahr.
- **Welche drei Fehlerarten gibt es?** Syntaxfehler (Compiler meckert), logische Fehler (falsches Ergebnis,
  nur durch Testen zu finden) und Laufzeitfehler (Exceptions, um die geht es hier).

## Starten

```bash
dotnet run --project "UE07_Fehlerbehandlung/A1_DatumEinlesen"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
Vorführen: `dd.MM.yyyy` + `31.02.2023` (Fehler), dann `dd_MM~yyyy` + `10_12~2023`.
