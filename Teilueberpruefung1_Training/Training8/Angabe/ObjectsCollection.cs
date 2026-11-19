namespace Teilueberpruefung_Training8
{
    public class ObjectsCollection
    {
        // Vervollständigen Sie den Code derart, dass alle Tiere im übergebenen 1D Array ('Animal[] animals') gesucht werden,
        // die NICHT fliegen können ('bool CanFly()').

        // Die gefundenen Tiere sollen in der vorbereiteten Liste ('List<Animal> groundAnimals') nach ihrem Alter
        // ('int GetAge()') AUFSTEIGEND sortiert sein (jüngstes Tier zuerst).
        // Haben zwei Tiere das gleiche Alter, bleibt ihre Reihenfolge so wie im Array.

        // Hierfür muss das Konstrukt einer Schleife verwendet werden! 'Sort', 'OrderBy' und ähnliche fertige Methoden sind NICHT erlaubt.

        // Tipp 1: 'CanFly()' ist in 'Animal' virtual und liefert 'false' - nur 'Bird' überschreibt es (und auch nicht jeder Vogel kann fliegen).
        // Tipp 2: Sortiertes Einfügen: Suchen Sie in der Liste die erste Stelle, an der ein ÄLTERES Tier steht, und fügen Sie
        //         das neue Tier genau dort mit 'liste.Insert(position, tier)' ein. Gibt es kein älteres Tier, kommt es mit 'Add' ans Ende.
        // Tipp 3: 'liste.Count' liefert die Anzahl der Elemente, 'liste[k]' das Element an Position k.

        // Übergabeparameter:   Animal[] animals            -> 1D Array von Objekten vom Typ 'Animal' (Dog, Bird oder Spider)
        // Rückgabewert:        List<Animal> groundAnimals  -> Liste der Tiere, die nicht fliegen können, aufsteigend nach Alter

        public static List<Animal> GetGroundAnimalsSortedByAge(Animal[] animals) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<Animal> groundAnimals = new List<Animal>();

            // Code hier schreiben...


            return groundAnimals; // ACHTUNG! Return Statement muss unverändert bleiben!
        }
    }
}
