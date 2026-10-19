// ============================================================================
// Fahrrad.cs – MODERNE Version der Klasse "Fahrrad"
// ----------------------------------------------------------------------------
// Unterschied zur klassischen Version: PROPERTIES statt öffentlicher FELDER.
//
//   Klassisch:  public int numberGears;                          // Feld = nackte Variable
//   Modern:     public required int numberGears { get; set; }    // Property
//
// Ein Feld ist einfach ein Speicherplatz im Objekt; wer es sieht, kann es beliebig
// lesen und überschreiben. Eine Property sieht von außen GENAU GLEICH aus
// (rad.brand = "Cube"; Console.WriteLine(rad.brand);), ist intern aber ein Paar
// aus Get- und Set-Methode ("Accessoren"). Bei "{ get; set; }" erzeugt der
// Compiler beides automatisch ("Auto-Property") – man kann später Prüfungen
// einbauen (z. B. "Gänge > 0"), OHNE dass sich der Code ändert, der die Klasse
// benutzt. Darum gilt in C#: öffentliche Daten als Property, Felder privat.
//
// "required" (C# 11): Beim Erzeugen MUSS ein Wert gesetzt werden, sonst meldet
//   der Compiler einen Fehler. Damit entfällt der Platzhalter "= """ aus der
//   klassischen Version, und kein Fahrrad kann versehentlich ohne Marke entstehen.
//
// Warum "set" und nicht "init"?
//   "init" würde das Ändern NACH dem Erzeugen verbieten. Die Aufgabe verlangt aber
//   genau das (Gangzahl korrigieren) – deshalb bleibt "numberGears" änderbar.
//   Die Marke ändert sich bei einem echten Fahrrad nie -> "init".
//
// Namen: "brand" und "numberGears" sind von der Angabe vorgegeben. Übliche
// C#-Konvention wäre PascalCase (Brand, NumberGears).
// ============================================================================

namespace UE03.A3.Fahrrad.Modern;

public sealed class Fahrrad
{
    public required string brand { get; init; }

    public required int numberGears { get; set; }

    // ToString wird automatisch aufgerufen, wenn ein Objekt in einen String
    // eingesetzt wird (z. B. $"{rad}"). So steht das Ausgabeformat genau EINMAL hier
    // – in der klassischen Version wird der Text zweimal zusammengesetzt.
    public override string ToString() => $"Marke: {brand}, Anzahl der Gänge: {numberGears}";
}
