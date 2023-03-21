using M006.Bauteil;

namespace M006
{
	internal class Raum
	{
		public Tuer Tuere { get; set; }

		public Fenster[] Fenster = new Fenster[10];

		public double Laenge, Breite;
	}
}
