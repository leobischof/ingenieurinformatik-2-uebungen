// =====================================================================================
// UE04 – Aufgabe 4: Leistungsübersicht einer Solaranlage – Klasse Solaranlage
//                   (klassische Version)
// -------------------------------------------------------------------------------------
// Ziel:
//   Eine PV-Anlage mit 4 Reihen zu je 6 Modulen. Gespeichert werden Standort,
//   Modulnennleistung (W) und die gemessenen Modulleistungen (W) als 2D-Array
//   [reihe, modul]. Die Klasse kann die Messwerte als Tabelle ausgeben und
//   Gesamtleistung, Auslastung und Leistung pro Reihe berechnen.
//
// Verwendete Konzepte:
//   - Klasse, private Felder, Konstruktor, Zugriffsmodifikatoren
//   - 2D-Array int[,], GetLength(0) / GetLength(1)
//   - verschachtelte for-Schleifen, foreach über ein 2D-Array
//   - Methoden mit Rückgabewerten (int, double, int[])
// =====================================================================================

namespace UE04.A4.Solaranlage.Klassisch
{
    internal class Solaranlage
    {
        // Spaltenbreiten der Messwerttabelle (in Zeichen).
        // "Reihe 1:" ist 8 Zeichen lang; mit 10 bleibt Abstand zur ersten Zahl.
        // Messwerte haben max. 3 Ziffern (400); mit 6 stehen sie luftig nebeneinander.
        private const int BreiteZeilenbeschriftung = 10;
        private const int BreiteMesswert = 6;

        // Umrechnung Prozent: Anteil * 100.
        private const double ProzentFaktor = 100.0;

        // ---------------------------------------------------------------------------
        // Felder – alle private und readonly. Begründung:
        //   - Lesen/Setzen von außen ist hier NICHT nötig: Alle Auswertungen erledigt
        //     die Klasse selbst über ihre Methoden. Was niemand von außen braucht,
        //     wird auch nicht herausgegeben ("so wenig Zugriff wie möglich").
        //   - readonly: Standort und Nennleistung ändern sich nach dem Bau nicht; die
        //     Referenz auf das Messwert-Array wird ebenfalls nie neu gesetzt.
        //   - Die Messwerte selbst werden nie als Array herausgegeben (sonst könnte
        //     ein Aufrufer sie über die Referenz verändern). BerechneReihenleistung()
        //     liefert ein NEUES Array, das mit den internen Daten nichts zu tun hat.
        // ---------------------------------------------------------------------------
        private readonly string standort;

        // int in Watt: Nennleistungen werden in ganzen Watt angegeben (400 W).
        private readonly int modulnennleistung;

        // 2D-Array [reihe, modul] mit den gemessenen Leistungen in Watt.
        // int[,] (rechteckig) statt int[][] (jagged), weil jede Reihe GLEICH viele
        // Module hat – genau das garantiert ein rechteckiges Array.
        private readonly int[,] messwerte;

        // ---------------------------------------------------------------------------
        // Konstruktor: Standort und Nennleistung kommen als Parameter, die Messwerte
        // werden hier befüllt (laut Angabe "beliebige Werte, Maximalwert beachten").
        // Ein Destruktor (~Solaranlage) ist nicht nötig – der Garbage Collector
        // gibt den Speicher automatisch frei.
        // ---------------------------------------------------------------------------
        public Solaranlage(string standort, int modulnennleistung)
        {
            this.standort = standort;
            this.modulnennleistung = modulnennleistung;

            // Werte aus dem Beispiel der Angabe – mit EINER Korrektur:
            // Im Beispiel steht bei Reihe 1 / Modul 4 der Wert 401 W. Das ist mehr als
            // die Nennleistung von 400 W und damit laut Angabe ("Maximalwert
            // beachten!") nicht zulässig -> hier auf 400 W korrigiert.
            // (Dadurch: Reihe 1 = 2338 W statt 2339 W, Gesamt 8470 W statt 8471 W;
            //  die gerundeten Ausgaben 8,47 kW und 88,2 % bleiben gleich.)
            //
            // Zeilen = Reihen (4), Spalten = Module (6).
            messwerte = new int[,]
            {
                { 385, 392, 378, 400, 388, 395 },
                { 380, 391, 120, 390, 379, 386 },
                { 372, 381, 369, 377, 375, 383 },
                { 390, 398, 385,   0, 260, 396 }
            };

            // Sicherheitsnetz für den Maximalwert: Sollte jemand die Werte oben ändern
            // und sich vertippen, wird jeder Wert auf den gültigen Bereich begrenzt.
            BegrenzeMesswerteAufGueltigenBereich();
        }

