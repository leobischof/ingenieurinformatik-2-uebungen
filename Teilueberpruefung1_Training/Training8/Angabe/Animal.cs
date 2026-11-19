namespace Teilueberpruefung_Training8
{
    public abstract class Animal
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private string _name;
        private int _age;

        public Animal(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return $"{_name} ({_age})";
        }

        public string GetName() { return _name; }

        public int GetAge() { return _age; }

        // Jede Tierart hat eine andere Anzahl an Beinen - darum abstract.
        public abstract int GetLegs();

        // Die meisten Tiere können nicht fliegen - Unterklassen dürfen das überschreiben.
        public virtual bool CanFly() { return false; }
    }
}
