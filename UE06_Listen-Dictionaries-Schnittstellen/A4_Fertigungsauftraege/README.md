# UE06 – Aufgabe 4: Fertigungsaufträge

> Ausführliche Erklärung (Konzepte, Lösungsweg, Python-Vergleiche): [ERKLAERUNG.md](../ERKLAERUNG.md#aufgabe-4--fertigungsaufträge)

## Was macht das Programm?

Acht Fertigungsaufträge sollen auf einer Maschine nacheinander gefertigt werden. Das Programm zeigt
alle Aufträge, lässt einen stornieren und plant die Reihenfolge dann zweimal: nach der **KOZ-Regel**
(kürzeste Bearbeitungszeit zuerst) und nach der **FLT-Regel** (frühester Liefertermin zuerst). Für jede
Reihenfolge kommen Ende, Verspätung, mittlere Durchlaufzeit und die Anzahl verspäteter Aufträge.

## So zeigst du den Code

1. `Auftrag.cs`: vier Felder, darunter `TimeSpan bearbeitungszeit` (Dauer) und `DateTime liefertermin` (Zeitpunkt).
   `CompareTo` ist die KOZ-Regel, also die Standard-Sortierung.
2. `LieferterminComparer.cs`: eigene Klasse mit `IComparer<Auftrag>`, deren `Compare(a, b)` die FLT-Regel ist.
3. `Program.cs` → `Main`: Start = heute 06:00, Aufträge in die Liste, Stornieren-Schleife,
   dann `Sort()` (KOZ) und `Sort(new LieferterminComparer())` (FLT).
4. `GibPlanAus`: Ende = voriges Ende + Dauer, Verspätung = Ende − Termin (nie negativ), Durchlaufzeit = Ende − Start.

## Wahrscheinliche Fragen

- **Was ist der Unterschied zwischen `IComparable` und `IComparer`?** `IComparable` steckt in der Klasse
  selbst und ist die Standard-Sortierung (`Sort()`). `IComparer` ist eine eigene Klasse für eine zusätzliche
  Sortierung, die man `Sort(...)` mitgibt. In Python: `__lt__` vs. `sort(key=...)`.
- **Was sind `DateTime` und `TimeSpan`?** Zeitpunkt und Dauer, wie `datetime` und `timedelta` in Python.
  Zeitpunkt − Zeitpunkt ergibt eine Dauer.
- **Warum `for` mit Index beim Stornieren?** Während eines `foreach` darf man nichts aus der Liste löschen.
- **Welche Regel ist besser?** KOZ hat die kürzere mittlere Durchlaufzeit (13,14 h), aber 3 Verspätungen.
  FLT hat nur 1 Verspätung, dafür 16,14 h Durchlaufzeit.
- **Warum nicht 4,29 h wie im Beispiel?** 4,29 h ist nur der Mittelwert der Bearbeitungszeiten und wäre bei
  beiden Regeln gleich. Die echte Durchlaufzeit (Start bis fertig) zeigt den Unterschied.

## Starten

```bash
dotnet run --project "UE06_Listen-Dictionaries-Schnittstellen/A4_Fertigungsauftraege"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken. Vorführen: zuerst `9999` (gibt es nicht), dann `1003`.
