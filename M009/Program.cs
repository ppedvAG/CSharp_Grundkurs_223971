namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("Max", 11); //Variablentyp Mensch, kann alle Objekte vom Typ Mensch oder einer Unterklasse halten

		Lebewesen lw = new Mensch("Max", 11); //Variablentyp Lebewesen, kann alle Objekte vom Typ Lebewesen oder einer Unterklasse halten
		
		object o = new Mensch("Max", 11); //Variablentyp Object, kann alle Objekte halten
		o = 123; //int
		o = false; //bool
		o = "Test"; //string

		lw = m; //Kompatibel weil Lebewesen > Mensch
		//m = lw; //Nicht kompatibel
		m = (Mensch) lw; //Möglich, gibt eine Exception wenn nicht kompatibel

		//GetType(): gibt den Typen des Objektes zurück
		Console.WriteLine(m.GetType()); //M009.Mensch
		Console.WriteLine(lw.GetType()); //M009.Mensch
		Console.WriteLine(o.GetType()); //System.String

		Type tm = m.GetType(); //GetType() gibt ein Type Objekt
		Type typeofM = typeof(Mensch); //Über typeof(<Name>) einen Typen über einen Klassennamen erzeugen

		#region Exakter Typvergleich
		if (m.GetType() == typeof(Mensch)) //Ist m genau ein Mensch?
		{
			//true
		}

		if (m.GetType() == typeof(Lebewesen))
		{
			//false
		}
		#endregion

		#region Vererbungshierarchie Typvergleich
		if (m is Mensch) //Ist m ein Mensch oder eine Unterklasse von Mensch?
		{
			//true
		}

		if (m is Lebewesen)
		{
			//true
		}

		if (m is object)
		{
			//immer true
		}

		if (m is Program)
		{
			//false
		}
		#endregion

		#region Virtual Override
		Mensch mensch = new Mensch("", 123);
		mensch.WasBinIch2(); //Ich bin ein Mensch und bin 123 Jahre alt

		Lebewesen l3 = mensch;
		l3.WasBinIch2(); //Ich bin ein Mensch und bin 123 Jahre alt
						 //Verbindung zwischen Lebewesen und Mensch hergestellt, deshalb wird die Mensch Methode verwendet
		#endregion

		#region New
		Mensch mensch2 = new Mensch("", 123);
		mensch2.WasBinIch(); //Ich bin ein Mensch

		Lebewesen l4 = mensch2;
		l4.WasBinIch(); //Ich bin ein Lebewesen
						//Hier wird die Methode von Lebewesen verwendet, da die Verbindung getrennt wurde
		#endregion

		Lebewesen[] array = new Lebewesen[3]; //Array von Lebewesen kann alle Unterklassen halten (Mensch und Katze)
		array[0] = new Mensch("Max", 23);
		array[1] = new Katze("");
		array[2] = new Mensch("", 123);

		foreach (Lebewesen leb in array) //Hier nur generisches Lebewesen, mit Typvergleichen schauen was es genau ist
		{
			if (leb.GetType() == typeof(Mensch))
			{
				Mensch men = (Mensch) leb;
				men.MenschMethode();
			}

			if (leb is Katze k)
			{
				//Katze k = (Katze) leb; //kann gespart werden, da Variablendeklaration in der if passiert
				k.KatzeMethode();
			}
		}

		//new Lebewesen(); //Nicht möglich
	}
}



public abstract class Lebewesen //abstract: Strukturklasse für die Unterklassen, kann nicht instanziert werden
{
	public string Name { get; set; } //Wird nach unten vererbt

	public void WasBinIch() //Wird auch nach unten vererbt
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}

	public virtual void WasBinIch2() //virtual: kann überschrieben werden, muss aber nicht
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}

	public Lebewesen(string name)
	{
		Name = name;
	}

	public abstract void Bewegen(); //Abstrakte Methoden haben keinen Body
}

public class Mensch : Lebewesen //Mensch ist ein Lebewesen (Vererbung herstellen)
{
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name) //Konstruktoren zwischen Klassen verketten mit base(...)
	{
		Alter = alter; //Extra Feld hinzufügen bei den Parametern
	}

	public new void WasBinIch() //Nicht virtuelle Methode überschreiben
	{
		Console.WriteLine("Ich bin ein Mensch");
	}

	public override void WasBinIch2()
	{
		//base.WasBinIch2(); //Mit base.<Methode> auf die Basisimplementation zugreifen
		Console.WriteLine("Ich bin ein Mensch");
	}

	public override void Bewegen()
	{
		Console.WriteLine("Der Mensch bewegt sich");
	}

	public void MenschMethode() { }
}

public class Katze : Lebewesen
{
	public Katze(string name) : base(name)
	{

	}

	public override void Bewegen()
	{
		Console.WriteLine("Die Katze bewegt sich");
	}

	public void KatzeMethode()
	{

	}
}