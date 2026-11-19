namespace Teilueberpruefung_Training7
{
    public class ObjectsCollection
    {
        // Vervollständigen Sie den Code derart, dass alle Mitarbeitenden im übergebenen 1D Array ('Employee[] employees') gesucht
        // werden, deren Gehalt ÜBER dem Durchschnitt aller Mitarbeitenden im Array liegt.

        // Maßgeblich ist das tatsächlich ausbezahlte Gehalt ('double GetSalary()'), NICHT das Grundgehalt ('GetBaseSalary()')!
        //   - Employee: Gehalt = Grundgehalt
        //   - Manager:  Gehalt = Grundgehalt + Bonus
        //   - Intern:   Gehalt = halbes Grundgehalt
        // Liegt das Gehalt ECHT ÜBER dem Durchschnitt, soll die Instanz in die vorbereitete Liste ('List<Employee> topEarners')
        // hinzugefügt werden.

        // Hierfür muss das Konstrukt einer Schleife verwendet werden!

        // Tipp 1: Sie brauchen ZWEI Schleifen: zuerst den Durchschnitt berechnen, danach vergleichen.
        // Tipp 2: Den Durchschnitt können Sie in einer eigenen Hilfsmethode 'static double GetAverageSalary(Employee[] employees)' berechnen.
        // Tipp 3: 'GetSalary()' ist 'virtual' - der Aufruf liefert automatisch die Berechnung der richtigen Unterklasse.

        // Übergabeparameter:   Employee[] employees        -> 1D Array von Objekten vom Typ 'Employee' (oder einer Unterklasse)
        // Rückgabewert:        List<Employee> topEarners   -> Liste der Mitarbeitenden mit überdurchschnittlichem Gehalt

        public static List<Employee> GetTopEarners(Employee[] employees) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Employee> topEarners = new List<Employee>();

            // Code hier schreiben...


            return topEarners; // ACHTUNG! Return Statement muss unverändert bleiben!
        }

        // Hilfsmethode hier schreiben (optional)...

    }
}