        /// <summary>
        /// Begrenzt jeden Messwert auf 0 .. Modulnennleistung.
        /// Ein Modul kann physikalisch keine negative Leistung erzeugen, und laut Angabe
        /// darf kein Messwert über der Nennleistung liegen.
        /// private: Das ist ein internes Detail des Konstruktors, kein Dienst nach außen.
        /// </summary>
        private void BegrenzeMesswerteAufGueltigenBereich()
        {
            for (int reihe = 0; reihe < messwerte.GetLength(0); reihe++)
            {
                for (int modul = 0; modul < messwerte.GetLength(1); modul++)
                {
                    if (messwerte[reihe, modul] > modulnennleistung)
                    {
                        messwerte[reihe, modul] = modulnennleistung;
                    }
                    else if (messwerte[reihe, modul] < 0)
                    {
                        messwerte[reihe, modul] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Gibt alle Messwerte als Tabelle aus (Kopfzeile M1..M6, eine Zeile pro Reihe).
        /// Laut Angabe mit verschachtelten Schleifen.
        /// </summary>
        public void MesswerteAnzeigen()
        {
            Console.WriteLine("PV-Anlage " + standort + " (" + modulnennleistung + " W pro Modul)");

            // Kopfzeile: links Platz für die Zeilenbeschriftung, dann M1, M2, ...
            // Module werden für Menschen ab 1 gezählt, der Array-Index beginnt bei 0.
            Console.Write("".PadLeft(BreiteZeilenbeschriftung));
            for (int modul = 0; modul < messwerte.GetLength(1); modul++)
            {
                Console.Write(("M" + (modul + 1)).PadLeft(BreiteMesswert));
            }
            Console.WriteLine();

            // Verschachtelte Schleifen: außen die Reihen (Dimension 0),
            // innen die Module einer Reihe (Dimension 1).
            for (int reihe = 0; reihe < messwerte.GetLength(0); reihe++)
            {
                Console.Write(("Reihe " + (reihe + 1) + ":").PadRight(BreiteZeilenbeschriftung));

                for (int modul = 0; modul < messwerte.GetLength(1); modul++)
                {
                    Console.Write(messwerte[reihe, modul].ToString().PadLeft(BreiteMesswert));
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Summe aller Modulmesswerte in Watt – laut Angabe mit einer foreach-Schleife.
        /// </summary>
        public int BerechneGesamtleistung()
        {
            int summe = 0;

            // foreach über ein 2D-Array liefert ALLE Elemente nacheinander – und zwar
            // zeilenweise: [0,0], [0,1], ..., [0,5], [1,0], ... ("row-major order"),
            // genau in der Reihenfolge, in der sie im Speicher liegen.
            // Wir brauchen hier keine Indizes, nur jeden Wert einmal -> foreach ist
            // kürzer und lesbarer als zwei verschachtelte for-Schleifen.
            foreach (int messwert in messwerte)
            {
                summe += messwert;
            }

            return summe;
        }

        /// <summary>
        /// Gemessene Gesamtleistung in Prozent der maximal möglichen Leistung.
        /// </summary>
        /// <returns>Auslastung in % (ungerundet – gerundet wird erst bei der Ausgabe).</returns>
        public double BerechneGesamtauslastung()
        {
            int maximalleistung = BerechneMaximalleistung();

            // Guard-Clause: Division durch 0 vermeiden (z. B. Anlage ohne Module).
            if (maximalleistung == 0)
            {
                return 0;
            }

            // ProzentFaktor ist ein double -> die ganze Rechnung läuft in double,
            // es gibt keine Ganzzahl-Division (8470 / 9600 wäre als int sonst 0!).
            return BerechneGesamtleistung() * ProzentFaktor / maximalleistung;
        }

        /// <summary>
        /// Leistung jeder Modulreihe in Watt, als 1D-Array (Index 0 = Reihe 1).
        /// </summary>
        public int[] BerechneReihenleistung()
        {
            // Das Ergebnis-Array ist so lang, wie es Reihen gibt (Dimension 0).
            // Es wird bei jedem Aufruf NEU angelegt -> der Aufrufer darf es beliebig
            // verändern, ohne die Messwerte der Anlage zu beeinflussen.
            int[] reihenleistung = new int[messwerte.GetLength(0)];

            for (int reihe = 0; reihe < messwerte.GetLength(0); reihe++)
            {
                for (int modul = 0; modul < messwerte.GetLength(1); modul++)
                {
                    reihenleistung[reihe] += messwerte[reihe, modul];
                }
            }

            return reihenleistung;
        }

        /// <summary>
        /// Maximal mögliche Leistung = Anzahl Reihen × Module pro Reihe × Nennleistung.
        /// Nicht hart codiert (9600), sondern aus den Array-Dimensionen berechnet –
        /// so stimmt der Wert auch, wenn die Anlage einmal größer wird.
        /// private: wird nur intern für die Auslastung gebraucht.
        /// </summary>
        private int BerechneMaximalleistung()
        {
            return messwerte.GetLength(0) * messwerte.GetLength(1) * modulnennleistung;
        }
    }
}
