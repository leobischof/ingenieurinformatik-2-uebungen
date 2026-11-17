// UE05 – Aufgabe 4: Fahrradverleih – Leo Bischof (12320283)

namespace UE05.A4.Fahrradverleih
{
    internal class EBike : Fahrrad
    {
        // Die Pauschale gibt es nur beim E-Bike, deshalb steht sie hier und nicht in Fahrrad.
        private static double pauschale = 20;

        // : base(...) gibt die Preise an den Konstruktor von Fahrrad weiter
        public EBike() : base(35, 0.70, 8)
        {
        }

        /// <summary>Gibt den Namen des Modells zurück.</summary>
        public override string GetModellname()
        {
            return "E-Bike";
        }

        /// <summary>Berechnet die Kosten wie bei jedem Fahrrad, plus Pauschale bei mehr als 70 km oder 6 Stunden.</summary>
        public override double BerechneKosten()
        {
            // base.BerechneKosten() ist die normale Rechnung aus Fahrrad
            double kosten = base.BerechneKosten();

            if (GetGesamtKm() > 70 || GetGesamtStunden() > 6)
            {
                kosten = kosten + pauschale;
            }

            return kosten;
        }
    }
}
