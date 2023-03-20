namespace M002
{
	/// <summary>
	/// Die Program Klasse
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Die Main Methode
		/// </summary>
		/// <param name="args">Die Programmargumente</param>
		static void Main(string[] args)
		{
			#region Variablen
			int zahl;
			zahl = 5;

			Console.WriteLine(zahl);

			int zahlMalZwei = zahl * 2;
			Console.WriteLine(zahlMalZwei);

			string wort = "Hallo";
			char buchstabe = 'A';

			double kostenDouble = 34.292;
			float kostenFloat = 35.249f;
			decimal kostenDecimal = 32874.3284m; //Für Geldwerte (weil sehr viele Kommastellen)
			#endregion

			#region Strings
			string kombi = "Das Wort ist " + wort + ", der Buchstabe ist " + buchstabe;

			string inter = $"Das Wort ist {wort}, der Buchstabe ist {buchstabe}";

			string verbatim = @"\n\t\\ \ "; //Nimmt den String 1:1 wie er geschrieben wurde (ignoriert Escape-Sequenzen)
			string pfad = @"C:\Users\lk3\source\repos\CSharp_Grundkurs_2023_01_10\M002";

			string umbruch = @"Umbruch
	Umbruch";
			#endregion

			#region Eingabe
			string eingabe = Console.ReadLine(); //Eingabe vom Benutzer, mit Enter bestätigen

			ConsoleKeyInfo info = Console.ReadKey(); //Einzelne Eingabe vom User, nicht mit Enter bestätigen
			#endregion

			#region Konvertierung
			//Explizite Konvertierung (Cast, Typecast, Casting)
			double d = 3489.3825;
			int i = (int) d; //Konvertierung erzwingen, Kommastellen werden abgeschnitten

			int x = 50;
			double d2 = x; //Geht einfach so, da alle ints in double passen
			
			short s = (short) x;
			#endregion

			#region Arithmetik
			int z1 = 5;
			int z2 = 8;
			Console.WriteLine(z1 + z2); //Das Ergebnis der Berechnung, originale Werte werden nicht verändert

			z1 = z1 + z2; //Originale Werte verändern mit Zuweisung
			z1 += z2; //Kurzform

			z1++; //Zahl Plus 1
			z2--; //Zahl Minus 1

			double round = 342758.2385768327;
			Math.Ceiling(round); //Aufrunden
			Math.Floor(round); //Abrunden
			Math.Round(round); //Rundet auf die nächste Zahl, bei .5 wird auf die nächste gerade Zahl gerundet
			Math.Round(4.5); //Rundet auf 4
			Math.Round(5.5); //Rundet auf 6
			Math.Round(round, 2);

			Console.WriteLine(8 / 5); //-> 1.6 erwartet, 1 als Ergebnis da zwei Int Werte als Input -> Int-Division
			Console.WriteLine(8.0 / 5); //Double-Division erzwungen
			Console.WriteLine(8d / 5);
			Console.WriteLine(8f / 5);
			Console.WriteLine((double) z1 / z2); //Eine der beiden Variablen zu double konvertieren
			#endregion
		}
	}
}