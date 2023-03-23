namespace M014;

internal class ComponentWithEvent
{
	static void Main(string[] args)
	{
		Component comp = new Component();
		comp.ProcessCompleted += Comp_ProcessCompleted;
		comp.Progress += e => Console.WriteLine($"Fortschritt: {e}");
		comp.StartProcess();
	}

	private static void Comp_ProcessCompleted()
	{
		//Console.WriteLine("Prozess fertig");
		File.WriteAllText("Prozess.txt", "Prozess fertig");
	}
}

public class Component
{
	public event Action ProcessCompleted; //Wenn der Prozess fertig ist, wird dieses Event gefeuert

	public event Action<int> Progress; //Wenn der Prozess voranschreitet, wird dieses Event gefeuert

	public void StartProcess() //Daten holen von einer Datenbank
	{
		for (int i = 0; i < 10; i++)
		{
			//Tu etwas...
			Thread.Sleep(200);
			Progress(i);
		}
		ProcessCompleted();
	}
}
