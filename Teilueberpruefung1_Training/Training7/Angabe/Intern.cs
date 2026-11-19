namespace Teilueberpruefung_Training7
{
    public class Intern : Employee
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        public Intern(string name, double baseSalary) : base(name, baseSalary)
        {
        }

        // Praktikantinnen und Praktikanten arbeiten halbtags -> halbes Grundgehalt
        public override double GetSalary() { return base.GetSalary() * 0.5; }
    }
}
