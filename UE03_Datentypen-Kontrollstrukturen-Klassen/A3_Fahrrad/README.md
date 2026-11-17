# A3 – Erstes Objekt: Fahrrad

## Aufgabe (in eigenen Worten)

Es gibt eine „vereinfachte“ Klasse `Fahrrad` mit genau zwei öffentlichen Attributen: `brand`
(string) und `numberGears` (int). In `Main` der Klasse `Program` werden zwei Fahrrad-Objekte mit
frei gewählten Werten erzeugt, und ihre Daten werden ausgegeben. Danach stellt sich heraus, dass bei
einem Fahrrad die Gangzahl falsch eingegeben wurde. Sie wird korrigiert, und die Daten werden noch
einmal ausgegeben.

**Klasse vs. Objekt:** Die Klasse ist der Bauplan (welche Attribute ein Fahrrad hat). Ein Objekt ist
ein konkretes Fahrrad, das mit `new` nach diesem Bauplan erzeugt wird und eigene Werte hat.

## Lösungsweg

- **Attribute:** public **Felder**: `public string brand = "";`
- **Pflichtwerte:** Startwert `""` gegen die Nullable-Warnung
- **Objekte erzeugen:** `new Fahrrad()` + einzelne Zuweisungen
- **Ausgabe:** Text zweimal per `+` und `"\n"` zusammengesetzt
- **Program/Main:** ausdrücklich geschrieben

Die Namen `brand` und `numberGears` gibt die Angabe vor und werden im Code verwendet.
Üblich wären in C# `Brand` und `NumberGears`.

## Starten

```powershell
dotnet run --project "UE03_Datentypen-Kontrollstrukturen-Klassen/A3_Fahrrad"
```

## Beispiel-Ausgabe

Das Programm braucht keine Eingabe.

```text
Informationen zu den Fahrrädern:
Fahrrad 1: Marke: Cube, Anzahl der Gänge: 18
Fahrrad 2: Marke: Trek, Anzahl der Gänge: 21

Die Anzahl der Gänge von Fahrrad 2 wurde korrigiert.

Aktualisierte Informationen zu den Fahrrädern:
Fahrrad 1: Marke: Cube, Anzahl der Gänge: 18
Fahrrad 2: Marke: Trek, Anzahl der Gänge: 24
```
