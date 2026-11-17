// UE05 – Aufgabe 3: Immobilienverwaltung – Leo Bischof (12320283)

namespace UE05.A3.Immobilienverwaltung
{
    internal class Immobilie
    {
        // private: nur die Klasse selbst darf die Fläche direkt ändern (Datenkapselung), von außen nur über Get/Set.
        private double flaeche;

        // static: Die Sätze sind für alle Immobilien gleich, deshalb gibt es sie nur einmal in der Klasse.
        // protected: Unterklassen (z. B. Geschäftsfläche) dürfen sie sehen, fremder Code nicht.
        // Die Zahlen sind laut Angabetext. Der Screenshot (986,4 / 8470) rechnet offenbar mit 2,47 statt 21,47 € pro m².
        protected static double verwaltungProM2 = 4.50;
        protected static double betriebskostenProM2 = 21.47;

        /// <summary>Legt eine Immobilie mit der gegebenen Fläche an.</summary>
        public Immobilie(double flaeche)
        {
            this.flaeche = flaeche;
        }

        /// <summary>Gibt die Fläche in m² zurück.</summary>
        public double GetFlaeche()
        {
            return flaeche;
        }

        /// <summary>Setzt die Fläche in m².</summary>
        public void SetFlaeche(double flaeche)
        {
            this.flaeche = flaeche;
        }

        // virtual: Jede Unterklasse darf diese Methode mit override anders berechnen.
        /// <summary>Berechnet die Jahreskosten (Verwaltung + Betrieb) laut Standardsätzen.</summary>
        public virtual double BerechneJahreskosten()
        {
            return flaeche * (verwaltungProM2 + betriebskostenProM2);
        }

        // virtual: Jede Unterklasse liefert ihren eigenen Namen (mit Artikel) für die Ausgabe.
        /// <summary>Gibt den Namen der Immobilienart zurück.</summary>
        public virtual string GetBezeichnung()
        {
            return "die Immobilie";
        }
    }
}
