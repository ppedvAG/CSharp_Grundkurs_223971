using System.Collections;
using System.Diagnostics;

namespace M017;

internal class Program
{
	static void Main(string[] args)
	{
		Wagon w1 = new();
		Wagon w2 = new();
		Console.WriteLine(w1 == w2);

		Zug z = new();
		z += w1;
		z += w2;
		z++;
		z++;
		z++;
		z++;

		foreach (Wagon w in z)
		{
			Console.WriteLine(w.GetHashCode());
		}

		Console.WriteLine(z[2].GetHashCode());
		//Console.WriteLine(z["Rot"].GetHashCode());
		//Console.WriteLine(z[3, "Rot"]);
		//z["Rot"] = new Wagon();

		Stopwatch sw = new();
		sw.Start();
		Thread.Sleep(500);
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);

		System.Timers.Timer timer = new();
		timer.Elapsed += (sender, args) => Console.WriteLine("Intervall vergangen");
		timer.Interval = 1000;
		timer.Start();

		Console.ReadKey();
	}
}

public class Zug : IEnumerable
{
	private List<Wagon> Wagons = new();

	public IEnumerator GetEnumerator()
	{
		return Wagons.GetEnumerator();
	}

	public static Zug operator +(Zug z, Wagon w)
	{
		z.Wagons.Add(w);
		return z;
	}

	public static Zug operator ++(Zug z)
	{
		z.Wagons.Add(new Wagon());
		return z;
	}

	public Wagon this[int index]
	{
		get => Wagons[index];
		set => Wagons[index] = value;
	}

	public Wagon this[string farbe]
	{
		get => Wagons.First(e => e.Farbe == farbe);
	}

	public Wagon this[int anz, string farbe]
	{
		get => Wagons.First(e => e.Farbe == farbe && e.AnzSitze == anz);
	}
}

public class Wagon
{
	public int AnzSitze;
	public string Farbe;

	public static bool operator ==(Wagon a, Wagon b)
	{
		return a.AnzSitze == b.AnzSitze && a.Farbe == b.Farbe;
	}

	public static bool operator !=(Wagon a, Wagon b)
	{
		return !(a == b);
	}
}