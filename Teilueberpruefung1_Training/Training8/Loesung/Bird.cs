namespace Teilueberpruefung_Training8
{
    public class Bird : Animal
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private bool _canFly;

        public Bird(string name, int age, bool canFly) : base(name, age)
        {
            _canFly = canFly;
        }

        public override int GetLegs() { return 2; }

        // nicht jeder Vogel kann fliegen (z.B. ein Pinguin)
        public override bool CanFly() { return _canFly; }
    }
}
