// UE04 – Aufgabe 4: Solaranlage – Leo Bischof (12320283)

namespace UE04.A4.Solaranlage
{
    internal class Solaranlage
    {
        // private: von außen kommt niemand direkt an die Daten, nur über die Methoden der Klasse
        private string standort;
        private int modulnennleistung;
        private int[,] messwerte;   // 4 Reihen mit je 6 Modulen, Werte in Watt

        /// <summary>Setzt Standort und Nennleistung und befüllt das Messwerte-Array.</summary>
        public Solaranlage(string standort, int modulnennleistung)
        {
            // this.standort ist das Feld der Klasse, standort ist der übergebene Parameter
            this.standort = standort;
            this.modulnennleistung = modulnennleistung;

            // Zeile = Reihe, Spalte = Modul (Werte wie im Beispiel der Angabe)
            // Ausnahme: im Beispiel steht einmal 401 W, das ist mehr als die Nennleistung -> 400 W
            messwerte = new int[4, 6]
            {
                { 385, 392, 378, 400, 388, 395 },
                { 380, 391, 120, 390, 379, 386 },
                { 372, 381, 369, 377, 375, 383 },
                { 390, 398, 385, 0, 260, 396 }
            };
        }

        /// <summary>Gibt alle Messwerte als Tabelle aus.</summary>
        public void MesswerteAnzeigen()
        {
            Console.WriteLine($"PV-Anlage {standort} ({modulnennleistung} W pro Modul)");

            // Kopfzeile: erst Platz für "Reihe 1:", dann M1 bis M6
            Console.Write("".PadLeft(10));
            for (int modul = 0; modul < messwerte.GetLength(1); modul++)
            {
                Console.Write($"M{modul + 1}".PadLeft(6));
            }
            Console.WriteLine();

            // verschachtelte Schleife: außen jede Reihe, innen jedes Modul der Reihe
            for (int reihe = 0; reihe < messwerte.GetLength(0); reihe++)
            {
                Console.Write($"Reihe {reihe + 1}:".PadRight(10));
                for (int modul = 0; modul < messwerte.GetLength(1); modul++)
                {
                    Console.Write(messwerte[reihe, modul].ToString().PadLeft(6));
                }
                Console.WriteLine();
            }
        }

        /// <summary>Summiert alle Messwerte (in Watt).</summary>
        public int BerechneGesamtleistung()
        {
            int summe = 0;

            // foreach geht bei einem 2D-Array einfach alle Werte der Reihe nach durch
            foreach (int messwert in messwerte)
            {
                summe += messwert;
            }

            return summe;
        }

        /// <summary>Gibt die gemessene Gesamtleistung in Prozent der Maximalleistung zurück.</summary>
        public double BerechneGesamtauslastung()
        {
            // Maximalleistung = alle Module mit voller Nennleistung = 4 * 6 * 400 = 9600 W
            int maximalleistung = messwerte.GetLength(0) * messwerte.GetLength(1) * modulnennleistung;

            // 100.0 (mit Komma) rechnet mit Kommazahlen; mit 100 wäre 8470 * 100 / 9600 eine Ganzzahldivision
            return BerechneGesamtleistung() * 100.0 / maximalleistung;
        }

        /// <summary>Berechnet die Leistung jeder Reihe und gibt sie als Array zurück.</summary>
        public int[] BerechneReihenleistung()
        {
            // ein Eintrag pro Reihe, am Anfang überall 0
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
    }
}
