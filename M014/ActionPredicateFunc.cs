namespace M014;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		List<int> x = new();


		Action<int, int> action = Addiere; //Action: Methode mit void und bis zu 16 Parametern
		action(1, 2);
		DoAction(3, 4, Addiere); //Eigene Methode schreiben mit Action Parameter
		DoAction(4, 5, action); //Über die Action das Verhalten der Methode anpassen
		
		//Action Beispiele
		x.ForEach(Console.WriteLine); //Beispiel für Action Methode in List
		x.ForEach(PrintMalZwei); //Verhalten anpassen: 1. cw, 2. PrintMalZwei

		////////////////////////////////////////

		Predicate<int> pred = CheckForZero; //Predicate: Methode mit bool als Rückgabewert und genau einem Parameter
		bool b = pred(1);
		DoPredicate(1, CheckForZero); //Eigene Methode schreiben mit Predicate Parameter
		DoPredicate(2, pred); //Über das Predicate das Verhalten der Methode anpassen

		//Predicate Beispiele
		x.FindAll(CheckForZero);
		x.FindAll(e => e == 1);

		////////////////////////////////////////

		Func<int, int, double> func = Multipliziere; //Func: Methode mit Rückgabewert (letztes Generic ist der Rückgabetyp), bis zu 16 Parameter
		double d = func(4, 2);
		DoFunc(4, 5, Multipliziere); //Eigene Methode schreiben mit Func Parameter
		DoFunc(4, 6, func); //Über die Func das Verhalten der Methode anpassen

		//Func Beispiele
		x.Where(e => e == 1);

		////////////////////////////////////////

		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y; //Kürzeste, häufigste Form

		DoAction(4, 5, (x, y) => Console.WriteLine(x + y)); //Action als anonyme Methode
		DoPredicate(4, e => e % 2 == 0); //Ist die gegebene Zahl gerade?
		DoFunc(4, 5, (x, y) => x / y); //Anonyme Methode bei Func mit double als Ergebnis
	}

	#region Action
	private static void Addiere(int arg1, int arg2) => Console.WriteLine(arg1 + arg2);

	public static void DoAction(int a, int b, Action<int, int> action) => action(a, b);

	public static void PrintMalZwei(int a) => Console.WriteLine(a * 2);
	#endregion

	#region Predicate
	private static bool CheckForZero(int obj) => obj == 0;

	public static bool DoPredicate(int x, Predicate<int> pred) => pred(x);
	#endregion

	#region Func
	private static double Multipliziere(int arg1, int arg2)
	{
		return arg1 * arg2;
	}

	public static double DoFunc(int x, int y, Func<int, int, double> func)
	{
		return func(x, y);
	}
	#endregion
}
