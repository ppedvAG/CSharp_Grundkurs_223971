using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Enumerable.Range: Liste von <Start> bis <Anzahl> Elemente
		//Liste von 1-20
		List<int> ints = Enumerable.Range(1, 20).ToList();

		Console.WriteLine(ints.Sum());
		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());

		Console.WriteLine(ints.First()); //Erstes Element, Fehler wenn kein Element vorhanden
		Console.WriteLine(ints.FirstOrDefault()); //Erstes Element, null wenn kein Element vorhanden

		Console.WriteLine(ints.Last()); //Letztes Element, Fehler wenn kein Element vorhanden
		Console.WriteLine(ints.LastOrDefault()); //Letztes Element, null wenn kein Element vorhanden

		//Console.WriteLine(ints.First(e => e % 50 == 0)); //Finde das erste Element das durch 50 teilbar ist (Exception)
		Console.WriteLine(ints.FirstOrDefault(e => e % 50 == 0)); //0 als Ergebnis (Standardwert)
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq-Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsAlt = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq mit Lambda
		//Alle VWs finden
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW);

		//Alle VWs mit MaxV >= 200
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV >= 200);

		//Autos nach Marke sortieren
		fahrzeuge.OrderBy(e => e.Marke); //Originale Liste wird nicht verändert
		fahrzeuge.OrderByDescending(e => e.MaxV);

		//Autos nach Marke und danach nach Maximalgeschwindigkeit sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//Alle Marken finden
		fahrzeuge.Select(e => e.Marke);
		fahrzeuge.Select(e => e.Marke).Distinct(); //Marken einzigartig machen

		//Anwendungsbeispiel Select
		string[] pfadeMitEndungen = Directory.GetFiles(@"C:\Windows\System32"); //Pfade und Endungen wegschneiden
		List<string> shortPaths = new();
		foreach (string pfad in pfadeMitEndungen)
			shortPaths.Add(Path.GetFileNameWithoutExtension(pfad));

		List<string> pfade = Directory.GetFiles(@"C:\Windows\System32").Select(pfad => Path.GetFileNameWithoutExtension(pfad)).ToList();
		///////////////////////////

		//Fahren alle unsere Fahrzeuge mindestens 200km/h?
		fahrzeuge.All(e => e.MaxV >= 200);

		//Fährt mindestens ein Fahrzeug 200km/h?
		fahrzeuge.Any(e => e.MaxV >= 200);

		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Wieviele VWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW);

		//Wieviele VWs und BMWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW || e.Marke == FahrzeugMarke.BMW);

		//Wie schnell fahren unsere Autos im Durchschnitt?
		fahrzeuge.Average(e => e.MaxV);

		fahrzeuge.Sum(e => e.MaxV);

		fahrzeuge.Min(e => e.MaxV); //Min: Ergebnis int (die kleinste Geschwindigkeit)
		fahrzeuge.MinBy(e => e.MaxV); //MinBy: Ergebnis Fahrzeug (das Fahrzeug mit der kleinsten Geschwindigkeit)

		fahrzeuge.Max(e => e.MaxV); //Max: Ergebnis int (die größte Geschwindigkeit)
		fahrzeuge.MaxBy(e => e.MaxV); //MaxBy: Ergebnis Fahrzeug (das Fahrzeug mit der größten Geschwindigkeit)

		//Die Durchschnittsgeschwindigkeit aller VWs
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.VW)
			.Average(e => e.MaxV);

		//Alle Autos nach Marke gruppieren (Audi-Gruppe, BMW-Gruppe, VW-Gruppe)
		fahrzeuge.GroupBy(e => e.Marke);

		Dictionary<FahrzeugMarke, List<Fahrzeug>> dict = fahrzeuge
			.GroupBy(e => e.Marke)
			.ToDictionary(e => e.Key, e => e.ToList());

		fahrzeuge
			.GroupBy(e => e.Marke)
			.ToDictionary(e => e.Key, e => e.MinBy(x => x.MaxV)); //Bei verschachtelten Linq-Funktion sollten unterschiedliche Namen verwendet werden
		#endregion

		#region Erweiterungsmethoden
		int x = 843259;
		x.Quersumme();
		Console.WriteLine(58529058.Quersumme());

		ints.Shuffle();
		fahrzeuge.Shuffle();
		#endregion
	}
}

[DebuggerDisplay("Marke: {Marke}, Geschwindigkeit: {MaxV} - {typeof(Fahrzeug).FullName}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }