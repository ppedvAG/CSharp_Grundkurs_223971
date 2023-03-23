using Newtonsoft.Json;
using System.Xml.Serialization;
using static System.Environment; //using static: Importiert den gesamten Inhalt der Klasse in unsere Klasse als hätten wir den Inhalt selbst geschrieben (Console.WriteLine -> WriteLine)

namespace M016;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern (z.B.: Windows, AppData, Desktop, ...)

		string folderPath = Path.Combine(desktop, "Testordner"); //Pfad zum Testordner (wurde noch nicht erstellt)

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zur Datei

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//Streams();

		//SystemJson();

		//NewtonsoftJson();

		//Xml();
	}

	static void Streams()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern (z.B.: Windows, AppData, Desktop, ...)

		string folderPath = Path.Combine(desktop, "Testordner"); //Pfad zum Testordner (wurde noch nicht erstellt)

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zur Datei

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		StreamWriter sw = new StreamWriter(filePath); //Stream öffnen
		sw.WriteLine("Test1"); //Inhalt in den Stream schreiben
		sw.WriteLine("Test2"); //Inhalt in den Stream schreiben
		sw.WriteLine("Test3"); //Inhalt in den Stream schreiben
		sw.Flush(); //schreibe den Inhalt des Streams in das File
		sw.Close(); //gib das File wieder frei

		using (StreamWriter sw2 = new StreamWriter(filePath)) //using: Schließt Objekte mit dem IDisposable Interface am Ende des Blocks
		{
			sw2.WriteLine("Test4"); //Inhalt in den Stream schreiben
			sw2.WriteLine("Test5"); //Inhalt in den Stream schreiben
			sw2.WriteLine("Test6"); //Inhalt in den Stream schreiben
									//sw.Flush(); //passiert bei Dispose() automatisch
		}

		using StreamWriter sw3 = new StreamWriter(filePath);
		sw3.WriteLine("Test7");
		sw3.WriteLine("Test8");
		sw3.WriteLine("Test9");
		//Bei using Statement wird der Stream am Ende der Methode geschlossen

		using StreamReader sr = new StreamReader(filePath);
		string s = sr.ReadToEnd(); //Ließ das ganze File ein
		List<string> lines = s.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList(); //Split: string nach einem Zeichen in einzelne Strings aufteilen

		File.WriteAllText(filePath, "ABC"); //schnell einen String in ein File schreiben
		string s2 = File.ReadAllText(filePath); //schnell einen String aus einem File einlesen
	}

	static void SystemJson()
	{
		//string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern (z.B.: Windows, AppData, Desktop, ...)

		//string folderPath = Path.Combine(desktop, "Testordner"); //Pfad zum Testordner (wurde noch nicht erstellt)

		//string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zur Datei

		//if (!Directory.Exists(folderPath))
		//	Directory.CreateDirectory(folderPath);

		//List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		//{
		//	new Fahrzeug(251, FahrzeugMarke.BMW),
		//	new Fahrzeug(274, FahrzeugMarke.BMW),
		//	new Fahrzeug(146, FahrzeugMarke.BMW),
		//	new Fahrzeug(208, FahrzeugMarke.Audi),
		//	new Fahrzeug(189, FahrzeugMarke.Audi),
		//	new Fahrzeug(133, FahrzeugMarke.VW),
		//	new Fahrzeug(253, FahrzeugMarke.VW),
		//	new Fahrzeug(304, FahrzeugMarke.BMW),
		//	new Fahrzeug(151, FahrzeugMarke.VW),
		//	new Fahrzeug(250, FahrzeugMarke.VW),
		//	new Fahrzeug(217, FahrzeugMarke.Audi),
		//	new Fahrzeug(125, FahrzeugMarke.Audi)
		//};

		//JsonSerializerOptions options = new();
		//options.WriteIndented = true;
		//options.UnknownTypeHandling = System.Text.Json.Serialization.JsonUnknownTypeHandling.JsonElement;

		//string json = JsonSerializer.Serialize(fahrzeuge, options); //Objekte zu Json umwandeln
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//Fahrzeug[] fzgArray = JsonSerializer.Deserialize<Fahrzeug[]>(readJson, options); //Json zu Objekten umwandeln

		//Settings s = new() { Modell = "Maschine A", SollWert = 5 }; //Einstellungen als Json speichern
		//File.WriteAllText(Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), "M016", "Settings.json"), JsonSerializer.Serialize(s));
	}

	static void NewtonsoftJson()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern (z.B.: Windows, AppData, Desktop, ...)

		string folderPath = Path.Combine(desktop, "Testordner"); //Pfad zum Testordner (wurde noch nicht erstellt)

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zur Datei

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		JsonSerializerSettings settings = new(); //Einstellungen beim Serialisieren/Deserialisieren vornhemen, müssen bei beiden Methoden mitgegeben werden
		settings.Formatting = Formatting.Indented;
		settings.TypeNameHandling = TypeNameHandling.Objects; //Vererbungen beim Serialisieren beachten

		string json = JsonConvert.SerializeObject(fahrzeuge, settings); //Objekte zu Json umwandeln
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		Fahrzeug[] fzgArray = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson, settings); //Json zu Objekten umwandeln
	}

	static void Xml()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zu speziellen Ordnern (z.B.: Windows, AppData, Desktop, ...)

		string folderPath = Path.Combine(desktop, "Testordner"); //Pfad zum Testordner (wurde noch nicht erstellt)

		string filePath = Path.Combine(folderPath, "Test.txt"); //Pfad zur Datei

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		using StreamWriter sw = new StreamWriter(filePath);
		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		xml.Serialize(sw, fahrzeuge);

		sw.Close();

		using StreamReader sr = new StreamReader(filePath);
		List<Fahrzeug> readFzg = xml.Deserialize(sr) as List<Fahrzeug>;
	}
}

public class Fahrzeug
{
	public int MaxGeschwindigkeit { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug()
	{

	}

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }


public class Settings
{
	public string Modell { get; set; } //Für Json müssen Felder Properties sein

	public int SollWert { get; set; }
}