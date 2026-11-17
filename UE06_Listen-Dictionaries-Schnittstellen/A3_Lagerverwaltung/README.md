# UE06 – Aufgabe 3: Lagerverwaltung

> Ausführliche Erklärung (Konzepte, Lösungsweg, Python-Vergleiche): [ERKLAERUNG.md](../ERKLAERUNG.md#aufgabe-3--lagerverwaltung)

## Was macht das Programm?

Ein Lager mit Menü. Die Artikel liegen in einem `Dictionary<string, Artikel>` (Schlüssel = Artikelnummer).
Man kann den Bestand anzeigen, Artikel anlegen, Waren ein- und ausbuchen, Artikel löschen, den
Gesamtwert berechnen und ein Experiment zu `ContainsKey`/`ContainsValue` starten. Fehler wie doppelte
Nummern, zu wenig Bestand oder unbekannte Artikel werden gemeldet.

## So zeigst du den Code

1. `Artikel.cs`: vier Felder, Getter, `Einlagern(menge)` und `Entnehmen(menge)`. `Entnehmen` gibt
   `false` zurück und ändert nichts, wenn zu wenig da ist.
2. `Program.cs` → `Main`: Dictionary mit vier Startartikeln, dann die Menü-Schleife mit `switch`.
3. Pro Menüpunkt eine Methode: `ArtikelAnlegen` (prüft mit `ContainsKey`), `BuchungDurchfuehren`
   (holt mit `TryGetValue`), `ArtikelLoeschen` (`Remove` gibt `true`/`false`), `ZeigeGesamtwert` (`lager.Values`).
4. `Experiment`: ersten Artikel holen, eine Kopie mit gleichen Daten bauen, `ContainsValue` mit beiden testen.
5. Die Kommentare a) und b) im Code beantworten die Theoriefragen.

## Wahrscheinliche Fragen

- **Was ist ein Dictionary?** Dasselbe wie ein `dict` in Python: Schlüssel → Wert.
  `ContainsKey(k)` = `k in d`, `TryGetValue` ≈ `d.get(k)`.
- **Was macht `out` bei `TryGetValue`?** Die Methode gibt `true`/`false` zurück und schreibt den gefundenen
  Artikel zusätzlich in die Variable nach `out`.
- **Warum ist `ContainsValue(Kopie)` false?** Objekte werden über ihre Referenz verglichen: Ist es genau
  dasselbe Objekt im Speicher? Die Kopie ist ein anderes Objekt mit gleichem Inhalt (Python: `is` statt `==`).
- **Warum Dictionary statt List?** Artikel werden immer über die eindeutige Nummer gesucht, das geht direkt
  über den Schlüssel, ohne die ganze Liste durchzugehen. Doppelte Nummern sind dadurch auch ausgeschlossen.
- **Warum `ToUpper()` bei der Nummer?** Damit `b-100` auch `B-100` findet.

## Starten

```bash
dotnet run --project "UE06_Listen-Dictionaries-Schnittstellen/A3_Lagerverwaltung"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
Vorführen: `1` (Bestand), `2` + `a-100` (existiert schon), `3` + `b-100` + `2` + `30` (zu wenig), `5` (Gesamtwert).
