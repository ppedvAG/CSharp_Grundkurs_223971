using M006.Bauteil; //mit Using andere Namespaces importieren (Klassen herüberholen)

namespace M006
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Fenster f = new Fenster(); //Fenster Objekt erstellen mit dem new Keyword
			f.SetLaenge(3); //Länge setzen über Set-Methode
			f.Breite = 3; //Breite setzen über Set-Property

			f.FensterOeffnen();
			//f.Status = FensterStatus.Geschlossen; //Nicht möglich, da private set

			Console.WriteLine(f.Area);
			//f.Area = 20; //Nicht möglich, da Get-Only


			Fenster f2 = new Fenster(3, 3); //Standardwerte bei unserem neuen Konstruktor übergeben
			Fenster f3 = new Fenster(3, 3, 2);

			Tuer t = new Tuer();

			Raum r = new Raum();
			r.Tuere = t;
			r.Fenster[0] = f;
			r.Fenster[1] = f2;
			r.Fenster[2] = f3;
			r.Fenster[1].FensterOeffnen();
			
			//Console -> System
			//File -> System.IO
			//HttpClient -> System.Net.Http
		}
	}
}