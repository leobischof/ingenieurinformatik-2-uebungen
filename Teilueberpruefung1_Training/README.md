# Teilüberprüfung 1 – Trainingsbeispiele (Stoff UE01–UE05)

Acht Übungsprüfungen, aufgebaut **genau wie die Test-Teilüberprüfung**: ein Visual-Studio-Projekt
mit `Program.cs`, einer **unveränderlichen** Klasse, `TwoDimensionalArray.cs` (Task 1) und
`ObjectsCollection.cs` (Task 2). In den beiden Task-Dateien steht die Angabe als Kommentar,
der Code kommt bei `// Code hier schreiben...` hinein.

| Training | Task 1 – 2D Array | Task 2 – Objekte im Array | Schwierigkeit |
| --- | --- | --- | --- |
| [Training1](Training1/) | Zahlen mit gerader Quersumme | Studierende mit gültiger Matrikelnummer (8 Ziffern) | leicht |
| [Training2](Training2/) | Zahlen-Palindrome (121, 1331, …) | Bücher, deren Titel ≥ 3× `e`/`E` enthält | mittel |
| [Training3](Training3/) | vollkommene Zahlen (6, 28, 496, …) | Mitarbeitende mit gültiger E-Mail (genau ein `@`, danach ein `.`) | mittel |
| [Training4](Training4/) | lokale Maxima (größer als alle Nachbarn) | Produkte mit Artikelnummer `AB12345` und Lagerstand > 0 | schwer |
| [Training5](Training5/) | Primzahlen – eigene Hilfsmethode `IsPrime` | Fahrzeuge mit 2 Rädern (`override GetWheels`) und ≥ 100 km/h | leicht |
| [Training6](Training6/) | Fibonacci-Zahlen – **rekursive** Methode `Fibonacci(n)` | Formen (`abstract` `Shape`) mit Fläche > Umfang | mittel |
| [Training7](Training7/) | Armstrong-Zahlen – mehrere Hilfsmethoden, eigenes `Power` | Gehalt über dem Durchschnitt (`virtual`/`override`, `base.GetSalary()`) | mittel |
| [Training8](Training8/) | ggT jeder Zeile – **rekursiver** Euklid `Gcd(a, b)` | nicht-fliegende Tiere, nach Alter sortiert eingefügt (`abstract`/`virtual`) | schwer |

**Training 5–8** legen den Schwerpunkt auf **Methoden und Vererbung** (Stoff UE05): Task 1 verlangt
jeweils eine selbst geschriebene `static`-Hilfsmethode (teils rekursiv), Task 2 arbeitet mit einer
Klassenhierarchie – `abstract`, `virtual`/`override`, `base(...)` und `base.Methode()`. Die Aufgabe
funktioniert nur, wenn man die **überschriebene** Methode über die Basisklasse aufruft.

## So übst du

1. `TrainingX/Angabe` öffnen (in Visual Studio die `.sln`, in Zed den Ordner).
2. **Nur** `TwoDimensionalArray.cs` und `ObjectsCollection.cs` bearbeiten – Methodenkopf,
   `return`-Zeile und die Modell-Klasse bleiben unverändert (wie bei der echten Prüfung).
3. Starten: `dotnet run --project "Teilueberpruefung1_Training/Training1/Angabe"`.
   `Program.cs` gibt bei jedem Task das Ergebnis **und** die erwartete Zeile (`Expected:`) aus –
   stimmen beide überein, passt es.
4. Danach mit `TrainingX/Loesung` vergleichen. Die Lösung ist ein eigenständiges Projekt
   (gleiche `Program.cs` und Modell-Klasse), damit man sie direkt starten kann.

Tipp: Am Prüfungstag den Projektordner wie in der Angabe auf die eigene Matrikelnummer umbenennen
(`UMBENENNEN_IN_MATRIKELNUMMER.txt`).
