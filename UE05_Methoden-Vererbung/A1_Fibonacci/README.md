# UE05 – Aufgabe 1: Fibonacci rekursiv

## Was macht das Programm?

Du gibst ein, die wievielte Zahl der Fibonacci-Folge du willst (z. B. 12), und das Programm
rechnet sie aus (144). Jede Fibonacci-Zahl ist die Summe der zwei davor: 1, 1, 2, 3, 5, 8, 13, …
Gerechnet wird mit einer **rekursiven** Methode, also einer Methode, die sich selbst aufruft.
Ungültige Eingaben (Buchstaben, 0, negative Zahlen, zu große Zahlen) werden abgefangen, und das
Programm fragt dann noch einmal.

## So zeigst du den Code

1. `Program.cs` oben: `maxStelle` ist eine **statische Variable**. Sie gehört zur Klasse, nicht zu
   einem Objekt, deshalb kann `Main` (das auch static ist) direkt darauf zugreifen.
2. `Main`: Frage ausgeben, dann die `while`-Schleife: Sie fragt so lange neu, bis die Eingabe
   eine Zahl zwischen 1 und 40 ist.
3. `Fibonacci(n)`: zuerst die **Abbruchbedingung** (Stelle 1 und 2 → 1), dann der rekursive
   Aufruf `Fibonacci(n - 1) + Fibonacci(n - 2)`.
4. Vorführen: Programm starten, einmal `abc` eingeben (Fehlermeldung), dann `12` → 144.

## Wahrscheinliche Fragen

- **Was ist Rekursion?** Die Methode ruft sich selbst mit einer kleineren Zahl auf, bis sie bei
  der Abbruchbedingung ankommt. Ohne Abbruchbedingung würde sie sich endlos aufrufen und abstürzen.
- **Was heißt `static`?** Die Methode bzw. Variable gehört zur Klasse selbst. Man braucht kein
  Objekt (`new ...`), um sie zu benutzen. Eine nicht-statische Methode bräuchte zuerst ein Objekt.
- **Was macht `int.TryParse`?** Es versucht, den eingegebenen Text in eine Zahl umzuwandeln. Es
  liefert `true`, wenn das klappt, und schreibt die Zahl in `stelle` (das macht `out`). In Python
  wäre das ungefähr `try: stelle = int(input())`.
- **Warum maximal 40?** Die Rekursion rechnet vieles doppelt, ab ca. 40 wird sie spürbar langsam.
  Ab Stelle 47 ist das Ergebnis zu groß für einen `int`.
- **Was ist `$"..."`?** Ein Text mit eingesetzten Variablen, genau wie ein f-String in Python.

## Starten

```bash
dotnet run --project "UE05_Methoden-Vererbung/A1_Fibonacci"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
