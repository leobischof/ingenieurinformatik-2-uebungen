// UE05 – Aufgabe 3: Immobilienverwaltung – Leo Bischof (12320283)

namespace UE05.A3.Immobilienverwaltung
{
    internal class Zinshaus : Immobilie
    {
        // static: Der Zuschlag pro Wohnung ist für alle Zinshäuser gleich.
        private static double zuschlagProWohnung = 50;

        private int anzahlWohnungen;

        // Konstruktorenverkettung: base(flaeche) ruft zuerst den Konstruktor von Immobilie auf.
        /// <summary>Legt ein Zinshaus mit der gegebenen Fläche an.</summary>
        public Zinshaus(double flaeche) : base(flaeche)
        {
        }

        /// <summary>Gibt die Anzahl der Wohnungen zurück.</summary>
        public int GetAnzahlWohnungen()
        {
            return anzahlWohnungen;
        }

        /// <summary>Setzt die Anzahl der Wohnungen.</summary>
        public void SetAnzahlWohnungen(int anzahlWohnungen)
        {
            this.anzahlWohnungen = anzahlWohnungen;
        }

        // override + base: Standardkosten der Basisklasse plus 50 Euro pro Wohnung.
        /// <summary>Berechnet die Jahreskosten inklusive Wohnungszuschlag.</summary>
        public override double BerechneJahreskosten()
        {
            return base.BerechneJahreskosten() + anzahlWohnungen * zuschlagProWohnung;
        }

        /// <summary>Gibt den Namen der Immobilienart zurück.</summary>
        public override string GetBezeichnung()
        {
            return "das Zinshaus";
        }
    }
}
