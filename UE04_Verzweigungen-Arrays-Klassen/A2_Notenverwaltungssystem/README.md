# UE04 – Aufgabe 2: Notenverwaltungssystem

## Was macht das Programm?

Es gibt drei Studenten mit Namen und Noten. Jeder Student ist ein **Objekt** der Klasse `Student`.
Die drei Objekte liegen in einem Array. Das Programm geht das Array durch und gibt für jeden Studenten
Name, Noten und Notendurchschnitt aus. Der Durchschnitt wird auf 2 Nachkommastellen gerundet.

## So zeigst du den Code

1. `Student.cs`, Felder: `private string name` und `private int[] noten`. `private` heißt, dass man
   Name und Noten von außen nicht direkt ändern kann. Man kommt nur über die Methoden heran.
2. `Student.cs`, Konstruktor: `public Student(string name, int[] noten)` wird bei `new Student(...)`
   aufgerufen und speichert Name und Noten.
3. `Student.cs`, `BerechneNotendurchschnitt`: Erst wird die Summe in einer `for`-Schleife berechnet.
   Dann `(double)summe / noten.Length`. Das `(double)` ist wichtig, sonst würde C# eine Ganzzahl-Division
   machen (8 / 3 = 2). `Math.Round(..., 2)` rundet auf 2 Nachkommastellen.
4. `Program.cs`, `Main`: Das Array `Student[] studenten` mit den drei `new Student(...)`. Dann
   `foreach`, das jeden Studenten nacheinander durchgeht. `string.Join(" / ", ...)` setzt die Trenner
   zwischen die Noten.
5. Vorführen: Programm starten, die Ausgabe für Andreas (2,67), Paul (3) und Laura (1,33) zeigen.

## Wahrscheinliche Fragen

- **Was ist eine Klasse, was ein Objekt?** Die Klasse `Student` ist der Bauplan. Mit `new Student(...)`
  entsteht daraus ein Objekt. Aus einer Klasse kann man beliebig viele Objekte machen, jedes hat seine
  eigenen Werte. In Python wäre das eine Klasse mit `__init__`.
- **Was macht `private`?** Das Feld ist nur innerhalb der Klasse sichtbar. Von außen kommt man nur über
  `GetName()` und `GetNoten()` heran.
- **Warum `(double)` vor `summe`?** Summe und Anzahl sind beide `int`. Ohne den Cast rechnet C# ganzzahlig
  und schneidet die Nachkommastellen ab. Mit `(double)` wird die Summe zur Kommazahl.
- **Was macht `foreach`?** Es geht ein Array der Reihe nach durch, ohne Index. In Python wäre das
  `for student in studenten:`.
- **Was macht `string.Join`?** Es verbindet alle Elemente eines Arrays zu einem Text und setzt den Trenner
  nur dazwischen. In Python wäre das `" / ".join(...)`.

## Starten

```bash
dotnet run --project "UE04_Verzweigungen-Arrays-Klassen_Einfach/A2_Notenverwaltungssystem"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
