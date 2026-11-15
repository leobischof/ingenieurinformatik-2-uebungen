# UE06 – Aufgabe 2: Stückliste

> Ausführliche Erklärung (Konzepte, Lösungsweg, Python-Vergleiche): [ERKLAERUNG.md](../ERKLAERUNG.md#aufgabe-2--stückliste)

## Was macht das Programm?

Es liest `Stueckliste.csv` ein, macht aus jeder Zeile ein `Component`-Objekt und speichert alle in
einer `List<Component>`. Die Liste wird zuerst unsortiert ausgegeben, dann nach **Material** und bei
gleichem Material nach **Masse** sortiert und nochmal ausgegeben.

## So zeigst du den Code

1. `Component.cs`: die Klasse implementiert `IComparable<Component>`, also das Versprechen
   „ich habe eine `CompareTo`-Methode“.
2. `CompareTo`: zuerst Material mit `string.Compare` vergleichen. Nur wenn das 0 ist (gleich),
   entscheidet die Masse.
3. `Program.cs` → `LeseStueckliste`: `File.ReadAllLines`, Schleife ab Zeile 1 (Zeile 0 ist die Kopfzeile),
   `Split(';')`, Masse mit deutscher Zahlenschreibweise umwandeln, `liste.Add(...)`.
4. `Main`: einlesen, ausgeben, `stueckliste.Sort()`, nochmal ausgeben.

## Wahrscheinliche Fragen

- **Was ist `List<Component>`?** Eine Liste wie in Python, aber es dürfen nur `Component`-Objekte hinein.
  `Add` = `append`, `Count` = `len`.
- **Woher weiß `Sort()`, wie sortiert wird?** Es ruft immer wieder unser `CompareTo` auf. In Python
  wäre das `sort(key=lambda c: (c.material, c.masse))`.
- **Warum `;` statt `,` als Trennzeichen?** Die Massen haben ein Dezimalkomma (`3,265`). Mit `,` würde
  jede Masse in zwei Teile zerfallen.
- **Warum `CultureInfo("de-DE")`?** Damit `3,265` als 3.265 gelesen wird, egal wie der Computer eingestellt ist.
- **Warum stehen manche Bauteile ohne Material ganz oben?** Normteile haben in der CSV kein Material.
  Ein leerer Text kommt alphabetisch vor allen anderen, wie im Beispiel der Angabe.

## Starten

```bash
dotnet run --project "UE06_Listen-Dictionaries-Schnittstellen/A2_Stueckliste"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken. Die CSV wird beim Bauen automatisch neben das Programm kopiert.
