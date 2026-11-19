namespace Teilueberpruefung_Training6
{
    public class ObjectsCollection
    {
        // Vervollständigen Sie den Code derart, dass alle "kompakten" Formen im übergebenen 1D Array ('Shape[] shapes') gesucht werden.

        // Eine Form ist kompakt, wenn ihre Fläche ('double GetArea()') ECHT GRÖSSER ist als ihr Umfang ('double GetPerimeter()').
        // Trifft das zu, soll die Instanz der Form in die vorbereitete Liste ('List<Shape> compactShapes') hinzugefügt werden.

        // Hierfür muss das Konstrukt einer Schleife verwendet werden!

        // Tipp: 'Shape' ist eine abstrakte Klasse - im Array liegen in Wirklichkeit 'Rectangle'- und 'Circle'-Objekte.
        //       Rufen Sie 'GetArea()' und 'GetPerimeter()' einfach auf: Es wird automatisch die Methode der richtigen Unterklasse ausgeführt.

        // Übergabeparameter:   Shape[] shapes              -> 1D Array von Objekten vom Typ 'Shape' (Rectangle oder Circle)
        // Rückgabewert:        List<Shape> compactShapes   -> Liste der Formen mit Fläche > Umfang

        public static List<Shape> GetCompactShapes(Shape[] shapes) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Shape> compactShapes = new List<Shape>();

            // Code hier schreiben...


            return compactShapes; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
