// =====================================================================================
// UE04 – Aufgabe 2: Notenverwaltungssystem – Klasse Student (moderne Version)
// -------------------------------------------------------------------------------------
// Ziel:
//   Wie klassisch: Name + Noten im Konstruktor, Methoden GetNoten() und
//   BerechneNotendurchschnitt() (Namen exakt wie in der Angabe).
//
// Was ist hier "modern"?
//   - file-scoped namespace ("namespace X;" ohne geschweifte Klammern)
//   - Primary Constructor: "class Student(string name, IEnumerable<int> noten)" –
//     die Konstruktor-Parameter stehen direkt im Klassenkopf.
//   - Auto-Property "Name { get; }": nur lesbar, wird einmal gesetzt.
//   - IReadOnlyList<int> statt int[] als Rückgabetyp von GetNoten() (siehe unten).
//   - LINQ: Average() statt händischer Summen-Schleife.
//   - "sealed": von dieser Klasse soll niemand erben – macht die Absicht klar.
// =====================================================================================

namespace UE04.A2.Notenverwaltung.Modern;

// Klasse = Bauplan. Objekte entstehen erst mit "new Student(...)" im Hauptprogramm.
// Der Primary Constructor ersetzt den klassischen Konstruktor mit this.x = x;
// ein Destruktor (Finalizer ~Student()) ist – wie fast immer in C# – nicht nötig,
// weil der Garbage Collector den Speicher automatisch freigibt.
public sealed class Student(string name, IEnumerable<int> noten)
{
    // Öffentlich LESBAR (für die Ausgabe), aber ohne set -> von außen nicht änderbar.
    public string Name { get; } = name;

    // WARUM eine Kopie + ReadOnlyCollection statt einfach das übergebene Array?
    //   1. noten.ToArray() legt eine EIGENE Kopie an. Ändert der Aufrufer später sein
    //      ursprüngliches Array, bleibt der Student davon unberührt.
    //   2. Array.AsReadOnly(...) verpackt die Kopie in eine schreibgeschützte Hülle.
    //      Selbst ein Cast "(int[])student.GetNoten()" scheitert dann, weil das
    //      zurückgegebene Objekt gar kein Array ist.
    //   -> Die Noten sind wirklich gekapselt: Lesen ja, Verändern nein.
    //   "private readonly": nur diese Klasse sieht das Feld, und es wird nie neu gesetzt.
    private readonly IReadOnlyList<int> _noten = Array.AsReadOnly(noten.ToArray());

    /// <summary>
    /// Liefert die Noten als schreibgeschützte Liste.
    /// </summary>
    /// <remarks>
    /// Die klassische Version gibt (laut Angabe) das int[] direkt zurück – dort kann ein
    /// Aufrufer mit <c>GetNoten()[0] = 1</c> die Noten im Objekt verfälschen.
    /// IReadOnlyList&lt;int&gt; bietet nur Lesen (Indexer, Count, foreach) und verbessert
    /// so die Kapselung. string.Join(" / ", ...) funktioniert damit unverändert, weil
    /// es jede IEnumerable&lt;T&gt; akzeptiert.
    /// </remarks>
    public IReadOnlyList<int> GetNoten() => _noten;

    /// <summary>
    /// Durchschnitt aller Noten, auf 2 Nachkommastellen gerundet (0, wenn keine Noten).
    /// </summary>
    /// <remarks>
    /// Average() rechnet bei int-Werten automatisch in double – die Falle der
    /// Ganzzahl-Division (8 / 3 = 2) gibt es hier nicht. Ohne Noten würde Average()
    /// eine Exception werfen, deshalb der Bedingungsoperator davor.
    /// </remarks>
    public double BerechneNotendurchschnitt() =>
        _noten.Count == 0 ? 0 : Math.Round(_noten.Average(), 2);
}
