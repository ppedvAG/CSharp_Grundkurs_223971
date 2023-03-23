namespace M014;

internal class Events
{
	//event: Statischer Punkt an den Methoden angehängt werden können (kann nicht erstellt werden)
	static event EventHandler TestEvent;

	static event EventHandler<TestEventArgs> ArgsEvent;

	static event EventHandler<int> IntEvent;

	static void Main(string[] args)
	{
		TestEvent += Events_TestEvent; //Anwenderseite: Methode anhängen, die beim feuern der Events ausgeführt wird
		TestEvent(null, EventArgs.Empty); //Entwicklerseite: Event feuern wenn etwas passiert

		ArgsEvent += Events_ArgsEvent1;
		ArgsEvent(null, new TestEventArgs("Fertig"));

		IntEvent += Events_ArgsEvent;
		IntEvent(null, 5);
	}
	private static void Events_TestEvent(object? sender, EventArgs e)
	{
		Console.WriteLine("Event wurde gefeuert");
	}

	private static void Events_ArgsEvent1(object? sender, TestEventArgs e)
	{
		Console.WriteLine($"Der Status ist {e.Status}");
	}


	private static void Events_ArgsEvent(object? sender, int e)
	{
		Console.WriteLine($"Die Zahl ist {e}");
	}
}

internal class TestEventArgs : EventArgs
{
	public string Status { get; set; }

	public TestEventArgs(string status)
	{
		Status = status;
	}
}