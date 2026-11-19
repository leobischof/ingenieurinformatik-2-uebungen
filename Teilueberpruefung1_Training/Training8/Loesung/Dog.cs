namespace Teilueberpruefung_Training8
{
    public class Dog : Animal
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        public Dog(string name, int age) : base(name, age)
        {
        }

        public override int GetLegs() { return 4; }
    }
}
