namespace Teilueberpruefung_Training5
{
    public class Motorcycle : Vehicle
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        public Motorcycle(string name, int maxSpeed) : base(name, maxSpeed)
        {
        }

        public override int GetWheels() { return 2; }
    }
}
