// Teilüberprüfung 1 – Training 5 – Lösung Task 2: schnelle Zweiräder (virtual/override)

namespace Teilueberpruefung_Training5
{
    public class ObjectsCollection
    {
        public static List<Vehicle> GetFastTwoWheelers(Vehicle[] vehicles) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Vehicle> fastTwoWheelers = new List<Vehicle>();

            for (int i = 0; i < vehicles.Length; i++)
            {
                // GetWheels() ist virtual: bei Motorcycle und Bicycle wird automatisch die override-Version (2) aufgerufen
                if (vehicles[i].GetWheels() == 2 && vehicles[i].GetMaxSpeed() >= 100)
                {
                    fastTwoWheelers.Add(vehicles[i]);
                }
            }

            return fastTwoWheelers; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
