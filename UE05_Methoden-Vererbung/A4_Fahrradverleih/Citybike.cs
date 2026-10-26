// UE05 – Aufgabe 4: Fahrradverleih – Leo Bischof (12320283)

namespace UE05.A4.Fahrradverleih
{
    internal class Citybike : Fahrrad
    {
        // : base(...) ruft den Konstruktor von Fahrrad auf und gibt Grundgebühr, Preis pro km und Preis pro Stunde weiter (Konstruktorenverkettung)
        public Citybike() : base(15, 0.30, 4)
        {
        }

        /// <summary>Gibt den Namen des Modells zurück.</summary>
        public override string GetModellname()
        {
            return "Citybike";
        }
    }
}
