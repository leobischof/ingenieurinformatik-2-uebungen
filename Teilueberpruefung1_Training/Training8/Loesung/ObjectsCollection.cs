// Teilüberprüfung 1 – Training 8 – Lösung Task 2: nicht-fliegende Tiere, nach Alter sortiert eingefügt

namespace Teilueberpruefung_Training8
{
    public class ObjectsCollection
    {
        public static List<Animal> GetGroundAnimalsSortedByAge(Animal[] animals) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Animal> groundAnimals = new List<Animal>();

            for (int i = 0; i < animals.Length; i++)
            {
                // CanFly() ist virtual: nur Bird hat eine eigene Version, alle anderen liefern false
                if (animals[i].CanFly())
                {
                    continue;
                }

                // erste Stelle suchen, an der ein älteres Tier steht
                int position = groundAnimals.Count;
                for (int k = 0; k < groundAnimals.Count; k++)
                {
                    if (groundAnimals[k].GetAge() > animals[i].GetAge())
                    {
                        position = k;
                        break;
                    }
                }

                // davor einfügen (bei position == Count landet es einfach am Ende)
                groundAnimals.Insert(position, animals[i]);
            }

            return groundAnimals; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
