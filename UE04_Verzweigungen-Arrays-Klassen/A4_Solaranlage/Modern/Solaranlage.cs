// =====================================================================================
// UE04 – Aufgabe 4: Leistungsübersicht einer Solaranlage – Klasse Solaranlage
//                   (moderne Version)
// -------------------------------------------------------------------------------------
// Ziel: wie klassisch – Standort, Modulnennleistung, Messwerte als 2D-Array; Methoden
// MesswerteAnzeigen(), BerechneGesamtleistung(), BerechneGesamtauslastung(),
// BerechneReihenleistung() (Namen exakt wie in der Angabe).
//
// Was ist hier "modern"?
//   - file-scoped namespace, Primary Constructor, Auto-Properties { get; }
//   - berechnete Properties (AnzahlReihen, Maximalleistung) statt Hilfsmethoden
//   - Math.Clamp für die Begrenzung auf den gültigen Bereich
//   - LINQ (Enumerable.Range, Select, Sum) für die Reihenleistungen
//   - String-Interpolation mit Alignment {wert,6}
//
// Was bleibt bewusst wie in der Angabe?
//   - Messwerte als 2D-Array int[,] (nicht int[][] oder List)
//   - MesswerteAnzeigen() mit verschachtelten Schleifen
//   - BerechneGesamtleistung() mit foreach
//   - BerechneReihenleistung() liefert ein 1D-Array (int[])
// =====================================================================================

namespace UE04.A4.Solaranlage.Modern;

// Primary Constructor: standort und modulnennleistung stehen direkt im Klassenkopf
// und werden unten in Properties bzw. das Messwert-Feld übernommen.
public sealed class Solaranlage(string standort, int modulnennleistung)
{
    // Spaltenbreiten der Tabelle: "Reihe 1:" (8 Zeichen) + Abstand = 10; Messwerte 6.
    private const int BreiteZeilenbeschriftung = 10;
    private const int BreiteMesswert = 6;
    private const double ProzentFaktor = 100.0;

    // Öffentlich LESBAR (falls ein Aufrufer z. B. den Standort anzeigen will), aber
    // ohne set -> nach dem Konstruktor unveränderlich.
    public string Standort { get; } = standort;

    /// <summary>Nennleistung eines Moduls in Watt.</summary>
    public int Modulnennleistung { get; } = modulnennleistung;

    // Die Messwerte bleiben PRIVATE: Ein öffentliches int[,] würde die Referenz
    // herausgeben, und jeder könnte einzelne Werte überschreiben.
    // Befüllt wird über eine statische Hilfsmethode, die auch den Maximalwert prüft.
    private readonly int[,] _messwerte = ErzeugeMesswerte(modulnennleistung);

    // Berechnete Properties: kein eigener Speicher, immer aus dem Array abgeleitet.
    // GetLength(0) = Reihen (Zeilen), GetLength(1) = Module pro Reihe (Spalten).
    public int AnzahlReihen => _messwerte.GetLength(0);
    public int ModuleProReihe => _messwerte.GetLength(1);

    /// <summary>
    /// Maximal mögliche Leistung in W = Reihen × Module × Nennleistung.
    /// Aus den Array-Dimensionen berechnet, nicht hart codiert (9600).
    /// </summary>
    public int Maximalleistung => AnzahlReihen * ModuleProReihe * Modulnennleistung;

    /// <summary>Gibt alle Messwerte als Tabelle aus (verschachtelte Schleifen laut Angabe).</summary>
    public void MesswerteAnzeigen()
    {
        Console.WriteLine($"PV-Anlage {Standort} ({Modulnennleistung} W pro Modul)");

        // Kopfzeile: leere Beschriftungsspalte, dann M1..M6 rechtsbündig.
        Console.Write($"{"",BreiteZeilenbeschriftung}");
        for (var modul = 0; modul < ModuleProReihe; modul++)
        {
            Console.Write($"{"M" + (modul + 1),BreiteMesswert}");
        }
        Console.WriteLine();

        // Außen die Reihen, innen die Module einer Reihe.
        // {text,-10}: negatives Alignment = linksbündig; {zahl,6}: rechtsbündig.
        for (var reihe = 0; reihe < AnzahlReihen; reihe++)
        {
            Console.Write($"{$"Reihe {reihe + 1}:",-BreiteZeilenbeschriftung}");
            for (var modul = 0; modul < ModuleProReihe; modul++)
            {
                Console.Write($"{_messwerte[reihe, modul],BreiteMesswert}");
            }
            Console.WriteLine();
        }
    }

