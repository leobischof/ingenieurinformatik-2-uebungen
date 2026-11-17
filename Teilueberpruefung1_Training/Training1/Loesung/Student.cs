namespace Teilueberpruefung_Training1
{
    public class Student
    {
        // ACHTUNG! Die Klasse muss unverändert bleiben!
        // Die automatisierte Prüfung der Ergebnisse erfolgt stets mit einer unveränderten Version dieser Klasse (extern geladen)!

        private string _name;
        private string _matrikelnummer;
        private string _studiengang;
        private int _semester;

        public Student(string name, string matrikelnummer, string studiengang, int semester)
        {
            _name = name;
            _matrikelnummer = matrikelnummer;
            _studiengang = studiengang;
            _semester = semester;
        }

        public override string ToString()
        {
            return $"{_name} ({_matrikelnummer})";
        }

        public string GetName() { return _name; }

        public string GetMatrikelnummer() { return _matrikelnummer; }

        public string GetStudiengang() { return _studiengang; }

        public int GetSemester() { return _semester; }
    }
}
