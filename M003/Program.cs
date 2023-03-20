namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			int[] zahlen;
			zahlen = new int[10];
			zahlen[3] = 5;
			Console.WriteLine(zahlen[3]);

			int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Direkte Initialisierung, Länge automatisch (5)
			int[] zahlenDirektKurz = new[] { 1, 2, 3, 4, 5 }; //Kurzschreibweise 
			int[] zahlenDirektNochKuerzer = { 1, 2, 3, 4, 5 }; //Kürzeste Schreibweise

			Console.WriteLine(zahlenDirekt.Length); //5
			Console.WriteLine(zahlenDirekt.Contains(3)); //Ist das Element enthalten? true/false
			int[,] zweiDArray = new int[3, 3]; //Matrix (3x3), Kommas in der Klammer bestimmen die Anzahl Dimensionen
			zweiDArray[1, 2] = 3;
			/*
				 0 0 0
				 0 0 3
				 0 0 0
			*/

			Console.WriteLine(zweiDArray[1, 2]);

			zweiDArray = new[,] //Direkte Initialisierung
			{
				{ 1, 2, 3 },
				{ 1, 3, 4 },
				{ 1, 4, 5 }
			};

			Console.WriteLine(zweiDArray.Length); //Gesamtanzahl der Felder (9)
			Console.WriteLine(zweiDArray.Rank); //Anzahl der Dimensionen (2)
			Console.WriteLine(zweiDArray.GetLength(0)); //Länge einer Dimension (3)
			Console.WriteLine(zweiDArray.GetLength(1)); //Länge einer Dimension (3)
			#endregion

			#region Bedingungen
			bool b1 = true;
			bool b2 = false;

			if (b1 ^ b2) //Wenn Bedingungen unterschiedlich sind
			{

			}

			b1 = !b1; //boolean invertieren
			b1 ^= true;
			//App.MainWindow.Button.Boolean = !App.MainWindow.Button.Boolean
			//App.MainWindow.Button.Boolean ^= true; //boolean umdrehen

			//Fragezeichen Operator (Ternary Operator): if/else in eine Zeile schreiben
			if (zahlen.Length > 5)
			{
				Console.WriteLine("Zahlen ist länger als 5");
			}
			else
			{
				Console.WriteLine("Zahlen ist kürzer oder genau 5");
			}

			if (zahlen.Length > 5)
				Console.WriteLine("Zahlen ist länger als 5");
			else
				Console.WriteLine("Zahlen ist kürzer oder genau 5");

			string s = zahlen.Length > 5 ? "Zahlen ist länger als 5" : "Zahlen ist kürzer oder genau 5"; //Rechts müssen Werte herauskommen
			Console.WriteLine(s); //? ist if, : ist else

			int x = 0;
			if (zahlen.Length > 5)
				x = 5;
			else
				x = zahlen.Length;

			int y = zahlen.Length > 5 ? 5 : zahlen.Length;
			#endregion
		}
	}
}