    /// <summary>Summe aller Modulmesswerte in W – laut Angabe mit foreach.</summary>
    /// <remarks>
    /// foreach über ein int[,] liefert alle Elemente zeilenweise ([0,0], [0,1], ...,
    /// [1,0], ...). Die LINQ-Kurzform wäre <c>_messwerte.Cast&lt;int&gt;().Sum()</c>
    /// (ein 2D-Array implementiert nur das nicht-generische IEnumerable, daher Cast);
    /// hier bleiben wir bei der vorgeschriebenen foreach-Schleife.
    /// </remarks>
    public int BerechneGesamtleistung()
    {
        var summe = 0;
        foreach (var messwert in _messwerte)
        {
            summe += messwert;
        }
        return summe;
    }

    /// <summary>Gesamtleistung in % der Maximalleistung (ungerundet).</summary>
    public double BerechneGesamtauslastung() =>
        Maximalleistung == 0 ? 0 : BerechneGesamtleistung() * ProzentFaktor / Maximalleistung;

    /// <summary>Leistung pro Reihe in W als 1D-Array (Index 0 = Reihe 1).</summary>
    /// <remarks>
    /// Für jede Reihe r: Summe über alle Module m von _messwerte[r, m].
    /// ToArray() erzeugt bei jedem Aufruf ein NEUES Array – Änderungen daran wirken
    /// sich nicht auf die Anlage aus.
    /// </remarks>
    public int[] BerechneReihenleistung() =>
        Enumerable.Range(0, AnzahlReihen)
                  .Select(reihe => Enumerable.Range(0, ModuleProReihe).Sum(modul => _messwerte[reihe, modul]))
                  .ToArray();

    /// <summary>
    /// Erzeugt die Messwerte (4 Reihen × 6 Module, in W) und begrenzt jeden Wert auf
    /// 0 .. Nennleistung ("Maximalwert beachten!").
    /// </summary>
    /// <remarks>
    /// Werte aus dem Beispiel der Angabe mit einer Korrektur: Reihe 1 / Modul 4 war dort
    /// 401 W – mehr als die Nennleistung von 400 W und damit unzulässig -> auf 400 W
    /// korrigiert. (Reihe 1 = 2338 W, gesamt 8470 W; die gerundeten Ausgaben 8,47 kW und
    /// 88,2 % ändern sich dadurch nicht.)
    /// "static", weil die Methode keinen Objektzustand braucht – sie läuft, bevor das
    /// Objekt fertig gebaut ist.
    /// </remarks>
    private static int[,] ErzeugeMesswerte(int nennleistung)
    {
        int[,] messwerte =
        {
            { 385, 392, 378, 400, 388, 395 },
            { 380, 391, 120, 390, 379, 386 },
            { 372, 381, 369, 377, 375, 383 },
            { 390, 398, 385,   0, 260, 396 },
        };

        // Sicherheitsnetz gegen Tippfehler: Math.Clamp(wert, min, max) begrenzt auf den
        // Bereich [min, max]. Zum SCHREIBEN in ein 2D-Array braucht man die Indizes –
        // deshalb hier verschachtelte for-Schleifen (foreach liefert nur Kopien der Werte).
        for (var reihe = 0; reihe < messwerte.GetLength(0); reihe++)
        {
            for (var modul = 0; modul < messwerte.GetLength(1); modul++)
            {
                messwerte[reihe, modul] = Math.Clamp(messwerte[reihe, modul], 0, nennleistung);
            }
        }

        return messwerte;
    }
}
