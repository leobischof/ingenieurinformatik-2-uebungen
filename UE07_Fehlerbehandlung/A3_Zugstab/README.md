# UE07 – Aufgabe 3: Zugstab

> Ausführliche Erklärung (Konzepte, Lösungsweg, Python-Vergleiche): [ERKLAERUNG.md](../ERKLAERUNG.md#aufgabe-3--zugstab)

## Was macht das Programm?

Für einen runden Stab werden Durchmesser `d`, Streckgrenze `Re` und Zugkraft `F` eingegeben. Das
Programm berechnet die Spannung `σ = F / A` mit `A = π · d² / 4` und den Sicherheitsfaktor `S = Re / σ`.
Ist `σ > Re`, wird der Stab plastisch verformt: Es kommt eine Meldung und man gibt neue Werte ein.
Ungültige Eingaben werden einzeln nachgefragt. Am Ende steht immer „Auf Wiedersehen!“.

## So zeigst du den Code

1. `Zugstab.cs` → Konstruktor: wirft `ArgumentOutOfRangeException`, wenn `d` oder `Re` ≤ 0 ist.
2. `Spannung(kraft)`: Fläche, Spannung, und bei `σ > Re` wird `InvalidOperationException` geworfen.
3. `Program.cs` → `LeseWert`: `while (true)` mit `try`, fragt nur diesen einen Wert neu, bis er passt.
4. `Main`: äußeres `try` mit `catch (Exception)` und `finally` („Auf Wiedersehen!“), innen die Schleife
   mit einem zweiten `try`, das den plastischen Fall abfängt und neu fragen lässt.

## Wahrscheinliche Fragen

- **Warum zwei `try` ineinander?** Das innere behandelt den erwarteten Fall (plastisch → neu eingeben),
  das äußere fängt Unerwartetes ab und sorgt per `finally` für die Verabschiedung.
- **Warum `InvalidOperationException`?** Jeder Wert ist einzeln gültig, aber die Kombination geht nicht.
  Für einzelne ungültige Werte passt dagegen `ArgumentOutOfRangeException`.
- **Warum prüft der Konstruktor, obwohl `LeseWert` schon ≤ 0 verhindert?** Die Klasse soll sicher sein, auch
  wenn sie jemand ohne `LeseWert` verwendet. Jede Klasse prüft ihre eigenen Regeln.
- **Was ist `Math.Pow` und `Math.PI`?** Potenz und π, wie `math.pow` und `math.pi` in Python.

## Starten

```bash
dotnet run --project "UE07_Fehlerbehandlung/A3_Zugstab"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
Vorführen: `abc`, `-5`, dann `10` / `235` / `100000` (plastisch), dann `10` / `235` / `10000` → σ = 127,32, S = 1,85.
