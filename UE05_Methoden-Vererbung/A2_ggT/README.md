# UE05 – Aufgabe 2: Größter gemeinsamer Teiler

## Was macht das Programm?

Du gibst eine untere und eine obere Grenze ein (ganze Zahlen ab 1, untere kleiner als obere). Das
Programm würfelt zwischen diesen Grenzen zwei Zufallszahlen und berechnet ihren größten gemeinsamen
Teiler (ggT), also die größte Zahl, durch die sich beide teilen lassen. Gerechnet wird zweimal mit dem
Euklidischen Algorithmus: einmal **rekursiv** und einmal mit einer **Schleife**. Beide Ergebnisse
werden ausgegeben und sind immer gleich. Ungültige Eingaben werden abgefangen und neu abgefragt.

## So zeigst du den Code

1. `Program.cs`, `LeseZahl`: Die Methode gibt die Frage aus und fragt in einer `while`-Schleife so
   lange neu, bis eine ganze Zahl ab 1 eingegeben wurde. Man braucht sie zweimal, deshalb eine Methode.
2. `Main`: Zwei Grenzen einlesen. Die `while`-Schleife prüft, ob untere < obere gilt, sonst kommt eine
   Fehlermeldung und die obere Grenze wird neu abgefragt.
3. `Main`: `rng.Next(untereGrenze, obereGrenze + 1)` – die obere Grenze zählt bei `Next` nicht mit,
   darum das `+ 1`.
4. `GgtRekursiv(a, b)`: Abbruchbedingung `b == 0` (dann ist `a` der ggT), sonst Selbstaufruf mit
   `(b, a % b)`.
5. `GgtSchleife(a, b)`: Dieselbe Rechnung, aber `a` und `b` werden in einer `while`-Schleife getauscht.
6. Der Kommentar am Ende von `Main`: der Vergleich der beiden Varianten.
7. Vorführen: Grenzen `abc` (Fehler), `10`, `5` (Fehler, obere muss größer sein), `60`. Dann
   kommen zwei Zufallszahlen und zweimal derselbe ggT.

## Wahrscheinliche Fragen

- **Wie funktioniert der Euklidische Algorithmus?** Man ersetzt `(a, b)` durch `(b, a % b)`, bis `b`
  gleich 0 ist. Dann ist `a` der ggT. Beispiel: ggT(48, 18) → (18, 12) → (12, 6) → (6, 0) → 6.
- **Was ist der Unterschied zwischen rekursiv und Schleife?** Rekursiv ruft sich die Methode selbst
  auf, die Schleife wiederholt denselben Block. Beide machen gleich viele `%`-Rechnungen und
  Vergleiche. Die Rekursion braucht aber pro Schritt einen Methodenaufruf (Speicher auf dem Stack),
  deshalb ist die Schleife etwas effizienter.
- **Warum `obereGrenze + 1`?** `rng.Next(a, b)` liefert Zahlen von `a` bis `b - 1`. Ohne `+ 1` könnte
  die obere Grenze selbst nie gewürfelt werden. In Python ist das wie `random.randrange(a, b)`.
- **Was heißt `static`?** Die Methode gehört zur Klasse selbst, man braucht kein Objekt (`new ...`).
  Eine nicht-statische Methode könnte `Main` nur über ein Objekt aufrufen.
- **Was ist Rekursion?** Die Methode ruft sich selbst mit kleineren Werten auf, bis die
  Abbruchbedingung (`b == 0`) erreicht ist. Ohne Abbruchbedingung würde sie sich endlos aufrufen.

## Starten

```bash
dotnet run --project "UE05_Methoden-Vererbung/A2_ggT"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
