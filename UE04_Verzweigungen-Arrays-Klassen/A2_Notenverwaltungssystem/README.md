# A2 – Notenverwaltungssystem

## Aufgabe (zusammengefasst)

Gebaut wird eine kleine Notenverwaltung für eine Schule:

- Eine Klasse **`Student`** hat einen Namen und ein Noten-Array. Beides wird im Konstruktor übergeben.
- **`GetNoten()`** liefert das Noten-Array.
- **`BerechneNotendurchschnitt()`** liefert den Durchschnitt aller Noten, auf 2 Nachkommastellen genau.
- Im Hauptprogramm werden drei Studenten angelegt und in einem Array gespeichert. Für jeden werden Name, Noten (mit `string.Join(" / ", student.GetNoten())`) und Durchschnitt ausgegeben.
- Jede zusätzliche Klasse kommt in eine eigene Datei. Datentypen und Zugriffsmodifikatoren sollen bewusst gewählt werden: Wer darf von außen lesen, wer darf setzen?

## Klassisch vs. Modern

| Thema | Klassisch | Modern |
|-------|-----------|--------|
| Konstruktor | klassischer Konstruktor, `this.feld = parameter` | Primary Constructor `class Student(string name, IEnumerable<int> noten)` |
| Name | `private readonly` Feld + `GetName()` | Property `Name { get; }` |
| `GetNoten()` | gibt das `int[]`-Feld direkt zurück (wörtlich laut Angabe). Ein Aufrufer könnte es verändern, siehe Kommentar | gibt `IReadOnlyList<int>` zurück, intern eine **Kopie** in einer schreibgeschützten Hülle, also echte Kapselung |
| Durchschnitt | `for`-Schleife, Cast `(double)` gegen Ganzzahl-Division, `Math.Round` | `Average()` + `Math.Round` |
| Array anlegen | `new Student[] { new Student("Andreas", new int[] { 1, 4, 3 }), ... }` | Collection-Expression `[new("Andreas", [1, 4, 3]), ...]` |

## Starten

```bash
dotnet run --project UE04_Verzweigungen-Arrays-Klassen/A2_Notenverwaltungssystem/Klassisch
dotnet run --project UE04_Verzweigungen-Arrays-Klassen/A2_Notenverwaltungssystem/Modern
```

## Beispiel-Ausgabe (echter Testlauf, beide Versionen identisch)

```text
Name: Andreas
Noten: 1 / 4 / 3
Notendurchschnitt: 2,67

Name: Paul
Noten: 2 / 2 / 5
Notendurchschnitt: 3

Name: Laura
Noten: 2 / 1 / 1
Notendurchschnitt: 1,33
```

Nachgerechnet: (1+4+3)/3 = 2,666… ergibt 2,67; (2+2+5)/3 = 3; (2+1+1)/3 = 1,333… ergibt 1,33.
