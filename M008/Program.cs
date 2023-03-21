namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("Max", 34);
		m.Name = "Test"; //Property wurde vererbt
		m.WasBinIch(); //Methode wurde vererbt

		Console.WriteLine(m.Alter);

		Lebewesen lw = new Lebewesen("Max");
		//Console.WriteLine(lw.Alter); //Vererbung geht nur nach unten
		
		m.WasBinIch2(); //Ich bin ein Mensch
		lw.WasBinIch2(); //Ich bin ein Lebewesen

		Console.WriteLine(lw.ToString()); //M008.Lebewesen
		Console.WriteLine(m.ToString()); //M008.Mensch
		Console.WriteLine(384.ToString()); //384
	}
}

public class Lebewesen //Basisklasse
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

	public override string ToString() //Überschreibung wird nach unten weitergegeben
	{
		return $"Der Typ dieses Objekts ist " + base.ToString(); //Basisimplementation von ToString() überschreiben, Typagnostisch
	}
}

public sealed class Mensch : Lebewesen //Mensch ist ein Lebewesen (Vererbung herstellen)
{
	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name) //Konstruktoren zwischen Klassen verketten mit base(...)
	{
		Alter = alter; //Extra Feld hinzufügen bei den Parametern
	}

	public override void WasBinIch2()
	{
		//base.WasBinIch2(); //Mit base.<Methode> auf die Basisimplementation zugreifen
		Console.WriteLine("Ich bin ein Mensch");
	}

	public sealed override string ToString()
	{
		return base.ToString() + " und es kann sprechen";
	}
}

//public class Kind : Mensch //Nicht möglich, da Mensch sealed ist
//{
//	public Kind(string name, int alter) : base(name, alter)
//	{
//	}

//	public override string ToString() //Nicht möglich, da ToString von Mensch sealed ist
//	{
//		return base.ToString();
//	}
//}