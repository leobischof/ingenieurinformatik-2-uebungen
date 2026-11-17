// UE05 – Aufgabe 3: Immobilienverwaltung – Leo Bischof (12320283)

namespace UE05.A3.Immobilienverwaltung
{
    // ": Immobilie" heißt Vererbung: Das Einfamilienhaus hat alles, was eine Immobilie hat, und kann mehr.
    internal class Einfamilienhaus : Immobilie
    {
        // static: Die Zuschläge sind für alle Einfamilienhäuser gleich.
        private static double zuschlagGarten = 200;
        private static double zuschlagGarage = 150;

        private bool hatGarten;
        private bool hatGarage;

        // ": base(flaeche)" ist die Konstruktorenverkettung: Zuerst läuft der Konstruktor von Immobilie und speichert die Fläche.
        /// <summary>Legt ein Einfamilienhaus mit der gegebenen Fläche an.</summary>
        public Einfamilienhaus(double flaeche) : base(flaeche)
        {
        }

        /// <summary>Gibt zurück, ob es einen Garten gibt.</summary>
        public bool GetHatGarten()
        {
            return hatGarten;
        }

        /// <summary>Legt fest, ob es einen Garten gibt.</summary>
        public void SetHatGarten(bool hatGarten)
        {
            this.hatGarten = hatGarten;
        }

        /// <summary>Gibt zurück, ob es eine Garage gibt.</summary>
        public bool GetHatGarage()
        {
            return hatGarage;
        }

        /// <summary>Legt fest, ob es eine Garage gibt.</summary>
        public void SetHatGarage(bool hatGarage)
        {
            this.hatGarage = hatGarage;
        }

        // override: Ersetzt die Methode der Basisklasse. base.BerechneJahreskosten() holt zuerst die Standardkosten, dann kommen die Zuschläge dazu.
        /// <summary>Berechnet die Jahreskosten inklusive Garten und Garage.</summary>
        public override double BerechneJahreskosten()
        {
            double kosten = base.BerechneJahreskosten();
            if (hatGarten)
            {
                kosten = kosten + zuschlagGarten;
            }
            if (hatGarage)
            {
                kosten = kosten + zuschlagGarage;
            }
            return kosten;
        }

        /// <summary>Gibt den Namen der Immobilienart zurück.</summary>
        public override string GetBezeichnung()
        {
            return "das EFH";
        }
    }
}
