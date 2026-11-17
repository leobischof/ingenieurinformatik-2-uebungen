// UE04 – Aufgabe 2: Notenverwaltungssystem, Klasse Student – Leo Bischof (12320283)

namespace UE04.A2.Notenverwaltung
{
    internal class Student
    {
        // private: von außen kann man Name und Noten nicht direkt ändern
        private string name;
        private int[] noten;

        // Konstruktor: wird bei "new Student(...)" aufgerufen und speichert Name und Noten
        public Student(string name, int[] noten)
        {
            // this.name ist das Feld, name ist der Parameter  (wie self. in py)
            this.name = name;
            this.noten = noten;
        }

        /// <summary>Gibt den Namen des Studenten zurück.</summary>
        public string GetName()
        {
            return name;
        }

        /// <summary>Gibt das Noten-Array zurück.</summary>
        public int[] GetNoten()
        {
            return noten;
        }

        /// <summary>Berechnet den Notendurchschnitt, gerundet auf 2 Nachkommastellen.</summary>
        public double BerechneNotendurchschnitt()
        {
            int summe = 0;
            for (int i = 0; i < noten.Length; i++)
            {
                summe += noten[i];
            }

            // (double) macht aus der Summe eine Kommazahl. Ohne das wäre 8 / 3 = 2 (Ganzzahl-Division).
            double durchschnitt = (double)summe / noten.Length;
            return Math.Round(durchschnitt, 2);
        }
    }
}
