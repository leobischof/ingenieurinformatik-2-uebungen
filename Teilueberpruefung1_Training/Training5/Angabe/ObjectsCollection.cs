namespace Teilueberpruefung_Training5
{
    public class ObjectsCollection
    {
        // Vervollständigen Sie den Code derart, dass alle schnellen Zweiräder im übergebenen 1D Array ('Vehicle[] vehicles')
        // gesucht werden.

        // Ein Fahrzeug ist ein schnelles Zweirad, wenn
        //   1) es GENAU 2 Räder hat ('int GetWheels()') und
        //   2) seine Höchstgeschwindigkeit ('int GetMaxSpeed()') mindestens 100 km/h beträgt.
        // Trifft beides zu, soll die Instanz des Fahrzeugs in die vorbereitete Liste ('List<Vehicle> fastTwoWheelers') hinzugefügt werden.

        // Hierfür muss das Konstrukt einer Schleife verwendet werden!

        // Tipp: Im Array liegen Objekte der Klassen 'Vehicle', 'Car', 'Motorcycle' und 'Bicycle'. 'GetWheels()' ist in der
        //       Basisklasse 'virtual' und wird in manchen Unterklassen mit 'override' überschrieben. Sie müssen also NICHT
        //       selbst herausfinden, welche Klasse ein Objekt hat - der Aufruf liefert automatisch den richtigen Wert.

        // Übergabeparameter:   Vehicle[] vehicles              -> 1D Array von Objekten vom Typ 'Vehicle' (oder einer Unterklasse)
        // Rückgabewert:        List<Vehicle> fastTwoWheelers   -> Liste der schnellen Zweiräder

        public static List<Vehicle> GetFastTwoWheelers(Vehicle[] vehicles) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Vehicle> fastTwoWheelers = new List<Vehicle>();

            // Code hier schreiben...


            return fastTwoWheelers; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
