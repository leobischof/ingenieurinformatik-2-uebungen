// =====================================================================================
// UE04 – Aufgabe 3: Instrumentenverleih – Klasse Instrument (moderne Version)
// -------------------------------------------------------------------------------------
// Ziel: wie klassisch – Seriennummer, Name, Verleihstatus; Name und Seriennummer
// über den Konstruktor, Status startet mit ReadyToRent.
//
// Was ist hier "modern"?
//   - file-scoped namespace, Primary Constructor
//   - Auto-Properties statt Feld + Getter-Methode:
//       { get; }               -> nur lesbar, einmalig gesetzt (wie readonly-Feld)
//       { get; private set; }  -> von außen lesbar, ändern NUR innerhalb der Klasse
//   - Expression-bodied Members (=>) für Einzeiler
// =====================================================================================

namespace UE04.A3.Instrumentenverleih.Modern;

// Seriennummer als string, nicht int: Man rechnet nicht mit ihr, führende Nullen
// ("007312") blieben bei int nicht erhalten, und echte Seriennummern enthalten oft
// Buchstaben oder sind länger als int.MaxValue (2.147.483.647).
public sealed class Instrument(string name, string seriennummer)
{
    // Lesen von außen: ja (Ausgabe, Suche). Setzen: nie – ein Instrument behält
    // Name und Seriennummer ein Leben lang. Daher nur "get".
    public string Name { get; } = name;
    public string Seriennummer { get; } = seriennummer;

    // Lesen von außen: ja. Setzen: nur über Verleihen() – "private set" verhindert,
    // dass jemand von außen einfach Status = RentedOut schreibt und dabei die Regel
    // "nicht doppelt verleihen" umgeht. Startwert laut Angabe: ReadyToRent.
    public Verleihstatus Status { get; private set; } = Verleihstatus.ReadyToRent;

    // Berechnete Property: kein eigenes Feld, sondern immer aus Status abgeleitet ->
    // kann nie "veraltet" sein.
    public bool IstVerfuegbar => Status == Verleihstatus.ReadyToRent;

    /// <summary>
    /// Verleiht das Instrument, falls verfügbar.
    /// </summary>
    /// <returns>true bei Erfolg, false wenn es bereits verliehen war.</returns>
    public bool Verleihen()
    {
        if (!IstVerfuegbar)
        {
            return false;
        }

        Status = Verleihstatus.RentedOut;
        return true;
    }
}
