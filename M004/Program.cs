using System.Net;

namespace M004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Schleifen
			int a = 0;
			int b = 10;
			while (a < b) //Schleife läuft solange die Bedingung true ist
			{
				Console.WriteLine("while: " + a);
				if (a == 5)
					break; //Break: beendet die Schleife
				a++;
			}

			int c = 0;
			int d = 10;
			do //Wird mindestens einmal ausgeführt, auch wenn die Bedingung von Anfang an false ist
			{
				c++;
				if (c == 5)
					continue; //Continue: springt in den Schleifenkopf zurück (Code darunter wird ausgelassen)
				Console.WriteLine("do-while: " + c);
			}
			while (c < d);

			//while (true) { } //Endlosschleife

			c = 0;
			while (true) //do-while mit while (true)
			{
				c++;
				if (c == 5)
					continue;
				Console.WriteLine("while true: " + c);


				if (c >= d)
					break; //Äquivalent zur Bedingung im do-while
			}

			//for + Tab + Tab
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("for: " + i);
			}

			//forr + Tab + Tab
			for (int i = 9; i >= 0; i--)
			{
				Console.WriteLine("forr: " + i);
			}

			//for Schleife ist sehr flexibel was Zählervariablen und Inkrement betrifft
			for (int i = 1, counter = 0; counter < 10 && i != 0; i *= 2, counter++)
			{
				Console.WriteLine(i);
			}

			int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
			for (int i = 0; i < zahlen.Length; i++) //Array durchgehen und ausgeben
			{
				Console.WriteLine(zahlen[i]); //for Schleife kann daneben greifen, daher suboptimal um Arrays durchzugehen
			}

			//foreach + Tab + Tab
			foreach (int item in zahlen) //Array durchgehen aber kann nicht daneben greifen, da kein Index
			{
				Console.WriteLine(item);
			}

			foreach (int item in zahlen) //Einzeilige Schleifen können auch ohne Klammern geschrieben werden
				Console.WriteLine(item);

			string s = "Hallo";
			foreach (char zeichen in s) //String durchgehen mit foreach
			{
				Console.WriteLine(zeichen);
			}
			#endregion

			#region Enums
			string tag = Console.ReadLine(); //User Eingabe
			if (tag == "Montag")
			{
				Console.WriteLine("Es ist Montag"); //Fehleranfälligkeit bei Strings
			}

			Wochentag wt = Enum.Parse<Wochentag>(tag, true); //Konvertiert einen String (unabhängig von Groß-/Kleinschreibung) oder eine Zahl zu dem gegebenen Enum
			if (wt == Wochentag.Mo)
			{
				Console.WriteLine("Es ist Montag");
			}

			int x = 2;
			Wochentag cast = (Wochentag) x;
			int y = (int) cast;

			Wochentag[] alleTage = Enum.GetValues<Wochentag>(); //Aus einem Enum alle Werte in ein Array entnehmen
			foreach (Wochentag w in alleTage) //Über alle Enumwerte iterieren
			{
				Console.WriteLine(w);
			}
			#endregion

			#region Switch
			Wochentag sw = Wochentag.Fr;
			if (sw == Wochentag.Mo)
			{
				Console.WriteLine("Wochenanfang");
			}
			else if (sw == Wochentag.Di || sw == Wochentag.Mi || sw == Wochentag.Do || sw == Wochentag.Fr)
			{
				Console.WriteLine("Wochenmitte");
			}
			else if (sw == Wochentag.Sa || sw == Wochentag.So)
			{
				Console.WriteLine("Wochenende");
			}
			else
			{
				Console.WriteLine("Fehler");
			}


			switch (sw) //if-else Baum mit Switch
			{
				case Wochentag.Mo: //Sozusagen eine if -> sw == Wochentag.Mo
					Console.WriteLine("Wochenanfang");
					break; //Am Ende von jedem Case ein break machen
				case Wochentag.Di:
				case Wochentag.Mi:
				case Wochentag.Do: //Mehrere Cases kombiniert (Di-Fr)
				case Wochentag.Fr:
					Console.WriteLine("Wochenmitte");
					break;
				case Wochentag.Sa:
				case Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				default: //Sozusagen ein else
					Console.WriteLine("Fehler");
					break; //default case kann weggelassen werden
			}


			switch (sw) //Switch mit boolescher Logik
			{
				//and/or statt &&/||
				case >= Wochentag.Mo and <= Wochentag.Fr:
					Console.WriteLine("Wochentag");
					break;
				case Wochentag.Sa or Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
				default:
					Console.WriteLine("Fehler");
					break;
			}
			#endregion
		}
	}

	public enum Wochentag
	{
		Mo = 1, //Enumwerten eigene Werte zuweisen, Rest wird aufgeschoben
		Di,
		Mi,
		Do = 10, //hier neu anfangen zu zählen
		Fr,
		Sa,
		So
	}
}