namespace M007
{
	internal class Program
	{
		public static string Info = "Eine Information";

		static void Main(string[] args)
		{
			#region GC
			for (int i = 0; i < 5; i++)
			{
				Fenster f = new Fenster();
				Console.WriteLine(f.GetHashCode());
			}

			GC.Collect(); //Hier GC erzwingen
			GC.WaitForPendingFinalizers(); //Warte auf alle Destruktoren

			Fenster f1 = new();
			Fenster f2 = new();
			if (f1 == f2)
			{
				//Hier werden die HashCodes (GetHashCode()) der beiden Objekte verglichen
			}
			#endregion

			#region Static
			//Statische Member müssen ohne Objekte arbeiten
			//new Program().Main(args); //nicht möglich, da statisch
			//Program.Main(args); //Statische Methoden müssen über den Klassennamen angesprochen werden

			//Console c = new Console(); //Von statischen Klassen kann kein Objekt erstellt werden
			//c.WriteLine();
			//Console.WriteLine();

			Console.WriteLine(Program.Info);

			//StaticTest(); //nicht möglich, da nicht statisch
			new Program().StaticTest();

			//DateTime.Now


			Program[] p = new Program[10];
			for (int i = 0; i < p.Length; i++)
			{
				p[i] = new Program();
			}
			Program.Info = "Zwei Informationen"; //Wird bei allen Objekten angepasst
			#endregion

			#region Werte-/Referenztypen
			//Wertetyp
			int original = 5;
			int x = original;
			original = 10;
			Console.WriteLine(original.GetHashCode());
			Console.WriteLine(x.GetHashCode()); //Unterschiedliche HashCodes

			//Referenztyp
			Fenster f3 = new();
			Fenster f4 = f3;
			f3.Breite = 5;
			Console.WriteLine(f3.GetHashCode());
			Console.WriteLine(f4.GetHashCode()); //Gleiche HashCodes, zeigen auf das selbe Objekt im RAM

			//class
			//Referenztyp
			//==, != werden Speicheradressen verglichen
			//Zuweisungen haben Referenzen statt Kopien

			//struct
			//Wertetyp
			//==, != werden die Werte in dem Objekt verglichen
			//Zuweisungen haben Kopien statt Referenzen
			#endregion

			#region Null
			Fenster f5; //Standardmäßig null (es hängt kein Wert daran)
			f5 = null; //Referenz zum Objekt trennen
			//f5.FensterOeffnen(); //Nicht vorhandenes Fenster kann nicht geöffnet werden

			if (f5 != null) //Schauen ob das Objekt existiert
			{
				f5.FensterOeffnen();
			}

			if (f5 == null)
			{
				f5 = new Fenster();
			}

			if (f5 is null && f5 is not null) //Selbiges wie == und !=
			{

			}
			#endregion
		}

		public void StaticTest()
		{
			Console.WriteLine(Program.Info);
		}
	}
}