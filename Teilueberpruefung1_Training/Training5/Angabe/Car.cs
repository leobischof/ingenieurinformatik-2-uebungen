namespace Teilueberpruefung_Training5
{
    public class Car : Vehicle
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private int _seats;

        public Car(string name, int maxSpeed, int seats) : base(name, maxSpeed)
        {
            _seats = seats;
        }

        public int GetSeats() { return _seats; }
    }
}
