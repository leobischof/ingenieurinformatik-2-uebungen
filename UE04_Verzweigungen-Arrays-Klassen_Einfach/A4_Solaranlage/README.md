# UE04 – Aufgabe 4: Leistungsübersicht einer Solaranlage

## Was macht das Programm?

Eine Solaranlage hat 4 Reihen mit je 6 Modulen, jedes Modul schafft höchstens 400 W. Die Klasse
`Solaranlage` speichert die gemessene Leistung jedes Moduls in einer Tabelle (2D-Array). Das
Hauptprogramm zeigt ein Menü, bis du 0 eingibst: Menüpunkt 1 zeigt die Messwerte als Tabelle,
2 die Gesamtleistung (8,47 kW) und die Auslastung (88,2 %), 3 die Leistung jeder Reihe und die
schwächste Reihe (Reihe 4). Bei einer ungültigen Eingabe kommt eine Meldung, und das Menü erscheint erneut.

## So zeigst du den Code

1. `Solaranlage.cs` oben: Die Klasse hat drei **private Felder** (`standort`, `modulnennleistung`,
   `messwerte`). Von außen kommt man nur über die Methoden dran.
2. Der **Konstruktor**: Standort und Nennleistung kommen als Parameter, das Array `int[4, 6]`
   wird gleich mit Werten befüllt (4 Zeilen = Reihen, 6 Spalten = Module).
3. `MesswerteAnzeigen()`: **verschachtelte `for`-Schleife**, außen die Reihen, innen die Module.
4. `BerechneGesamtleistung()`: **`foreach`** geht alle 24 Werte durch und addiert sie.
5. `BerechneGesamtauslastung()`: Gesamtleistung in Prozent der Maximalleistung (9600 W).
   `100.0` mit Komma, damit keine Ganzzahldivision entsteht.
6. `BerechneReihenleistung()`: liefert ein `int[]` mit der Summe pro Reihe.
7. `Program.cs`: Objekt mit `new Solaranlage(...)` anlegen, dann die **`do-while`-Schleife** mit dem
   Menü und dem **`switch`**. Bei `case 3` wird die schwächste Reihe mit einer Schleife gesucht.
8. Vorführen: `1`, `2`, `3`, dann `x` (Fehlermeldung), dann `0`.

## Wahrscheinliche Fragen

- **Wie funktioniert das 2D-Array, was macht `GetLength`?** Ein `int[4, 6]` ist eine Tabelle mit
  4 Zeilen und 6 Spalten, man greift mit `messwerte[reihe, modul]` zu. `GetLength(0)` ist die Anzahl
  der Zeilen (4), `GetLength(1)` die Anzahl der Spalten (6). In Python wäre das eine Liste von Listen.
- **Warum `foreach` und nicht `for`?** Für die Summe brauche ich keine Indizes, nur jeden Wert einmal.
  `foreach` ist kürzer, wie `for wert in liste:` in Python. Mit `for` brauche ich dagegen den Index,
  zum Beispiel um die Reihe zu wissen (`BerechneReihenleistung`).
- **Warum `do-while` und nicht `while`?** Das Menü muss mindestens einmal erscheinen, bevor man
  etwas auswählen kann. Bei `do-while` wird die Bedingung (`auswahl != 0`) erst nach dem Durchlauf
  geprüft. Bei `while` müsste ich `auswahl` vorher künstlich auf einen Wert setzen.
- **Was ist eine Klasse, was macht der Konstruktor?** Die Klasse ist der Bauplan, `new Solaranlage(...)`
  baut daraus ein Objekt. Der Konstruktor läuft dabei automatisch einmal und setzt die Felder
  (in Python wäre das `__init__`). `this.standort` ist das Feld, `standort` der Parameter.
- **Warum `/ 1000.0` und `* 100.0`?** Bei zwei `int`-Zahlen rechnet C# eine Ganzzahldivision:
  `8470 / 1000` ergibt `8`. Mit `1000.0` (Kommazahl) kommt `8,47` heraus. Ohne `.0` wäre die Auslastung
  falsch (`8470 * 100 / 9600` wird nur durch `100.0` zur Kommazahl).
- **Warum steht bei Reihe 1 / Modul 4 die 400 und nicht 401 wie im Beispiel?** Die Angabe sagt
  „Maximalwert beachten!“: ein Modul schafft höchstens 400 W, 401 W wäre also unmöglich. Deshalb 400 W.
  Gesamtleistung und Auslastung bleiben gleich (8,47 kW, 88,2 %), nur Reihe 1 hat 2338 statt 2339 W.
- **Was macht `int.TryParse`?** Es versucht, den Text in eine Zahl umzuwandeln. Bei `x` klappt das nicht,
  dann setze ich `auswahl = -1` und lande im `default`-Fall des `switch`.

## Starten

```bash
dotnet run --project "UE04_Verzweigungen-Arrays-Klassen_Einfach/A4_Solaranlage"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
