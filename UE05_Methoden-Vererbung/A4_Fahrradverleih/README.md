# UE05 – Aufgabe 4: Fahrradverleih

## Was macht das Programm?

Das Programm zeigt eine Tabelle mit drei Fahrrädern (Citybike, Mountainbike, E-Bike) samt Grundgebühr
und Preisen. Du wählst ein Modell und buchst optional zusätzliche Kilometer und Stunden (je 20 km und
3 Stunden sind inklusive). Am Ende werden Gesamtkosten, Gesamtzeit und Gesamtstrecke ausgegeben. Beim
E-Bike kommen 20 Euro Pauschale dazu, wenn die Strecke über 70 km oder die Zeit über 6 Stunden liegt.
Ungültige Eingaben (Buchstaben, Zahlen außerhalb des Bereichs, etwas anderes als j/n) werden abgefangen.

## So zeigst du den Code

1. `Fahrrad.cs`: Die Klasse ist **abstract**, es gibt also kein allgemeines Fahrrad, nur die drei
   Arten. Oben die **statischen** Werte `inklusiveKm` und `inklusiveStunden` (gelten für alle
   Fahrräder gleich). Darunter die privaten Felder mit Get-/Set-Methoden.
2. `Fahrrad.cs` weiter unten: `GetModellname()` ist **abstract** (jede Art hat einen anderen Namen,
   die Unterklassen müssen sie schreiben). `BerechneKosten()` ist **virtual** (normale Rechnung,
   aber das E-Bike darf sie ändern).
3. `Citybike.cs` (Mountainbike genauso): `: base(15, 0.30, 4)` gibt Grundgebühr und Preise an den
   Konstruktor von `Fahrrad` weiter. Das ist die **Konstruktorenverkettung**.
4. `EBike.cs`: `override BerechneKosten()` ruft mit `base.BerechneKosten()` die normale Rechnung auf
   und addiert die Pauschale, wenn mehr als 70 km oder 6 Stunden zusammenkommen.
5. `Program.cs`, `Main`: Array `Fahrrad[]` mit allen drei Modellen, Tabelle, Modell wählen, j/n-Fragen,
   dann `fahrrad.BerechneKosten()`. Hier wird automatisch die richtige Version aufgerufen.
6. `Program.cs`, die drei statischen Hilfsmethoden: `LeseZahl`, `LeseJaNein`, `ZeigeModelltabelle`.
7. Vorführen: `5` oder `x` beim Modell eingeben (Fehlermeldung), dann Modell 3 mit `j`, `51`, `n`
   (71 km, also 90,70 Euro mit Pauschale). Zum Vergleich Modell 2 mit `j`, `35`, `j`, `1` → 48,50 Euro.

## Wahrscheinliche Fragen

- **Was ist eine abstrakte Klasse?** Eine Klasse, von der man kein Objekt erzeugen kann
  (`new Fahrrad()` geht nicht). Sie dient nur als gemeinsame Vorlage für die Unterklassen. In Python
  wäre das eine Basisklasse mit `ABC`.
- **Was ist eine abstrakte Methode?** Eine Methode ohne Inhalt, nur mit Kopf (`GetModellname()`). Jede
  Unterklasse muss sie mit `override` selbst schreiben, sonst gibt es einen Fehler.
- **Was ist der Unterschied zwischen `virtual` und `override`?** `virtual` erlaubt der Unterklasse,
  die Methode zu ersetzen, `override` ersetzt sie wirklich. Ruft man `BerechneKosten()` über eine
  Variable vom Typ `Fahrrad` auf, läuft trotzdem die Version des echten Objekts (bei EBike mit Pauschale).
- **Was macht `: base(...)`?** Es ruft den Konstruktor der Oberklasse auf. `Citybike` gibt damit 15,
  0.30 und 4 an `Fahrrad` weiter, wo sie in den Feldern gespeichert werden (Konstruktorenverkettung).
  In Python wäre das `super().__init__(15, 0.30, 4)`.
- **Was heißt `static` und warum bei `inklusiveKm`?** Der Wert gehört zur Klasse, nicht zu einem
  einzelnen Objekt. Die inklusiven 20 km und 3 Stunden sind für alle Fahrräder gleich, also gibt es
  sie nur einmal. Aufruf ohne Objekt: `Fahrrad.GetInklusiveKm()`.
- **Warum steckt die Pauschale im `EBike` und nicht in `Fahrrad`?** Nur das E-Bike hat sie.
  Würde sie in `Fahrrad` stehen, müsste die Oberklasse E-Bike-Sonderfälle kennen. So bleibt
  `Fahrrad` allgemein, und ein neues Modell mit eigener Regel bekommt einfach eine eigene Klasse.

## Starten

```bash
dotnet run --project "UE05_Methoden-Vererbung/A4_Fahrradverleih"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
