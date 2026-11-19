# Ingenieurinformatik II – Übungen (TU Graz, WS 2026/27)

Lösungen zu den Übungsblöcken der Lehrveranstaltung **Ingenieurinformatik II** in **C#**,
ausführlich auf Deutsch kommentiert, damit man den Stoff direkt aus dem Code lernen kann.

> Die Angaben (PDFs) sind urheberrechtlich geschützt (© TU Graz) und deshalb **nicht** im Repo.
> Jede Aufgabe hat eine eigene README mit einer Zusammenfassung der Angabe in eigenen Worten.

## Aufbau

```
ingenieurinformatik-2-uebungen/
├── Directory.Build.props        ← gemeinsame Build-Einstellungen für alle Projekte (net8.0, …)
├── IngInfo2-Uebungen.sln        ← eine Solution mit allen Übungsprojekten (in Visual Studio öffnen)
├── CSHARP-SPICKZETTEL.md        ← Startbefehle, Debuggen, Tastenkürzel
├── UE03_Datentypen-Kontrollstrukturen-Klassen/
│   ├── A1_Datentypen/
│   │   ├── Program.cs
│   │   ├── UE03.A1.Datentypen.csproj
│   │   └── README.md            ← Angabe in eigenen Worten + Beispiel-Ausgabe
│   └── …
├── UE04_… bis UE07_…/
└── Teilueberpruefung1_Training/ ← acht Übungsprüfungen (eigene .sln je Training)
```

Ein Ordner pro **Übung**, darin ein Ordner pro **Aufgabe**, darin genau **ein** Konsolenprojekt.
Alle Lösungen sind **klassisch** geschrieben, so wie in der Vorlesung: `namespace { class Program
{ static void Main(...) } }`, nur Stoff, der bis zu dieser Übung vorgekommen ist (keine LINQ, keine
Records, keine Top-Level-Statements).

## Übungen

| Übung | Thema | Aufgaben |
| --- | --- | --- |
| [UE03](UE03_Datentypen-Kontrollstrukturen-Klassen/) | Datentypen, Kontrollstrukturen und einfache Klassen | Datentypen · Multi-Massenkonverter · Fahrrad · Bestellsystem |
| [UE04](UE04_Verzweigungen-Arrays-Klassen/) | Verzweigungen, Arrays, Klassen | Multiplikationstabelle · Notenverwaltung · Instrumentenverleih · Solaranlage |
| [UE05](UE05_Methoden-Vererbung/) | Methoden, Vererbung | Fibonacci · ggT · Immobilienverwaltung · Fahrradverleih |
| [UE06](UE06_Listen-Dictionaries-Schnittstellen/) | Listen, Dictionaries, Schnittstellen ([Erklärung](UE06_Listen-Dictionaries-Schnittstellen/ERKLAERUNG.md)) | Matrix-Analyser · Stückliste · Lagerverwaltung · Fertigungsaufträge |
| [UE07](UE07_Fehlerbehandlung/) | Fehlerbehandlung ([Erklärung](UE07_Fehlerbehandlung/ERKLAERUNG.md)) | Datum einlesen · Ausschussquote · Zugstab |

**Prüfungsvorbereitung:** [Teilueberpruefung1_Training](Teilueberpruefung1_Training/README.md) –
acht Übungsprüfungen zum Stoff UE01–UE05, aufgebaut wie die Teilüberprüfung (Angabe + Lösung);
Training 5–8 mit Schwerpunkt Methoden und Vererbung.

## Ausführen

> Ausführlicher Spickzettel mit Startbefehlen, Debuggen und allen wichtigen Tastenkürzeln
> (Zed, VS Code & Visual Studio): [CSHARP-SPICKZETTEL.md](CSHARP-SPICKZETTEL.md)

Voraussetzung: [.NET SDK](https://dotnet.microsoft.com/download) 8 oder neuer.
Die Projekte zielen auf .NET 8 (LTS); dank `RollForward=Major` laufen sie auch, wenn nur eine neuere
Runtime (z. B. .NET 10) installiert ist.

```bash
# eine einzelne Aufgabe starten
dotnet run --project "UE04_Verzweigungen-Arrays-Klassen/A1_Multiplikationstabelle"

# alles bauen
dotnet build IngInfo2-Uebungen.sln
```

Oder in **Visual Studio 2022** (Workload „.NET-Desktopentwicklung“) `IngInfo2-Uebungen.sln`
öffnen, das gewünschte Projekt per Rechtsklick → *Als Startprojekt festlegen* auswählen und mit
**F5** (mit Debugger) oder **Strg+F5** (ohne Debugger) starten. Die Trainings-Prüfungen haben je
eine eigene `.sln` im Ordner `Angabe/` bzw. `Loesung/`.
