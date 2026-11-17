// UE05 – Aufgabe 4: Fahrradverleih – Leo Bischof (12320283)

namespace UE05.A4.Fahrradverleih
{
    internal class Mountainbike : Fahrrad
    {
        // : base(...) gibt die Preise an den Konstruktor von Fahrrad weiter
        public Mountainbike() : base(25, 0.50, 6)
        {
        }

        /// <summary>Gibt den Namen des Modells zurück.</summary>
        public override string GetModellname()
        {
            return "Mountainbike";
        }
    }
}
