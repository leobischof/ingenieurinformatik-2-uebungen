// UE06 – Aufgabe 4: Fertigungsaufträge – Leo Bischof (12320283)

namespace UE06.A4.Fertigungsauftraege
{
    // IComparable<Auftrag>: legt die "normale" Sortierung fest, die liste.Sort() ohne Parameter verwendet (KOZ-Regel).
    internal class Auftrag : IComparable<Auftrag>
    {
        private int auftragsnummer;
        private string artikel;
        private TimeSpan bearbeitungszeit;
        private DateTime liefertermin;

        public Auftrag(int auftragsnummer, string artikel, TimeSpan bearbeitungszeit, DateTime liefertermin)
        {
            this.auftragsnummer = auftragsnummer;
            this.artikel = artikel;
            this.bearbeitungszeit = bearbeitungszeit;
            this.liefertermin = liefertermin;
        }

        // Alle vier Getter werden gebraucht (Stornieren, Comparer, Planausgabe), Setter keine.

        /// <summary>Gibt die Auftragsnummer zurück.</summary>
        public int GetAuftragsnummer()
        {
            return auftragsnummer;
        }

        /// <summary>Gibt die Artikelbezeichnung zurück.</summary>
        public string GetArtikel()
        {
            return artikel;
        }

        /// <summary>Gibt die Bearbeitungszeit zurück.</summary>
        public TimeSpan GetBearbeitungszeit()
        {
            return bearbeitungszeit;
        }

        /// <summary>Gibt den Liefertermin zurück.</summary>
        public DateTime GetLiefertermin()
        {
            return liefertermin;
        }

        /// <summary>KOZ-Regel: kürzere Bearbeitungszeit zuerst, bei Gleichstand der frühere Liefertermin.</summary>
        public int CompareTo(Auftrag other)
        {
            int vergleich = bearbeitungszeit.CompareTo(other.GetBearbeitungszeit());
            if (vergleich != 0)
            {
                return vergleich;
            }

            return liefertermin.CompareTo(other.GetLiefertermin());
        }

        /// <summary>Eine Tabellenzeile: Nr. | Artikel | Dauer in Stunden | Termin.</summary>
        public override string ToString()
        {
            return $"{auftragsnummer.ToString().PadRight(4)} | {artikel.PadRight(16)} | {bearbeitungszeit.TotalHours.ToString().PadLeft(5)} | {liefertermin.ToString("dd.MM.yyyy HH:mm")}";
        }
    }
}
