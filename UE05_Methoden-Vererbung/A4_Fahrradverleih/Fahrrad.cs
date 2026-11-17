// UE05 – Aufgabe 4: Fahrradverleih – Leo Bischof (12320283)

namespace UE05.A4.Fahrradverleih
{
    // abstract: Es gibt kein "allgemeines Fahrrad" zum Ausleihen, nur Citybike, Mountainbike und E-Bike. Darum kann man kein Objekt davon erzeugen.
    internal abstract class Fahrrad
    {
        // static: Inklusive Kilometer und Stunden sind für alle Fahrräder gleich, also gibt es sie nur einmal in der Klasse.
        protected static int inklusiveKm = 20;
        protected static int inklusiveStunden = 3;

        private double grundgebuehr;
        private double preisProKm;
        private double preisProStunde;
        private int zusatzKm;
        private int zusatzStunden;

        public Fahrrad(double grundgebuehr, double preisProKm, double preisProStunde)
        {
            this.grundgebuehr = grundgebuehr;
            this.preisProKm = preisProKm;
            this.preisProStunde = preisProStunde;
        }

        /// <summary>Gibt die inklusiven Kilometer zurück (statisch, gilt für alle Fahrräder).</summary>
        public static int GetInklusiveKm()
        {
            return inklusiveKm;
        }

        /// <summary>Gibt die inklusiven Stunden zurück (statisch, gilt für alle Fahrräder).</summary>
        public static int GetInklusiveStunden()
        {
            return inklusiveStunden;
        }

        /// <summary>Gibt die Grundgebühr zurück.</summary>
        public double GetGrundgebuehr()
        {
            return grundgebuehr;
        }

        /// <summary>Gibt den Preis pro Zusatz-Kilometer zurück.</summary>
        public double GetPreisProKm()
        {
            return preisProKm;
        }

        /// <summary>Gibt den Preis pro Zusatz-Stunde zurück.</summary>
        public double GetPreisProStunde()
        {
            return preisProStunde;
        }

        /// <summary>Gibt die gebuchten Zusatz-Kilometer zurück.</summary>
        public int GetZusatzKm()
        {
            return zusatzKm;
        }

        /// <summary>Setzt die gebuchten Zusatz-Kilometer.</summary>
        public void SetZusatzKm(int zusatzKm)
        {
            this.zusatzKm = zusatzKm;
        }

        /// <summary>Gibt die gebuchten Zusatz-Stunden zurück.</summary>
        public int GetZusatzStunden()
        {
            return zusatzStunden;
        }

        /// <summary>Setzt die gebuchten Zusatz-Stunden.</summary>
        public void SetZusatzStunden(int zusatzStunden)
        {
            this.zusatzStunden = zusatzStunden;
        }

        /// <summary>Gibt alle Kilometer zurück (inklusive plus zusätzliche).</summary>
        public int GetGesamtKm()
        {
            return inklusiveKm + zusatzKm;
        }

        /// <summary>Gibt alle Stunden zurück (inklusive plus zusätzliche).</summary>
        public int GetGesamtStunden()
        {
            return inklusiveStunden + zusatzStunden;
        }

        // abstract: Jede Fahrradart hat einen anderen Namen, deshalb schreibt jede Unterklasse ihn selbst (override ist Pflicht).
        public abstract string GetModellname();

        // virtual: Die Rechnung gilt für alle gleich, aber das E-Bike darf sie mit override erweitern.
        public virtual double BerechneKosten()
        {
            return grundgebuehr + zusatzKm * preisProKm + zusatzStunden * preisProStunde;
        }
    }
}
