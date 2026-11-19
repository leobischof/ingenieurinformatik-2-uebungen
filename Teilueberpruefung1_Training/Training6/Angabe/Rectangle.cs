namespace Teilueberpruefung_Training6
{
    public class Rectangle : Shape
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private double _width;
        private double _height;

        public Rectangle(string name, double width, double height) : base(name)
        {
            _width = width;
            _height = height;
        }

        public override double GetArea() { return _width * _height; }

        public override double GetPerimeter() { return 2 * (_width + _height); }
    }
}
