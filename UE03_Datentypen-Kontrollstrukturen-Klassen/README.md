# UE03 – Datentypen, Kontrollstrukturen und einfache Klassen

Übungsblock #3 der Lehrveranstaltung *Ingenieurinformatik II* (TU Graz, WS 2026/27).
Jede Aufgabe ist zweimal gelöst:

- **Klassisch**: so, wie es in der Vorlesung gelehrt wird. Block-Namespace, `class Program` mit
  `static void Main`, nur Stoff aus UE3 (Datentypen, Casts, `Parse`/`TryParse`, `const`,
  `if`/`switch`, `while`/`do-while`/`for`, „vereinfachte“ Klassen mit public Feldern).
- **Modern**: idiomatisches C# 12 / .NET 8 mit gleicher Funktion. Top-Level-Statements,
  file-scoped Namespaces, Records/Properties, Switch-Ausdrücke, Pattern Matching, LINQ.

Alle Quelldateien sind ausführlich auf Deutsch kommentiert. Die Kommentare erklären vor allem,
*warum* etwas so gelöst ist.

## Aufgaben

| Nr. | Aufgabe | Inhalt | Ordner |
|-----|---------|--------|--------|
| 1 | Datentypen | `char` → `int` → `double`/`float` → `int`, Antworten auf die Fragen | [A1_Datentypen](A1_Datentypen/README.md) |
| 2 | Multi-Massenkonverter | kg ↔ lbs ↔ st mit Konstanten, Eingabeprüfung und Wiederholung | [A2_Multi-Massenkonverter](A2_Multi-Massenkonverter/README.md) |
| 3 | Erstes Objekt – Fahrrad | vereinfachte Klasse `Fahrrad`, zwei Objekte, Attribut ändern | [A3_Fahrrad](A3_Fahrrad/README.md) |
| 4 | Bestellsystem | Take-Away-Bestellung mit Sonderwünschen, Gesamtpreis und längster Zubereitungszeit | [A4_Bestellsystem](A4_Bestellsystem/README.md) |

## Lernziele (kurz)

- Datentypen kennen, Variablen und Konstanten (`const`) verwenden
- implizite und explizite Konversion (`(int)`, `(double)`, `Parse`, `TryParse`)
- arithmetische, vergleichende, logische und zuweisende Operatoren
- geschachtelte Verzweigungen, `switch`
- `while`, `do-while` und `for`: Unterschiede kennen, eine `for`- in eine `while`-Schleife umschreiben
- „vereinfachte“ Klassen (nur public Attribute), Klasse vs. Objekt, Objekte instanziieren

## Starten

Voraussetzung: .NET SDK 8 oder neuer. Dank `RollForward=Major` laufen die Programme auch, wenn nur
.NET 9/10 installiert ist. Die Befehle gelten für den Repo-Root:

```powershell
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A1_Datentypen/Klassisch"
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A1_Datentypen/Modern"
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A2_Multi-Massenkonverter/Klassisch"
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A2_Multi-Massenkonverter/Modern"
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A3_Fahrrad/Klassisch"
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A3_Fahrrad/Modern"
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A4_Bestellsystem/Klassisch"
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A4_Bestellsystem/Modern"
```

In Visual Studio öffnet man `IngInfo2-Uebungen.sln` und wählt das gewünschte Projekt als
Startprojekt aus.

## Gemeinsame Hinweise

- **UTF-8-Ausgabe:** Jedes Programm setzt `Console.OutputEncoding = Encoding.UTF8`. Ohne diese Zeile
  zeigt die Windows-Konsole (Codepage 850) z. B. das `€` als `?` an, so wie im Screenshot der Angabe.
- **Dezimaltrennzeichen:** Es wird keine Culture erzwungen. `double.Parse`/`TryParse` und die
  Formatierung (`F2`, `C`) folgen der Ländereinstellung des Rechners. Auf einem deutschen System
  heißt das: Komma eingeben (`2,5`). Achtung, `2.5` wird dort als `25` gelesen, weil der Punkt als
  Tausendertrennzeichen gilt.
- **Ende der Eingabe (EOF):** `Console.ReadLine()` liefert `null`, wenn keine Eingabe mehr kommt
  (Strg+Z oder umgeleitete Eingabe). Alle Eingabeschleifen beenden dann sauber, statt endlos zu
  warten. Testen lässt sich das z. B. in Git Bash:
  `printf '1\n20\nNein\n' | dotnet run --project "<Projektordner>"`.
