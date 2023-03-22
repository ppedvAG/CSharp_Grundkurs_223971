using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace M011
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Erstellung einer Liste mit Generic
			//List: funktioniert wie Array (foreach, [], ...) nur hat endlos viel Platz
			List<int> ints = new List<int>();
			ints.Add(1); //T wird ersetzt durch int
			ints.Add(2); //T wird ersetzt durch int
			ints.Add(3); //T wird ersetzt durch int

			List<string> strings = new List<string>();
			strings.Add("123"); //T wird ersetzt durch string

			Console.WriteLine(ints[2]); //wie bei Array angreifen
			ints[1] = 10; //wie bei Array bestehende Werte überschreiben

			Console.WriteLine(ints.Count); //Count == Length bei Array, nicht Count() benutzen

			ints.Sort();

			foreach (int i in ints) //Liste iterieren wie bei Arrays
			{
				Console.WriteLine(i);
			}

			if (ints.Contains(3))
			{
				//True
			}

			ints.Clear(); //Entleert die Liste

			////////////////////////////////////////////////////////
			
			Stack<int> stack = new Stack<int>();
			stack.Push(1); //Elemente auflegen
			stack.Push(2);
			stack.Push(3);

			stack.Peek(); //Oberstes Element anschauen

			stack.Pop(); //Oberstes Element anschauen und entfernen

			Queue<int> queue = new Queue<int>();
			queue.Enqueue(1); //Neues Element anstellen
			queue.Enqueue(2); //Neues Element anstellen
			queue.Enqueue(3); //Neues Element anstellen
			
			queue.Peek(); //Erstes Mitglied der Schlange anschauen

			queue.Dequeue(); //Erstes Mitglied der Schlange anschauen und entfernen

			////////////////////////////////////////////////////////
			
			Dictionary<string, int> einwohnerzahlen = new(); //Liste von Key-Value Paaren, Keys müssen eindeutig sein
			einwohnerzahlen.Add("Wien", 2_000_000); //Zwei Parameter: Key = string, Value = int
			einwohnerzahlen.Add("Berlin", 3_650_000);
			einwohnerzahlen.Add("Paris", 2_160_000);
			//einwohnerzahlen.Add("Paris", 2_160_000); //ArgumentException

			if (!einwohnerzahlen.ContainsKey("Paris")) //Vorher schauen ob der Key bereits enthalten ist
			{
				einwohnerzahlen.Add("Paris", 2_160_000);
			}

			einwohnerzahlen.ContainsValue(2_000_000);

			Console.WriteLine(einwohnerzahlen["Wien"]); //Dictionary angreifen mit [] über den Key (hier string), Value als Ergebnis

			foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //Dictionary iterieren mit dem KeyValuePair Struct, mit var + Strg + . den vollen Typen generieren lassen
			{
				Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner."); //mit kv.Key und kv.Value einzelne Werte angreifen
			}

			List<string> keys = einwohnerzahlen.Keys.ToList(); //Nur auf Keys zugreifen
			List<int> values = einwohnerzahlen.Values.ToList(); //Nur auf Values zugreifen

			SortedDictionary<string, int> sortedEinwohnerzahlen = new(); //1:1 wie Dictionary, sortiert sich automatisch nach Key
			sortedEinwohnerzahlen.Add("Wien", 2_000_000);
			sortedEinwohnerzahlen.Add("Berlin", 3_650_000); //Berlin vor Wien
			sortedEinwohnerzahlen.Add("Paris", 2_160_000); //Paris zwischen Berlin und Wien (achtung Performance)

			////////////////////////////////////////////////////////

			ObservableCollection<string> str = new(); //Benachrichtigt bei Listenänderungen
			str.CollectionChanged += Str_CollectionChanged; //Methode wird jedes mal ausgeführt, wenn sich in der Liste etwas ändert
			str.Add("X");
			str.Add("Y");
			str.Add("Z");
			str.Remove("Y");
		}

		private static void Str_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					Console.WriteLine($"Element hinzugefügt: {e.NewItems[0]}");
					break;
				case NotifyCollectionChangedAction.Remove:
					Console.WriteLine($"Element entfernt: {e.OldItems[0]}");
					break;
			}
		}
	}
}