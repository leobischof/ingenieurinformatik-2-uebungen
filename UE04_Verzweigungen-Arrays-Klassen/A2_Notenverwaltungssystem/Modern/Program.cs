// =====================================================================================
// UE04 – Aufgabe 2: Notenverwaltungssystem – Hauptprogramm (moderne Version)
// -------------------------------------------------------------------------------------
// Ziel:
//   Drei Student-Objekte in einem Array speichern, darüber iterieren und Name,
//   Noten und Notendurchschnitt ausgeben.
//
// Was ist hier "modern"?
//   - Top-Level-Statements (kein Main-Gerüst)
//   - Collection-Expressions: [1, 4, 3] statt new int[] { 1, 4, 3 }
//   - target-typed new: new("Andreas", ...) – der Typ Student ergibt sich aus dem Array
//   - String-Interpolation $"..." statt Verkettung mit +
//   - static local function für die Ausgabe eines Studenten
//   - Name als Property (student.Name) statt Getter-Methode
// =====================================================================================

using UE04.A2.Notenverwaltung.Modern;

// Umlaute/Sonderzeichen in der Windows-Konsole korrekt darstellen.
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Ein Array ist angemessen: genau drei Studenten, Anzahl steht fest.
// Jedes new(...) erzeugt ein OBJEKT der KLASSE Student (Instanziierung).
Student[] studenten =
[
    new("Andreas", [1, 4, 3]),
    new("Paul", [2, 2, 5]),
    new("Laura", [2, 1, 1]),
];

// Die Angabe verlangt, das Array zu iterieren -> foreach.
// Die Leerzeile kommt nur ZWISCHEN die Blöcke (nicht vor den ersten).
// "!=" vergleicht bei Klassen die REFERENZEN: Ist das nicht dasselbe Objekt wie
// das erste im Array? (Zwei verschiedene Objekte mit gleichem Inhalt wären trotzdem
// ungleich – Klassen sind Referenztypen.)
foreach (var student in studenten)
{
    if (student != studenten[0])
    {
        Console.WriteLine();
    }

    GibStudentAus(student);
}

// Gibt die drei Zeilen für einen Studenten aus.
// string.Join(" / ", ...) setzt den Trenner nur ZWISCHEN die Noten: 1 / 4 / 3.
// Der double-Durchschnitt wird mit der Systemkultur formatiert (Deutsch: 2,67; 3).
static void GibStudentAus(Student student)
{
    Console.WriteLine($"Name: {student.Name}");
    Console.WriteLine($"Noten: {string.Join(" / ", student.GetNoten())}");
    Console.WriteLine($"Notendurchschnitt: {student.BerechneNotendurchschnitt()}");
}
