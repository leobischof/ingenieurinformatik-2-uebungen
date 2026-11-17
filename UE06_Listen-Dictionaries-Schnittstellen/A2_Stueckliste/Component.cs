// UE06 – Aufgabe 2: Stückliste – Leo Bischof (12320283)

namespace UE06.A2.Stueckliste
{
    // IComparable<Component>: Damit weiß liste.Sort(), wie zwei Bauteile verglichen werden.
    internal class Component : IComparable<Component>
    {
        private int position;
        private string name;
        private string material;
        private double masse;

        public Component(int position, string name, string material, double masse)
        {
            this.position = position;
            this.name = name;
            this.material = material;
            this.masse = masse;
        }

        // Nur diese zwei Getter werden gebraucht (in CompareTo), Setter gar keine.

        /// <summary>Gibt das Material zurück (leer, wenn in der CSV keines steht).</summary>
        public string GetMaterial()
        {
            return material;
        }

        /// <summary>Gibt die Masse in kg zurück.</summary>
        public double GetMasse()
        {
            return masse;
        }

        /// <summary>Vergleicht zuerst das Material (alphabetisch), bei gleichem Material die Masse (aufsteigend).</summary>
        public int CompareTo(Component other)
        {
            // Ergebnis < 0: dieses Bauteil kommt vorher, > 0: nachher, 0: gleich
            int vergleichMaterial = string.Compare(material, other.GetMaterial());
            if (vergleichMaterial != 0)
            {
                return vergleichMaterial;
            }

            return masse.CompareTo(other.GetMasse());
        }

        /// <summary>Eine Zeile der Stückliste: Pos | Name | Material | Masse.</summary>
        public override string ToString()
        {
            return $"{position.ToString().PadRight(3)} | {name.PadRight(40)} | {material.PadRight(15)} | {masse.ToString("0.000")} kg";
        }
    }
}
