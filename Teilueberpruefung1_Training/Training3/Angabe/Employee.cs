namespace Teilueberpruefung_Training3
{
    public class Employee
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private string _firstName;
        private string _lastName;
        private string _email;
        private double _salary;

        public Employee(string firstName, string lastName, string email, double salary)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _salary = salary;
        }

        public override string ToString()
        {
            return $"{_firstName} {_lastName}";
        }

        public string GetFirstName() { return _firstName; }

        public string GetLastName() { return _lastName; }

        public string GetEmail() { return _email; }

        public double GetSalary() { return _salary; }
    }
}
