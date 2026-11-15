# UE07 – Aufgabe 2: Ausschussquote

> Ausführliche Erklärung (Konzepte, Lösungsweg, Python-Vergleiche): [ERKLAERUNG.md](../ERKLAERUNG.md#aufgabe-2--ausschussquote)

## Was macht das Programm?

Es fragt nach produzierten Teilen und Ausschussteilen und berechnet die Ausschussquote in Prozent
(1200 und 30 → 2,50 %). Text statt Zahl ergibt „Ungültige Eingabe!“, unsinnige Werte (0 Teile, mehr
Ausschuss als produziert) ergeben „Unplausible Eingabe!“ mit Begründung. Nach jeder Berechnung
kommt die Frage, ob man weitermachen will.

## So zeigst du den Code

1. `BerechneAusschussquote` (unten): prüft die Werte und wirft mit `throw` eine `ArgumentException` mit eigenem Text.
2. `Main`: `while (weiter)`, darin das `try` mit `int.Parse` (zweimal) und dem Methodenaufruf.
3. Drei `catch`-Blöcke: `FormatException` (Text), `OverflowException` (Zahl zu groß), `ArgumentException`
   (unser eigenes `throw`, Text kommt aus `ex.Message`).
4. `finally`: fragt „Weitere Berechnung?“, und zwar nach jedem Durchlauf, egal ob ein Fehler war.

## Wahrscheinliche Fragen

- **Was macht `throw`?** Löst selbst einen Fehler aus, wie `raise` in Python. Die Methode bricht sofort ab
  und das Programm springt in den passenden `catch` in `Main`.
- **Wann läuft `finally`?** Immer: nach erfolgreichem `try` und auch nach jedem `catch`.
- **Warum `int.Parse` und nicht `TryParse`?** `TryParse` meldet Fehler nur mit `false`. Hier sollen bewusst
  Exceptions geübt werden.
- **Warum prüft die Methode und nicht `Main`?** Die Methode weiß, was falsch ist, `Main` entscheidet, wie
  es angezeigt wird. So ist die Methode auch woanders verwendbar.
- **Warum `(double)`?** Sonst wäre `30 / 1200` ganzzahlig 0.

## Starten

```bash
dotnet run --project "UE07_Fehlerbehandlung/A2_Ausschussquote"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
Vorführen: `1200`/`30`, dann `drei`, dann `0`/`5`, dann `100`/`150`, am Ende `n`.
