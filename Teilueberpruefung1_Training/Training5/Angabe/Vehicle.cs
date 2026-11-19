namespace Teilueberpruefung_Training5
{
    public class Vehicle
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private string _name;
        private int _maxSpeed;

        public Vehicle(string name, int maxSpeed)
        {
            _name = name;
            _maxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return _name;
        }

        public string GetName() { return _name; }

        public int GetMaxSpeed() { return _maxSpeed; }

        // Ein normales Fahrzeug hat 4 Räder - Unterklassen dürfen das überschreiben.
        public virtual int GetWheels() { return 4; }
    }
}
