# UE05 – Aufgabe 3: Immobilienverwaltung

## Was macht das Programm?

Das Programm berechnet die Jahreskosten (Verwaltung + Betrieb) für drei Arten von Immobilien:
Einfamilienhaus, Zinshaus und Geschäftsfläche. Du wählst die Art im Menü, gibst die Fläche ein und
je nach Art noch Garten/Garage bzw. die Anzahl der Wohnungen. Alle drei Arten **erben** von der
Basisklasse `Immobilie` (Fläche, Standardsätze 4,50 € + 21,47 € pro m²) und ergänzen oder ändern nur,
was bei ihnen anders ist. Ungültige Eingaben werden abgefangen, und das Programm fragt noch einmal.

Beispiele: EFH, 120 m², Garten ja, Garage nein → 3316,4 Euro. Zinshaus, 1000 m², 30 Wohnungen →
27470 Euro. Geschäftsfläche, 100 m² → 4121 Euro.

**Achtung, Widerspruch in der Angabe:** Der Angabetext sagt 21,47 € Betriebskosten pro m², die
Beispiel-Screenshots (986,4 und 8470) passen aber nur zu 2,47 € pro m². Beim Zinshaus stimmt das
genau (1000 · 6,97 + 30 · 50 = 8470). Beim EFH ergibt 120 · 6,97 + 150 = 986,4, der Screenshot hat
also offenbar auch 150 statt 200 für den Garten verrechnet. Wir rechnen mit dem Text (21,47, Garten
200). Das steht als Kommentar in `Immobilie.cs`. Sag das ruhig vorher an, falls jemand fragt,
warum bei dir nicht 986,4 herauskommt.

## So zeigst du den Code

1. `Immobilie.cs`: Die Basisklasse. `flaeche` ist `private` (Datenkapselung), Zugriff nur über
   `GetFlaeche()` / `SetFlaeche()`. Die Sätze sind `static`: Es gibt sie nur einmal für alle
   Immobilien. `BerechneJahreskosten()` ist `virtual`, damit Unterklassen sie ersetzen dürfen.
2. `Einfamilienhaus.cs`: `: Immobilie` heißt Vererbung. `: base(flaeche)` ist die
   Konstruktorenverkettung. Die `override`-Methode ruft mit `base.BerechneJahreskosten()` zuerst
   die Standardkosten ab und addiert Garten (200) und Garage (150).
3. `Zinshaus.cs`: Gleiches Muster, nur mit 50 € pro Wohnung.
4. `Geschaeftsflaeche.cs`: Hier steht `protected new static double ...`. Das ist die
   **Verdeckung**: gleicher Name wie in der Basisklasse, aber andere Werte (6,00 und 35,21).
   Deshalb kein `base.` im override, sonst würden die alten Sätze verwendet.
5. `Program.cs`: Menü, dann `switch` auf die Auswahl. Das Objekt wird in einer Variablen vom Typ
   `Immobilie` gespeichert. Der Aufruf `immobilie.BerechneJahreskosten()` nimmt automatisch die
   Methode der richtigen Unterklasse (das ist der Sinn von `virtual`/`override`).
6. `LeseZahl` und `LeseFlaeche`: kleine statische Hilfsmethoden, die so lange neu fragen, bis die
   Eingabe gültig ist.
7. Vorführen: `x` im Menü (Fehlermeldung), dann `1`, `120`, `1`, `2` → 3316,4.

## Wahrscheinliche Fragen

- **Was ist Vererbung?** Eine Klasse übernimmt Felder und Methoden einer anderen (`: Immobilie`)
  und kann sie ergänzen oder ändern. So muss die Fläche und die Grundrechnung nur einmal stehen.
- **Was heißt `virtual` und `override`?** `virtual` in der Basisklasse erlaubt, die Methode in
  einer Unterklasse zu ersetzen. `override` ersetzt sie dort. Bei einer `Immobilie`-Variablen
  wird zur Laufzeit die Methode des echten Objekts aufgerufen. Python macht das automatisch, in C#
  muss man es mit diesen Wörtern erlauben.
- **Was ist Verdeckung (`new`)?** Die Unterklasse legt eine Variable mit demselben Namen wie die
  Basisklasse an. Innerhalb der Unterklasse gilt dann die neue Variable, die alte wird verdeckt.
  `new` sagt dem Compiler: Das ist Absicht. Anders als bei `override` wird nichts ersetzt, es sind
  zwei getrennte Variablen.
- **Was ist Konstruktorenverkettung?** Der Konstruktor der Unterklasse ruft mit `: base(flaeche)`
  zuerst den Konstruktor der Basisklasse auf. So wird die Fläche dort gespeichert, wo das Feld
  `private` liegt. In Python wäre das `super().__init__(flaeche)`.
- **Was heißt `static`, und warum hier?** Eine statische Variable gehört der Klasse, nicht einem
  einzelnen Objekt. Die Sätze (4,50 € usw.) sind für alle Immobilien gleich, also gibt es sie nur
  einmal. Auch `LeseZahl` ist `static`, weil `Main` es ohne Objekt aufrufen kann.
- **Warum ist `flaeche` private und die Sätze protected?** `private` = nur die eigene Klasse
  (Datenkapselung, Zugriff über Get/Set). `protected` = auch Unterklassen, damit
  `Geschaeftsflaeche` sie verdecken kann.

## Starten

```bash
dotnet run --project "UE05_Methoden-Vererbung/A3_Immobilienverwaltung"
```

In Zed: `Program.cs` öffnen und `Strg+F5` drücken.
