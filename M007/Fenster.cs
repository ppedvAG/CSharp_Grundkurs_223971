namespace M007
{
	internal class Fenster
	{
		#region Variable + Get/Set
		private double laenge; //Felder sollten nicht von außen angreifbar sein (nur über Methoden)

		/// <summary>
		/// Gibt die Länge des Fensters zurück.
		/// </summary>
		/// <returns>Die Länge des Fensters in Meter.</returns>
		public double GetLaenge()
		{
			return laenge;
		}

		/// <summary>
		/// Setzt die Länge des Fensters auf einen neuen Wert.
		/// </summary>
		/// <param name="neueLaenge">Die neue Länge des Fensters in Meter (0 bis 10).</param>
		public void SetLaenge(double neueLaenge)
		{
			if (neueLaenge > 0 && neueLaenge < 10) //Überprüfung machen bevor die Länge gesetzt wird
			{
				laenge = neueLaenge;
			}
			else
			{
				Console.WriteLine("Neue Länge zu klein/groß");
			}
		}
		#endregion

		#region Properties
		private double breite;

		public double Breite
		{
			get //Äquivalent zur Get-Methode
			{
				return breite;
			}
			set //Äquivalent zur Set-Methode
			{
				if (value > 0 && value < 10)
					breite = value; //value: Der neue Wert (Äquivalent zu neueLaenge in SetLaenge)
				else
					Console.WriteLine("Neue Breite ist zu klein/groß");
			}
		}

		public double BreiteKurz
		{
			get => breite; //Get-Accessor in Kurzform durch Expression Body
			set //Äquivalent zur Set-Methode
			{
				if (value > 0 && value < 10)
					breite = value; //value: Der neue Wert (Äquivalent zu neueLaenge in SetLaenge)
				else
					Console.WriteLine("Neue Breite ist zu klein/groß");
			}
		}

		private FensterStatus status = FensterStatus.Geschlossen; //Hier Standardwert auf Variablenebene setzen

		public FensterStatus Status
		{
			get => status;
			private set //private set: nicht von außen setzbar (nur innerhalb der Klasse)
			{
				status = value;
			}
		}

		/// <summary>
		/// Eine Methode die das Fenster öffnet.
		/// </summary>
		public void FensterOeffnen()
		{
			if (Status != FensterStatus.Offen)
				Status = FensterStatus.Offen; //private set ist hier sichtbar
			else
				Console.WriteLine("Fenster ist bereits geöffnet.");
		}

		//Get-Only Property
		public double Area
		{
			get
			{
				return laenge * breite;
			}
		}

		public double Area2
		{
			get => laenge * breite;
		}

		public double Area3 => laenge * breite;

		public double CalcArea() => laenge * breite;

		public int Scheibenanzahl { get; private set; } = 2; //Standardwert setzen auf Propertyebene
		#endregion

		#region Konstruktor
		public Fenster() { } //Leerer Konstruktor wird gelöscht, wenn ein eigener Konstruktor erstellt wird

		/// <summary>
		/// Der Initialcode des Fensters.
		/// </summary>
		/// <param name="laenge">Die Länge des Fensters</param>
		/// <param name="breite">Die Breite des Fensters</param>
		public Fenster(double laenge, double breite) //Konstruktor: Code der bei Erstellung des Objekts ausgeführt wird (new)
		{
			this.laenge = laenge; //this: nach oben (in die Klasse) greifen (hier laenge = laenge setzt den Wert auf den Parameter selbst)
			this.breite = breite;
		}

		public Fenster(double laenge, double breite, int scheiben) : this(laenge, breite) //Konstruktoren verketten (wenn dieser Konstruktor verwendet wird, wird auch der obere verwendet)
		{
			Scheibenanzahl = scheiben;
		}
		#endregion

		//~ + Tab + Tab
		~Fenster()
		{
			Console.WriteLine($"Fenster eingesammelt {GetHashCode()}"); //Wird aufgerufen wenn der Garbage Collector das Objekt einsammelt
			//GetHashCode(): Zeigt die Speicheradresse
		}
	}

	public enum FensterStatus
	{
		Offen, Gekippt, Geschlossen
	}
}
