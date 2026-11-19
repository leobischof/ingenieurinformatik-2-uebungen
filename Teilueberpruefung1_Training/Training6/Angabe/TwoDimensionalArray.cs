namespace Teilueberpruefung_Training6
{
    public class TwoDimensionalArray
    {
        // Erweitern Sie den Code derart, dass im übergebenen 2D Array ('int[,] numbers') alle FIBONACCI-ZAHLEN gesucht werden.
        // Jede gefundene Fibonacci-Zahl soll in die vorbereitete Liste ('List<int>') hinzugefügt werden.

        // Die Fibonacci-Folge beginnt mit 0 und 1, jede weitere Zahl ist die Summe der beiden vorherigen:
        //   0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ...
        // Eine Zahl ist eine Fibonacci-Zahl, wenn sie in dieser Folge vorkommt.

        // Schreiben Sie dafür ZWEI eigene statische Hilfsmethoden in dieser Klasse:
        //   1) 'static int Fibonacci(int n)'       -> liefert die n-te Fibonacci-Zahl und arbeitet REKURSIV
        //                                             (Fibonacci(0) = 0, Fibonacci(1) = 1, Fibonacci(n) = Fibonacci(n - 1) + Fibonacci(n - 2))
        //   2) 'static bool IsFibonacci(int number)' -> berechnet mit 'Fibonacci(n)' für n = 0, 1, 2, ... so lange die Folge,
        //                                             bis die Zahl gefunden oder überschritten wurde.

        // Tipp: Eine rekursive Methode ruft sich selbst auf - vergessen Sie die Abbruchbedingung (n == 0 bzw. n == 1) nicht,
        //       sonst endet das Programm mit einer 'StackOverflowException'.

        // Übergabeparameter:   int[,] numbers              -> 2D Array von positiven ganzen Zahlen
        // Rückgabewert:        List<int> fibonacciNumbers  -> Liste der Fibonacci-Zahlen (in der Reihenfolge Zeile für Zeile)

        public static List<int> GetFibonacciNumbers(int[,] numbers) // ACHTUNG! Methodenkopf muss unverändert bleiben!
        {
            List<int> fibonacciNumbers = new List<int>();

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    // Code hier schreiben...

                }
            }

            return fibonacciNumbers; // ACHTUNG! Return Statement muss unverändert bleiben!
        }

        // Hilfsmethoden hier schreiben...

    }
}
