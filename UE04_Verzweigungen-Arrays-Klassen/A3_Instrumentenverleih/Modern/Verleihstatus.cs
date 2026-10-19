// =====================================================================================
// UE04 – Aufgabe 3: Instrumentenverleih – Enum Verleihstatus (moderne Version)
// -------------------------------------------------------------------------------------
// Ein enum ist ein Datentyp mit einer festen Liste benannter Werte (intern ganze
// Zahlen: ReadyToRent = 0, RentedOut = 1).
// Vorteile gegenüber string/bool:
//   - Tippfehler fallen schon beim Kompilieren auf ("RentedOt" gibt es nicht).
//   - Mehr als zwei Zustände sind möglich (z. B. später "InReparatur").
//   - switch-Ausdrücke über ein enum kann der Compiler auf Vollständigkeit prüfen.
// Die Wertnamen sind laut Angabe exakt ReadyToRent und RentedOut.
// =====================================================================================

namespace UE04.A3.Instrumentenverleih.Modern;

public enum Verleihstatus
{
    /// <summary>Im Geschäft, kann ausgeliehen werden.</summary>
    ReadyToRent,

    /// <summary>Derzeit an einen Kunden verliehen.</summary>
    RentedOut,
}
