namespace Teilueberpruefung_Training7
{
    public class Employee
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private string _name;
        private double _baseSalary;

        public Employee(string name, double baseSalary)
        {
            _name = name;
            _baseSalary = baseSalary;
        }

        public override string ToString()
        {
            return _name;
        }

        public string GetName() { return _name; }

        // Grundgehalt laut Vertrag
        public double GetBaseSalary() { return _baseSalary; }

        // tatsächlich ausbezahltes Gehalt - Unterklassen rechnen es anders
        public virtual double GetSalary() { return _baseSalary; }
    }
}
