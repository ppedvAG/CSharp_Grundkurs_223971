using System.Text;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8; //€ Zeichen sichtbar machen

		Mensch m = new Mensch();
		m.Job = "Softwareentwickler";
		m.Gehalt = 5000;
		//m.Lohnauszahlung();

		IArbeit a = m; //Variable vom Typ IArbeit genau wie bei Vererbung
		a.Lohnauszahlung(); //Jede Klasse hat das Interface -> Lohnauszahlung erzwungen

		ITeilzeitArbeit a2 = m;
		a2.Lohnauszahlung(); //Für explizite Methodenaufrufe muss das Objekt in den entsprechenden Interfacetypen umgewandelt werden

		//IEnumerable: Basisinterface für alle Listen in C# (Array, List, Dictionary, ...)
		IEnumerable<int> e1 = new int[1];
		IEnumerable<int> e2 = new List<int>();
		IEnumerable<KeyValuePair<string, int>> e3 = new Dictionary<string, int>();

		e1.Sum();
		e2.Sum();
		//e3.Sum();

		Test(e1);
		Test(e2);
		Test(e3);

		void Test<T>(IEnumerable<T> x)
		{

		}
	}
}

public class Lebewesen { }

public class Mensch : Lebewesen, IArbeit, ITeilzeitArbeit
{
	public int Gehalt { get; set; }

	public string Job { get; set; }

	//int ITeilzeitArbeit.Gehalt { get; set; }
	//string ITeilzeitArbeit.Job { get; set; }

	void IArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ für den Job {Job} erhalten. " +
			$"Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche."); //statisches Feld angreifen
	}

	void ITeilzeitArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt / 2}€ für den Job {Job} erhalten. " +
			$"Er arbeitet {ITeilzeitArbeit.Wochenstunden} Stunden pro Woche.");
	}
}

public interface IArbeit //Interfaces fangen per Konvention mit I an
{
	static readonly int Wochenstunden = 40; //statisches Feld über IArbeit.Wochenstunden angreifen

	int Gehalt { get; set; }

	string Job { get; set; } //Properties werden weitergegeben

	void Lohnauszahlung(); //Methoden ohne Body wie bei abstrakten Klassen

	public void Test()
	{
		//Bad practice
	}
}

public interface ITeilzeitArbeit : IArbeit //Interfaces können auch vererbt werden
{
	static readonly new int Wochenstunden = 20; //new um explizite Überschreibung zu definieren

	//int Gehalt { get; set; } //kommt von oben

	//string Job { get; set; } //kommt von oben

	new void Lohnauszahlung(); //new um explizite Überschreibung zu definieren
}