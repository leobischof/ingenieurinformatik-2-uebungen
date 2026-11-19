namespace Teilueberpruefung_Training8
{
    public class Spider : Animal
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        public Spider(string name, int age) : base(name, age)
        {
        }

        public override int GetLegs() { return 8; }
    }
}
