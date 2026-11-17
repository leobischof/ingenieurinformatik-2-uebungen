# UE04 – Aufgabe 1: Multiplikationstabelle

## Was macht das Programm?

Das Programm rechnet das kleine Einmaleins aus, also alle Produkte von 1 × 1 bis 10 × 10, und gibt
sie als Tabelle auf der Konsole aus. Die Tabelle wird vorher komplett in einem **2-dimensionalen
Array** gespeichert. Erst danach wird sie ausgegeben. Es gibt keine Kopfzeile und keine Kopfspalte,
nur die Produkte selbst. Jede Zahl steht rechtsbündig, damit die Stellen untereinander stehen.

## So zeigst du den Code

1. `Program.cs`, `Main`: `int[,] tabelle = new int[10, 10];` legt das Array an. Dann wird es mit
   `FuelleTabelle` gefüllt und mit `GibTabelleAus` ausgegeben.
2. `FuelleTabelle`: Zwei verschachtelte `for`-Schleifen. Die äußere läuft über die Zeilen, die innere
   über die Spalten. Jede Zelle bekommt `(zeile + 1) * (spalte + 1)`. Das `+ 1` ist nötig, weil die
   Indizes bei 0 beginnen.
3. `GibTabelleAus`: Dieselben zwei Schleifen. `PadLeft(4)` macht aus jeder Zahl einen Text mit 4
   Zeichen, links mit Leerzeichen aufgefüllt. Das ergibt die rechtsbündige Ausrichtung.
   `Console.Write` schreibt ohne Zeilenumbruch, am Ende jeder Zeile setzt `Console.WriteLine()` einen.
4. Vorführen: Programm starten, die Tabelle zeigen.

## Wahrscheinliche Fragen

- **Was ist `int[,]`?** Ein 2-dimensionales Array, also eine Tabelle mit Zeilen und Spalten. In Python
  wäre das ungefähr eine Liste aus Listen. Hier hat aber jede Zeile garantiert gleich viele Spalten.
- **Warum `PadLeft(4)`?** Die größte Zahl ist 100 (drei Stellen). Mit 4 Zeichen bleibt immer ein
  Leerzeichen Abstand, und die Zahlen stehen rechtsbündig. In Python wäre das `str(x).rjust(4)`.
- **Warum `Console.Write` und nicht `WriteLine`?** `Write` bleibt in der Zeile, damit alle Zahlen einer
  Zeile nebeneinander stehen. Erst am Ende der Zeile kommt der Zeilenumbruch.
- **Was ist `Console.OutputEncoding = ...`?** Damit Umlaute richtig angezeigt werden. Die Windows-Konsole
  nimmt sonst eine alte Zeichentabelle.

## Starten

```bash
dotnet run --project "UE04_Verzweigungen-Arrays-Klassen_Einfach/A1_Multiplikationstabelle"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
