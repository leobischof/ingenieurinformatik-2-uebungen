namespace Teilueberpruefung_Training5
{
    public class Bicycle : Vehicle
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private int _gears;

        public Bicycle(string name, int maxSpeed, int gears) : base(name, maxSpeed)
        {
            _gears = gears;
        }

        public int GetGears() { return _gears; }

        public override int GetWheels() { return 2; }
    }
}
