# UE04 – Verzweigungen, Arrays, Klassen

Übungsblock #4 der Lehrveranstaltung *Ingenieurinformatik II* (TU Graz, WS 2026/27).
Jede Aufgabe gibt es in **zwei Versionen**:

- **Klassisch**: so, wie es in der Vorlesung gelehrt wird. Block-Namespace mit `class Program` und `Main`, nur Schleifen, Arrays, Klassen, Methoden und enums, kein LINQ und keine Lambdas.
- **Modern**: idiomatisches C# 12 / .NET 8 mit Top-Level-Statements, Primary Constructors, Properties, Collection-Expressions, Switch-Ausdrücken und LINQ.

Beide Versionen erfüllen dieselbe Angabe und liefern dieselbe Konsolenausgabe. Der Code ist ausführlich auf Deutsch kommentiert, damit sich der Stoff direkt aus den Quelltexten lernen lässt.

## Aufgaben

| Nr. | Aufgabe | Schwerpunkte | Ordner |
|-----|---------|--------------|--------|
| 1 | Multiplikationstabelle | 2D-Array `int[,]`, verschachtelte Schleifen, `PadLeft` | [A1_Multiplikationstabelle](A1_Multiplikationstabelle/README.md) |
| 2 | Notenverwaltungssystem | Klasse `Student`, Konstruktor, `private` + Getter, Array von Objekten | [A2_Notenverwaltungssystem](A2_Notenverwaltungssystem/README.md) |
| 3 | Instrumentenverleih | Klasse `Instrument`, enum `Verleihstatus`, Eingabeprüfung, `break` | [A3_Instrumentenverleih](A3_Instrumentenverleih/README.md) |
| 4 | Leistungsübersicht einer Solaranlage | Klasse `Solaranlage`, 2D-/1D-Arrays, `foreach`, Menü mit `do-while` | [A4_Solaranlage](A4_Solaranlage/README.md) |

## Lernziele (kurz)

- Schleifen (`for`, `while`, `do-while`, `foreach`), auch verschachtelt, und `break`
- 1D- und 2D-Arrays (`int[]`, `int[,]`, `GetLength`)
- Klassen vs. Objekte, Felder, Konstruktor (und Destruktor), Zugriffsmodifikatoren
- Methoden mit Parametern und Rückgabewerten
- Aufzählungstypen (`enum`)

## Starten

Voraussetzung: .NET SDK 8 oder neuer. Aus dem Repo-Root:

```bash
dotnet run --project UE04_Verzweigungen-Arrays-Klassen/A1_Multiplikationstabelle/Klassisch
dotnet run --project UE04_Verzweigungen-Arrays-Klassen/A1_Multiplikationstabelle/Modern
```

Für die anderen Aufgaben tauschst du den Ordnernamen aus (`A2_Notenverwaltungssystem`, `A3_Instrumentenverleih`, `A4_Solaranlage`).
Die Build-Einstellungen (net8.0, Nullable, ImplicitUsings) kommen zentral aus `Directory.Build.props` im Repo-Root.

## Gemeinsame Details

- `Console.OutputEncoding = UTF8` am Programmstart: Damit zeigt die Windows-Konsole Umlaute korrekt an.
- Programme mit Eingabe beenden sich sauber, wenn die Eingabe zu Ende ist (`Console.ReadLine()` liefert dann `null`), statt endlos weiterzulaufen.
- Bei umgeleiteter Eingabe (z. B. `printf '1\n0\n' | dotnet run ...`) wird die gelesene Zeile mit ausgegeben, damit ein Testprotokoll wie eine echte Sitzung aussieht.
- Es wird keine Kultur erzwungen. Auf einem deutschsprachigen System erscheint deshalb ein Komma als Dezimaltrennzeichen (`2,67`).
