namespace Teilueberpruefung_Training6
{
    public class Circle : Shape
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private double _radius;

        public Circle(string name, double radius) : base(name)
        {
            _radius = radius;
        }

        public override double GetArea() { return Math.PI * _radius * _radius; }

        public override double GetPerimeter() { return 2 * Math.PI * _radius; }
    }
}
