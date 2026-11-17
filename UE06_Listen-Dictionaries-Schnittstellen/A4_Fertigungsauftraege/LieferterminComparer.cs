// UE06 – Aufgabe 4: Fertigungsaufträge – Leo Bischof (12320283)

namespace UE06.A4.Fertigungsauftraege
{
    // IComparer<Auftrag>: eine eigene Klasse nur zum Vergleichen, damit man zusätzlich zur KOZ-Regel anders sortieren kann.
    internal class LieferterminComparer : IComparer<Auftrag>
    {
        /// <summary>FLT-Regel: früherer Liefertermin zuerst, bei Gleichstand die kürzere Bearbeitungszeit.</summary>
        public int Compare(Auftrag a, Auftrag b)
        {
            int vergleich = a.GetLiefertermin().CompareTo(b.GetLiefertermin());
            if (vergleich != 0)
            {
                return vergleich;
            }

            return a.GetBearbeitungszeit().CompareTo(b.GetBearbeitungszeit());
        }
    }
}
