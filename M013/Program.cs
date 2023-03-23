namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; //Alle Exceptions loggen
		//throw new Exception("Test");

		try //Codeblock markieren + Rechtsklick -> Surround with -> try(f)
		{
			string eingabe = Console.ReadLine(); //Maus über Methode -> Exception sind die Fehler die auftreten können
			int x = int.Parse(eingabe); //3 mögliche Exceptions: ArgumentNullException, FormatException, OverflowException
			if (x == 0)
			{
				throw new TestException("Zahl darf nicht 0 sein"); //beliebige Exception werfen
			}
		}
		catch (FormatException) //Keine Zahl (Buchstaben)
		{
			Console.WriteLine("Keine Zahl eingegeben");
		}
		catch (OverflowException e) //Zahl ist zu groß/klein
		{
			Console.WriteLine("Die Zahl ist zu groß/klein");
			Console.WriteLine();
			Console.WriteLine(e.Message); //Systeminterne Nachricht
			Console.WriteLine(e.StackTrace); //Nachverfolgung von Fehler im Code, von unten nach oben lesen
		}
		catch (TestException e)
		{
			Console.WriteLine($"TestException gefangen, {e.Message}");
			e.Test(); //Test Methode im catch Block sichtbar
		}
		catch (Exception e) //Alle anderen Fehler
		{
			Console.WriteLine($"Anderer Fehler: {e.Message}");
			Console.WriteLine(e.StackTrace);
			throw; //Exception weiterwerfen, nützlich bei fatalen Fehlern
		}
		finally //Wird immer ausgeführt nach try/catch, auch bei Fehlern
		{
			Console.WriteLine("Parsen abgeschlossen");
		}
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText("Log.txt", $"{ex.Message}\n{ex.StackTrace}");
	}
}

public class TestException : Exception //Eigene Exception muss von einer Exception Klasse erben
{
	public TestException(string? message) : base(message)
	{

	}

	public void Test() { }
}