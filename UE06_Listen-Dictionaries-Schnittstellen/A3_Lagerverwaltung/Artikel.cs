// UE06 – Aufgabe 3: Lagerverwaltung – Leo Bischof (12320283)

namespace UE06.A3.Lagerverwaltung
{
    internal class Artikel
    {
        private string artikelnummer;
        private string bezeichnung;
        private int bestand;
        private double preis;

        public Artikel(string artikelnummer, string bezeichnung, int bestand, double preis)
        {
            this.artikelnummer = artikelnummer;
            this.bezeichnung = bezeichnung;
            this.bestand = bestand;
            this.preis = preis;
        }

        /// <summary>Gibt die Artikelnummer zurück.</summary>
        public string GetArtikelnummer()
        {
            return artikelnummer;
        }

        /// <summary>Gibt die Bezeichnung zurück.</summary>
        public string GetBezeichnung()
        {
            return bezeichnung;
        }

        /// <summary>Gibt den Bestand zurück. Ändern geht nur über Einlagern und Entnehmen, darum kein SetBestand.</summary>
        public int GetBestand()
        {
            return bestand;
        }

        /// <summary>Gibt den Preis pro Stück zurück.</summary>
        public double GetPreis()
        {
            return preis;
        }

        /// <summary>Erhöht den Bestand um die angegebene Menge.</summary>
        public void Einlagern(int menge)
        {
            bestand = bestand + menge;
        }

        /// <summary>Verringert den Bestand. Gibt false zurück und ändert nichts, wenn zu wenig da ist.</summary>
        public bool Entnehmen(int menge)
        {
            if (menge > bestand)
            {
                return false;
            }

            bestand = bestand - menge;
            return true;
        }
    }
}
