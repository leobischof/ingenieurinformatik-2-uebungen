// UE05 – Aufgabe 3: Immobilienverwaltung – Leo Bischof (12320283)

namespace UE05.A3.Immobilienverwaltung
{
    internal class Geschaeftsflaeche : Immobilie
    {
        // Verdeckung: "new" legt gleichnamige Variablen mit neuen Werten an, die die Sätze der Basisklasse in dieser Klasse verdecken.
        // static, weil die Sätze für alle Geschäftsflächen gleich sind.
        protected new static double verwaltungProM2 = 6.00;
        protected new static double betriebskostenProM2 = 35.21;

        // Konstruktorenverkettung: base(flaeche) speichert die Fläche in der Basisklasse.
        /// <summary>Legt eine Geschäftsfläche mit der gegebenen Fläche an.</summary>
        public Geschaeftsflaeche(double flaeche) : base(flaeche)
        {
        }

        // override ohne base: Die Basisklasse würde mit ihren eigenen Sätzen (4,50 / 21,47) rechnen, hier gelten aber die verdeckten Sätze.
        /// <summary>Berechnet die Jahreskosten mit den höheren Sätzen für Geschäftsflächen.</summary>
        public override double BerechneJahreskosten()
        {
            return GetFlaeche() * (verwaltungProM2 + betriebskostenProM2);
        }

        /// <summary>Gibt den Namen der Immobilienart zurück.</summary>
        public override string GetBezeichnung()
        {
            return "die Geschäftsfläche";
        }
    }
}
