// UE04 – Aufgabe 3: Instrumentenverleih – Leo Bischof (12320283)

namespace UE04.A3.Instrumentenverleih
{
    /// <summary>Ein Instrument mit Seriennummer, Name und Verleihstatus.</summary>
    internal class Instrument
    {
        // private: von außen kann man die Felder nur über die Methoden unten lesen oder ändern
        private int seriennummer;
        private string name;
        private Verleihstatus status;

        /// <summary>Konstruktor: setzt Name und Seriennummer, ein neues Instrument ist immer ausleihbar.</summary>
        public Instrument(int seriennummer, string name)
        {
            this.seriennummer = seriennummer;
            this.name = name;
            this.status = Verleihstatus.ReadyToRent;
        }

        /// <summary>Gibt die Seriennummer zurück.</summary>
        public int GetSeriennummer()
        {
            return seriennummer;
        }

        /// <summary>Gibt den Namen zurück.</summary>
        public string GetName()
        {
            return name;
        }

        /// <summary>Gibt den Verleihstatus zurück.</summary>
        public Verleihstatus GetStatus()
        {
            return status;
        }

        /// <summary>Verleiht das Instrument: der Status wechselt auf RentedOut.</summary>
        public void Ausleihen()
        {
            status = Verleihstatus.RentedOut;
        }

        public void Zurückgeben()
        {
            status = Verleihstatus.ReadyToRent;
        }
    }
}
