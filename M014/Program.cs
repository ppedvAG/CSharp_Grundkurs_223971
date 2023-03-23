namespace M014;

internal class Program
{
	public delegate void Vorstellungen(string name); //Definition von Delegate, speichert Referenzen auf Methoden (Methodenzeiger), können zur Laufzeit hinzugefügt oder weggenommen werden

	static void Main(string[] args)
	{
		Vorstellungen v = new Vorstellungen(VorstellungDE); //Variablendeklaration + Erstellung mit einer Initialmethode
		v("Max"); //Alle Methoden am Delegate ausführen

		v += VorstellungEN; //Methode anhängen
		v("Lukas");

		v -= VorstellungDE; //Nimmt die letzte Methode mit dem gegebenen Namen ab
		v("Stefan");

		v -= VorstellungDE; //Methode die nicht angehängt ist abnehmen, gibt keine Fehlermeldung
		v -= VorstellungDE;
		v -= VorstellungDE;
		v -= VorstellungDE;

		v -= VorstellungEN; //Delegate ist null wenn die letzte Methode abgenommen wird
		//v("Max"); //Exception

		if (v is not null)
			v("Max");

		foreach (Delegate dg in v.GetInvocationList()) //Methoden auf dem Delegate durchgehen
		{
			Console.WriteLine(dg.Method.Name);
		}
	}

	static void VorstellungDE(string name)
	{
		Console.WriteLine($"Hallo mein Name ist {name}");
	}

	static void VorstellungEN(string name)
	{
		Console.WriteLine($"Hello my name is {name}");
	}
}