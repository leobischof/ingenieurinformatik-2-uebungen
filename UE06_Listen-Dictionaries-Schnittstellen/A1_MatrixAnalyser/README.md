# UE06 – Aufgabe 1: Matrix-Analyser

> Ausführliche Erklärung (Konzepte, Lösungsweg, Python-Vergleiche): [ERKLAERUNG.md](../ERKLAERUNG.md#aufgabe-1--matrix-analyser)

## Was macht das Programm?

Die Klasse `MatrixAnalyser` bekommt eine Zahlenmatrix und gibt sie aus, dazu den größten Wert,
den kleinsten Wert und die Mittelwerte der beiden Diagonalen. Getestet wird mit einer quadratischen
6×6-Matrix und einer 6×7-Matrix. Bei der nicht-quadratischen Matrix sind die Diagonalen-Mittelwerte 0.

## So zeigst du den Code

1. `MatrixAnalyser.cs` oben: drei private Felder. `GetLength(0)` liefert die Zeilen, `GetLength(1)` die Spalten.
2. `GetMaxValue`: zwei Schleifen von links oben nach rechts unten, Startwert ist `matrix[0, 0]`.
3. `GetMinValue`: dieselben Schleifen, aber rückwärts (`zeile--`, `spalte--`), Startwert ist das Element rechts unten.
4. `GetAverageDiagonal1/2`: zuerst die Prüfung „quadratisch?“, dann **eine** Schleife über `i`.
   Diagonale 1 nimmt `matrix[n - 1 - i, i]`, Diagonale 2 nimmt `matrix[i, n - 1 - i]`.
5. `Program.cs`: zwei Matrizen anlegen, je ein `MatrixAnalyser` erzeugen und `Analysiere()` aufrufen.

## Wahrscheinliche Fragen

- **Was ist `int[,]`?** Ein 2D-Array mit fester Größe, Zugriff mit `matrix[zeile, spalte]`. In Python
  wäre das eine Liste von Listen (`m[zeile][spalte]`) oder ein NumPy-Array.
- **Warum sind beide Diagonalen gleich (16,00)?** Laut Abbildung laufen beide über dieselbe Linie,
  nur in entgegengesetzter Richtung. Die Aufgabe übt die zwei Laufrichtungen.
- **Warum `(double)summe`?** Sonst teilt C# ganzzahlig (wie `//` in Python) und die Kommastelle fehlt.
- **Warum nicht `0` als Startwert beim Maximum?** Bei lauter negativen Zahlen wäre 0 falsch, darum
  wird mit dem ersten Element begonnen.

## Starten

```bash
dotnet run --project "UE06_Listen-Dictionaries-Schnittstellen/A1_MatrixAnalyser"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
