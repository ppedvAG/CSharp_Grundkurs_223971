using M013;

namespace M013_Tests
{
	[TestClass]
	public class RechnerTests
	{
		//Dependencies -> Rechtsklick -> Add Projekt Reference -> Projekt auswählen
		//Test Explorer -> View -> Test Explorer

		Rechner r;

		[TestInitialize]
		public void Init()
		{
			r = new Rechner();
		}

		[TestCleanup]
		public void Cleanup()
		{
			r = null;
		}

		[TestMethod]
		[TestCategory("AddiereTest")]
		public void TesteAddiere()
		{
			double ergebnis = r.Addiere(5, 7);
			Assert.AreEqual(12, ergebnis); //Assert-Klasse: Um Ergebnis von Tests auszuwerten
		}

		[TestMethod]
		[TestCategory("SubtrahiereTest")]
		public void TesteSubtrahiere()
		{
			double ergebnis = r.Subtrahiere(8, 5);
			Assert.AreEqual(3, ergebnis);
		}
	}
}