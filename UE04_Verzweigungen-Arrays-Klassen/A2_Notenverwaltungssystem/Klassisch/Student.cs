// =====================================================================================
// UE04 – Aufgabe 2: Notenverwaltungssystem – Klasse Student (klassische Version)
// -------------------------------------------------------------------------------------
// Ziel:
//   Ein Student hat einen Namen und ein Array mit Noten. Beides bekommt er im
//   Konstruktor. Die Klasse bietet GetNoten() und BerechneNotendurchschnitt().
//
// Verwendete Konzepte:
//   - Klasse mit private Feldern (Kapselung), Konstruktor, Zugriffsmodifikatoren
//   - Methoden mit Rückgabewerten (int[], double, string)
//   - for-Schleife über ein 1D-Array, Math.Round
//
// KLASSE vs. OBJEKT:
//   Diese Datei beschreibt nur den BAUPLAN ("was hat jeder Student, was kann er").
//   Erst mit "new Student(...)" entsteht ein konkretes OBJEKT (eine Instanz) im
//   Speicher – z. B. Andreas mit den Noten 1/4/3. Aus einer Klasse kann man beliebig
//   viele Objekte erzeugen, jedes hat seine EIGENEN Feldwerte.
// =====================================================================================

namespace UE04.A2.Notenverwaltung.Klassisch
{
    // "internal": Die Klasse ist nur innerhalb dieses Projekts (dieser Assembly)
    // sichtbar. Mehr braucht es nicht – kein anderes Programm verwendet sie.
    internal class Student
    {
        // ---------------------------------------------------------------------------
        // Felder (Attribute)
        // ---------------------------------------------------------------------------
        // WARUM private?
        //   Von außen soll niemand den Namen oder das Noten-Array einfach überschreiben
        //   können (z. B. student.noten = null). Der Zugriff läuft nur über Methoden,
        //   die die Klasse selbst anbietet -> die Klasse behält die Kontrolle
        //   über ihre Daten ("Kapselung").
        //
        // WARUM readonly?
        //   Die Felder werden nur einmal im Konstruktor gesetzt und danach nie mehr
        //   neu zugewiesen. readonly lässt sich der Compiler das garantieren.
        //   (Das "Setzen von außen" ist damit komplett ausgeschlossen.)
        //
        // WARUM int für Noten?
        //   Schulnoten sind ganze Zahlen von 1 bis 5 – Kommazahlen kommen erst beim
        //   Durchschnitt vor, und der wird berechnet, nicht gespeichert.
        private readonly string name;
        private readonly int[] noten;

        // ---------------------------------------------------------------------------
        // Konstruktor
        // ---------------------------------------------------------------------------
        // Der Konstruktor heißt wie die Klasse und hat KEINEN Rückgabetyp. Er wird
        // automatisch bei "new Student(...)" aufgerufen und sorgt dafür, dass jedes
        // Objekt von Anfang an in einem gültigen Zustand ist (hat Name und Noten).
        //
        // Gegenstück: Der DESTRUKTOR (in C# "Finalizer", Schreibweise ~Student())
        // würde aufgerufen, wenn der Garbage Collector das Objekt wegräumt. In C# braucht
        // man ihn praktisch nie, weil der Speicher automatisch verwaltet wird – nur bei
        // "fremden" Ressourcen (z. B. Datei-Handles des Betriebssystems).
        //
        // "this.name" ist das FELD des Objekts, "name" (ohne this) der PARAMETER.
        // Weil beide gleich heißen, unterscheidet "this." die beiden.
        public Student(string name, int[] noten)
        {
            this.name = name;
            this.noten = noten;
        }

        // ---------------------------------------------------------------------------
        // Methoden
        // ---------------------------------------------------------------------------

        /// <summary>Liefert den Namen des Studenten (nur lesen, nicht ändern).</summary>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Liefert das Noten-Array (so verlangt es die Angabe: "gibt die Variable für das
        /// Noten-Array zurück").
        /// </summary>
        /// <remarks>
        /// ACHTUNG – Arrays sind REFERENZTYPEN:
        ///   Zurückgegeben wird keine Kopie, sondern ein Verweis auf DASSELBE Array, das
        ///   im Objekt gespeichert ist. Ein Aufrufer könnte also schreiben
        ///       student.GetNoten()[0] = 1;
        ///   und damit die Note im Objekt verändern – trotz "private" und "readonly"!
        ///   (readonly schützt nur die Referenz, nicht den INHALT des Arrays.)
        ///   Dasselbe gilt für das Array, das im Konstruktor übergeben wurde.
        ///   Abhilfe wäre eine Kopie, z. B. "return (int[])noten.Clone();".
        ///   Hier halten wir uns an die Angabe und geben das Feld selbst zurück; die
        ///   moderne Version zeigt die sichere Variante mit IReadOnlyList&lt;int&gt;.
        /// </remarks>
        public int[] GetNoten()
        {
            return noten;
        }

        /// <summary>
        /// Berechnet den Notendurchschnitt aller Noten, gerundet auf 2 Nachkommastellen.
        /// </summary>
        /// <returns>
        /// Durchschnitt als double (Kommazahl!), bzw. 0, wenn keine Noten vorhanden sind.
        /// </returns>
        public double BerechneNotendurchschnitt()
        {
            // Guard-Clause: Ohne Noten gibt es keinen Durchschnitt. Ohne diese Prüfung
            // würde 0.0 / 0 den Wert NaN ("Not a Number") liefern.
            if (noten.Length == 0)
            {
                return 0;
            }

            int summe = 0;
            for (int i = 0; i < noten.Length; i++)
            {
                summe += noten[i];
            }

            // WICHTIG: summe und noten.Length sind beide int. "summe / noten.Length"
            // wäre eine GANZZAHL-Division (8 / 3 = 2, der Rest geht verloren)!
            // Durch den Cast (double) wird zuerst eine Kommazahl daraus -> 8.0 / 3 = 2,666...
            double durchschnitt = (double)summe / noten.Length;

            // Math.Round(wert, 2) rundet auf 2 Nachkommastellen: 2,666... -> 2,67.
            // (Standardmäßig "Banker's Rounding" bei genau ...5 – für Noten unerheblich.)
            return Math.Round(durchschnitt, 2);
        }
    }
}
