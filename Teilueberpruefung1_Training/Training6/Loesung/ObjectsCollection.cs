// Teilüberprüfung 1 – Training 6 – Lösung Task 2: Fläche größer als Umfang (abstract/override)

namespace Teilueberpruefung_Training6
{
    public class ObjectsCollection
    {
        public static List<Shape> GetCompactShapes(Shape[] shapes) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Shape> compactShapes = new List<Shape>();

            for (int i = 0; i < shapes.Length; i++)
            {
                // GetArea() und GetPerimeter() sind abstract: ausgeführt wird die Version von Rectangle bzw. Circle
                if (shapes[i].GetArea() > shapes[i].GetPerimeter())
                {
                    compactShapes.Add(shapes[i]);
                }
            }

            return compactShapes; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
