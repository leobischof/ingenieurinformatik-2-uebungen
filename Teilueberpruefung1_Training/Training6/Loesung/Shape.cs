namespace Teilueberpruefung_Training6
{
    public abstract class Shape
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private string _name;

        public Shape(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }

        public string GetName() { return _name; }

        // Jede Form berechnet Fläche und Umfang anders - darum abstract (die Unterklassen MÜSSEN sie schreiben).
        public abstract double GetArea();

        public abstract double GetPerimeter();
    }
}
