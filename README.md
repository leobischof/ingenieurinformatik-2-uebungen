# Ingenieurinformatik II – Übungen (TU Graz, WS 2026/27)

Lösungen zu den Übungsblöcken der Lehrveranstaltung **Ingenieurinformatik II** in **C#**,
ausführlich auf Deutsch kommentiert, damit man den Stoff direkt aus dem Code lernen kann.

> Die Angaben (PDFs) sind urheberrechtlich geschützt (© TU Graz) und deshalb **nicht** im Repo.
> Jede Aufgabe hat eine eigene README mit einer Zusammenfassung der Angabe in eigenen Worten.

## Aufbau

```
ingenieurinformatik-2-uebungen/
├── Directory.Build.props        ← gemeinsame Build-Einstellungen für alle Projekte (net8.0, …)
├── IngInfo2-Uebungen.sln        ← eine Solution mit allen Projekten (in Visual Studio öffnen)
├── UE03_Datentypen-Kontrollstrukturen-Klassen/
│   ├── A1_Datentypen/
│   │   ├── Klassisch/           ← Lösung im Stil der Vorlesung
│   │   └── Modern/              ← dieselbe Lösung in modernem C#
│   └── …
└── UE04_Verzweigungen-Arrays-Klassen/
    └── …
```

Ein Ordner pro **Übung**, darin ein Ordner pro **Aufgabe**, darin zwei eigenständige Konsolenprojekte:

| Variante | Idee |
| --- | --- |
| **Klassisch** | Genau so, wie es in der Vorlesung gelehrt wird: `class Program { static void Main(...) }`, nur Konzepte, die bis zu dieser Übung vorgekommen sind (keine LINQ, keine Records, …). Diese Variante entspricht der Abgabe. |
| **Modern** | Gleiche Funktion, aber idiomatisches aktuelles C# (Top-Level-Statements, Records/Properties, Switch-Expressions, LINQ, …). Zum Vergleichen und Weiterlernen. |

## Übungen

| Übung | Thema | Aufgaben |
| --- | --- | --- |
| [UE03](UE03_Datentypen-Kontrollstrukturen-Klassen/) | Datentypen, Kontrollstrukturen und einfache Klassen | Datentypen · Multi-Massenkonverter · Fahrrad · Bestellsystem |
| [UE04](UE04_Verzweigungen-Arrays-Klassen/) | Verzweigungen, Arrays, Klassen | Multiplikationstabelle · Notenverwaltung · Instrumentenverleih · Solaranlage |

## Ausführen

Voraussetzung: [.NET SDK](https://dotnet.microsoft.com/download) 8 oder neuer.
Die Projekte zielen auf .NET 8 (LTS); dank `RollForward=Major` laufen sie auch, wenn nur eine neuere
Runtime (z. B. .NET 10) installiert ist.

```bash
# eine einzelne Aufgabe starten
dotnet run --project "UE04_Verzweigungen-Arrays-Klassen/A1_Multiplikationstabelle/Klassisch"

# alles bauen
dotnet build IngInfo2-Uebungen.sln
```

Oder `IngInfo2-Uebungen.sln` in Visual Studio öffnen, das gewünschte Projekt per Rechtsklick
→ *Als Startprojekt festlegen* auswählen und mit **F5** starten.
