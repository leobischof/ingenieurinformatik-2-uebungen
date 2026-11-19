namespace Teilueberpruefung_Training7
{
    public class Manager : Employee
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private double _bonus;

        public Manager(string name, double baseSalary, double bonus) : base(name, baseSalary)
        {
            _bonus = bonus;
        }

        public double GetBonus() { return _bonus; }

        // Grundgehalt plus Bonus
        public override double GetSalary() { return base.GetSalary() + _bonus; }
    }
}
