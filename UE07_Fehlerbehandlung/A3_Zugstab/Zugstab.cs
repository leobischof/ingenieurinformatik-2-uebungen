// UE07 – Aufgabe 3: Zugstab – Leo Bischof (12320283)

namespace UE07.A3.Zugstab
{
    internal class Zugstab
    {
        private double durchmesser;    // d in mm
        private double streckgrenze;   // Re in N/mm²

        public Zugstab(double durchmesser, double streckgrenze)
        {
            // Ein Stab mit d <= 0 oder Re <= 0 ergibt keinen Sinn, also wird das Objekt gar nicht erst erzeugt.
            if (durchmesser <= 0)
            {
                throw new ArgumentOutOfRangeException("durchmesser", "Der Durchmesser muss größer als 0 sein.");
            }
            if (streckgrenze <= 0)
            {
                throw new ArgumentOutOfRangeException("streckgrenze", "Die Streckgrenze muss größer als 0 sein.");
            }

            this.durchmesser = durchmesser;
            this.streckgrenze = streckgrenze;
        }

        /// <summary>Gibt die Streckgrenze Re in N/mm² zurück.</summary>
        public double GetStreckgrenze()
        {
            return streckgrenze;
        }

        /// <summary>Berechnet die Spannung sigma = F / A in N/mm². Wirft eine Exception, wenn sigma größer als Re ist.</summary>
        public double Spannung(double kraft)
        {
            // Kreisfläche A = pi * d² / 4
            double flaeche = Math.PI * Math.Pow(durchmesser, 2) / 4;
            double spannung = kraft / flaeche;

            if (spannung > streckgrenze)
            {
                // InvalidOperationException: die Eingaben sind einzeln gültig, aber zusammen geht es nicht
                throw new InvalidOperationException("Stab wird plastisch verformt");
            }

            return spannung;
        }
    }
}
