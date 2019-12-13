using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate_001
{
    // 1. Delegate-Handler
    public delegate double CalculateHandler(double value1, double value2);

    class Demo
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }
        public static double Sub(double x, double y)
        {
            return x - y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 2. Variable vom Typ des Delegaten
            CalculateHandler calculate;

            do
            {
                // ---- Eingabe der Operanden ----
                Console.Clear();
                Console.Write("Geben Sie den ersten Operanden ein: ");
                double input1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Geben Sie den zweiten Operanden ein: ");
                double input2 = Convert.ToDouble(Console.ReadLine());

                // ---- Wahl der Operation ----
                Console.Write("Operation: Addition - (A) oeder Subtraktion - (S)? ");
                string wahl = Console.ReadLine().ToUpper();

                // In Abhängigkeit von der Wahl des Anwenders wird die Variable 'calculate'
                // mit einem Zeiger auf die auszuführende Methode initialisiert
                // 3. Zeiger der Delegaten-Variablen auf statische Methoden
                // Allerdings wird die Methode, auf die der Delegat in Form eines Zeigers verweist,
                // noch nicht sofort ausgeführt, denn dazu bedarf es eines Anstoßes durch den
                // Aufruf des Delegates:
                // double result = calculate(input1, input2); (s.u.)
                if (wahl == "A")
                {
                    calculate = new CalculateHandler(Demo.Add);
                }
                else if (wahl == "S")
                {
                    calculate = new CalculateHandler(Demo.Sub);
                }
                else
                {
                    Console.Write("Ungültgte Eingabe !");
                    Console.ReadLine();
                    return;
                }

                // Aufruf der Operation 'Add' oder 'Subtract' über den Delegaten
                // 4. Aufruf einer Operation über den DELEGATEN
                double result = calculate(input1, input2);
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Ergebnis = {0}\n\n", result);
                Console.WriteLine("Zum Beenden F12 drücken.");

                // (true) bedeutet: nicht in die Konsole schreiben
            } while (Console.ReadKey(true).Key != ConsoleKey.F12);




            // Console.ReadLine();
        }
    }
}
