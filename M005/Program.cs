namespace M005
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintAddiere(3, 4); //Funktionsaufruf über den Namen der Funktion, Parameter müssen mit angegeben werden
			PrintAddiere(5, 6);
			PrintAddiere(7, 8);
			PrintAddiere(8, 9);
			PrintAddiere(9, 10);
			PrintAddiere(10, 11);

			int summe = Addiere(3, 4); //Ergebnis der Addiere Funktion in die neue summe Variable schreiben
			Console.WriteLine(summe);

			Console.WriteLine(); //18 Overloads -> verschiedene Implementationen der selben Funktion anhand von Parametern
			Console.WriteLine(0); //int-Overload auswählen
			Console.WriteLine(""); //string-Overload auswählen
			Console.WriteLine('1'); //char-Overload auswählen

			Addiere(3, 4); //int-Overload durch 2 ints als Parameter
			Addiere(3, 4.0); //double-Overload durch mindestens einen double Parameter
			Addiere(3, 4, 5); //3-int-Overload auswählen

			Summiere(); //auch keine Parameter sind beliebig viele Parameter
			Summiere(1, 2, 3);
			Summiere(1, 2, 3, 4, 5, 6, 7, 8, 9);

			Subtrahiere(7, 4, 2); //Optionalen Parameter befüllen
			Subtrahiere(5, 2); //Optionalen Parameter auf dem Standardwert lassen

			SubtrahiereOderAddiere(5, 2); //Standard: Subtrahieren
			SubtrahiereOderAddiere(5, 2, true); //Umschalten auf Addieren

			int result; //Variable muss vorher definiert werden
			if (int.TryParse("123", out result)) //über out result die Variable verbinden
			{
				Console.WriteLine(result); //Ergebnis des Parsens steht in der Variable, wenn das parsen funktioniert hat
			}
			else
			{
				Console.WriteLine("Parsen fehlgeschlagen");
			}

			(double, double) dd = SubtrahiereUndAddiere(5, 6);
			Console.WriteLine(dd.Item1);
			Console.WriteLine(dd.Item2);

			PrintWochentag(DayOfWeek.Wednesday);
		}

		static void PrintAddiere(int x, int y) //Funktion mit void (ohne Rückgabewert), Zwei Parameter: x, y
		{
			Console.WriteLine($"{x} + {y} = {x + y}");
		}

		static int Addiere(int x, int y) //Funktion mit Rückgabewert
		{
			return x + y; //Ergebnis der Funktion zurückgeben mit return
		}

		static double Addiere(double x, double y) //Funktion überladen: Funktion mit gleichem Namen definieren mit anderen Parametern (Rückgabetyp egal)
		{
			return x + y;
		}

		static int Addiere(int x, int y, int z)
		{
			return x + y + z;
		}

		static double Summiere(params double[] zahlen) //Mit Params können beliebig viele Parameter angegeben werden (muss ein Array sein)
		{
			return zahlen.Sum();
		}

		static double Subtrahiere(int x, int y, int z = 0) //Standardwert für z setzen, muss bei Aufruf nicht gesetzt werden
		{
			return x - y - z;
		}

		static double SubtrahiereOderAddiere(int x, int y, bool add = false) //Über den bool das Verhalten der Funktion anpassen
		{
			//if (add)
			//	return x + y;
			//else
			//	return x - y;
			return add ? x + y : x - y;
		}

		static double SubtrahiereUndAddiere(int x, int y, out double summe) //Out-Parameter: mehrere Werte zurückgeben
		{
			summe = x + y; //Muss zugewiesen werden vor return
			return x - y;
		}

		static (double, double) SubtrahiereUndAddiere(int x, int y)
		{
			return (x - y, x + y);
		}

		static string PrintWochentag(DayOfWeek wt)
		{
			switch (wt)
			{
				case DayOfWeek.Monday: return "Montag"; //Bei einem Switch mit return muss kein break verwendet werden
				case DayOfWeek.Tuesday: return "Dienstag";
				case DayOfWeek.Wednesday: return "Mittwoch";
				case DayOfWeek.Thursday: return "Donnerstag";
				case DayOfWeek.Friday: return "Freitag";
				case DayOfWeek.Saturday: return "Samstag";
				case DayOfWeek.Sunday: return "Sonntag";
				default: return "Fehler"; //Alle Code Pfade müssen einen Wert zurückgeben, daher default notwendig
			}
		}

		static void PrintZahl(int zahl)
		{
			if (zahl < 0)
			{
				Console.WriteLine("Zahl darf nicht kleiner 0 sein!");
				return; //Bei Fehler einfach Funktion beenden
			}

			Console.WriteLine(zahl);
			return; //Aus Funktion herausspringen / Funktion beenden
			Console.WriteLine(zahl); //Kann nicht erreicht werden
		}
	}
}