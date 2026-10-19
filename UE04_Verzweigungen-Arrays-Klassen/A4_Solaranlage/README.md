# A4 – Leistungsübersicht einer Solaranlage

## Aufgabe (zusammengefasst)

Auf einem Hallendach steht eine PV-Anlage mit **4 Reihen zu je 6 Modulen**, jedes Modul hat **400 W** Nennleistung. Gesucht ist ein kleines Monitoring-Tool:

- Die Klasse **`Solaranlage`** speichert Standort, Modulnennleistung und die gemessenen Modulleistungen als **2D-Array** (in W). Standort und Nennleistung kommen über den Konstruktor. Die Messwerte werden im Konstruktor mit frei gewählten Werten befüllt, die die Nennleistung nicht überschreiten dürfen.
- Diese Methoden sind gefordert:
  - `MesswerteAnzeigen()` gibt alle Werte als Tabelle aus, mit verschachtelten Schleifen.
  - `BerechneGesamtleistung()` liefert die Summe aller Werte, mit einer `foreach`-Schleife.
  - `BerechneGesamtauslastung()` liefert die Gesamtleistung in % der Maximalleistung.
  - `BerechneReihenleistung()` liefert die Leistung je Reihe als 1D-Array.
- Das Hauptprogramm zeigt ein Menü, bis 0 eingegeben wird. Bei Menüpunkt 3 wird zusätzlich die schwächste Reihe ermittelt.

## Umsetzung und Entscheidungen

- **Messwerte**: Übernommen aus dem Beispiel der Angabe, mit einer Korrektur. Dort steht bei Reihe 1 / Modul 4 der Wert **401 W**, das liegt über der Nennleistung von 400 W. Er wurde deshalb auf **400 W** korrigiert. Reihe 1 hat dadurch 2338 W statt 2339 W. Die gerundeten Ausgaben (8,47 kW, 88,2 %) bleiben gleich.
- **Sicherheitsnetz**: Zusätzlich begrenzt der Konstruktor jeden Wert auf 0 … Nennleistung (klassisch mit `if`, modern mit `Math.Clamp`).
- **Maximalleistung**: `Reihen × Module × Nennleistung` wird aus `GetLength(0)`/`GetLength(1)` berechnet und ist nicht hart codiert.
- **Kapselung**: Das Messwert-Array bleibt `private` und wird nie herausgegeben. `BerechneReihenleistung()` liefert bei jedem Aufruf ein neues Array.
- **Formatierung**: Gesamtleistung in kW mit 2 Nachkommastellen (`F2`), Auslastung in % mit 1 Nachkommastelle (`F1`). Die schwächste Reihe wird 1-basiert ausgegeben.
- **Eingaben**: Buchstaben, leere Eingaben und unbekannte Zahlen ergeben „Ungültige Auswahl“. Bei Eingabeende (EOF) beendet sich das Programm wie bei 0.

## Klassisch vs. Modern

| Thema | Klassisch | Modern |
|-------|-----------|--------|
| Menüschleife | `do-while` + `switch`-Anweisung mit `break` | `while (true)` + `switch`-Ausdruck, der eine `Action` liefert |
| Menüauswahl | `int.TryParse`, Menüpunkte als `int`-Konstanten | direkter Vergleich mit `string`-Konstanten, Pattern `is null or "0"` |
| Klasse | `private readonly` Felder, Konstruktor | Primary Constructor, Properties `{ get; }`, berechnete Properties (`AnzahlReihen`, `Maximalleistung`) |
| `BerechneGesamtleistung()` | `foreach` (laut Angabe) | `foreach` (laut Angabe; LINQ-Alternative `Cast<int>().Sum()` im Kommentar) |
| `BerechneReihenleistung()` | verschachtelte `for`-Schleifen | `Enumerable.Range` + `Select` + `Sum` + `ToArray()` |
| Schwächste Reihe | klassische Minimumsuche mit `for` | `Enumerable.Range(...).MinBy(...)` |
| Tabelle | `PadLeft`/`PadRight` | Interpolation mit Alignment `{wert,6}`, `{text,-10}` |

## Starten

```bash
dotnet run --project UE04_Verzweigungen-Arrays-Klassen/A4_Solaranlage/Klassisch
dotnet run --project UE04_Verzweigungen-Arrays-Klassen/A4_Solaranlage/Modern
```

## Beispiel-Ausgabe (echter Testlauf, beide Versionen identisch)

Eingabe: `1`, `2`, `3`, `x` (ungültig), `0`

```text
========== PV-Monitoring ==========
1 ... Anlage anzeigen
2 ... Gesamtleistung und Auslastung
3 ... Leistung pro Reihe
0 ... Programm beenden
Auswahl: 1

PV-Anlage Dach Halle A (400 W pro Modul)
              M1    M2    M3    M4    M5    M6
Reihe 1:     385   392   378   400   388   395
Reihe 2:     380   391   120   390   379   386
Reihe 3:     372   381   369   377   375   383
Reihe 4:     390   398   385     0   260   396

========== PV-Monitoring ==========
1 ... Anlage anzeigen
2 ... Gesamtleistung und Auslastung
3 ... Leistung pro Reihe
0 ... Programm beenden
Auswahl: 2
Gesamtleistung: 8,47 kW
Auslastung:     88,2 %

========== PV-Monitoring ==========
1 ... Anlage anzeigen
2 ... Gesamtleistung und Auslastung
3 ... Leistung pro Reihe
0 ... Programm beenden
Auswahl: 3
Reihe 1:   2338 W
Reihe 2:   2046 W
Reihe 3:   2257 W
Reihe 4:   1829 W
Schwächste Reihe: 4

========== PV-Monitoring ==========
1 ... Anlage anzeigen
2 ... Gesamtleistung und Auslastung
3 ... Leistung pro Reihe
0 ... Programm beenden
Auswahl: x
Ungültige Auswahl! Bitte 1, 2, 3 oder 0 eingeben.

========== PV-Monitoring ==========
1 ... Anlage anzeigen
2 ... Gesamtleistung und Auslastung
3 ... Leistung pro Reihe
0 ... Programm beenden
Auswahl: 0
Programm beendet.
```

Nachgerechnet: 2338 + 2046 + 2257 + 1829 = 8470 W, das sind 8,47 kW. Maximal möglich sind 4 × 6 × 400 W = 9600 W, also 8470 / 9600 = 88,23 %, ausgegeben als 88,2 %.
