public enum HimmelskoerperTyp
{
    Stern,
    Planet,
    Mond,
    Todestern
}

public class Himmelskoerper
{
    private string _name;
    public string Name
    {
        get => _name;
        set => _name = value.Trim();
    }
    // katalognummer
    private uint _katalogNr;
    public uint KatalogNummer
    {
        get => _katalogNr;
        set
        {
            // check
            if (isCatalogueNumberNotValid(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Katalognummer nicht gültig (5 Zeichen).");
            }
            // zuweisung
            _katalogNr = value;
        }
    }
    // HimmelskoerperTyp
    public HimmelskoerperTyp Typ { get; set; }
    // Spektralklasse
    private char? _spectralKlasse;
    public char? SpektralKlasse
    {
        get => _spectralKlasse;
        set
        {
            if (value != null)
            {
                char[] gueltigeSpektralKlassen = ['O', 'B', 'A', 'F', 'G', 'K', 'M'];
                if (!gueltigeSpektralKlassen.Contains(value.Value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Spektralklasse muss eine von (O, B, A, F, G, K, M) sein");
                }
            }
            _spectralKlasse = value;
        }
    }
    // ScheinbareHelligkeit
    private double? _scheinbareHelligkeit;
    public double? ScheinbareHelligkeit { 
        get => _scheinbareHelligkeit;
        set{
            if (isDoubleSmallerZero(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Scheinbare Helligkeit darf nicht kleiner als 0 sein.");
            }
            _scheinbareHelligkeit = value;
        } 
    }
    // Umlaufzeit
    private double? _umlaufzeit;
    public double? Umlaufzeit { 
        get => _umlaufzeit; 
        set{
            if (isDoubleSmallerZero(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Umlaufzeit darf nicht 0 oder weniger sein.");
            }
            _umlaufzeit = value;
        } 
    }

    // ZentralkoerperKatalogNummer
    private uint? _zentralkoerperKatalogNummer;
    public uint? ZentralkoerperKatalogNummer { 
        get => _zentralkoerperKatalogNummer;
        set 
        {
            if (isCatalogueNumberNotValid(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Katalognummer des Zentralgestirns nicht gültig (5 Zeichen).");
            }
            _zentralkoerperKatalogNummer = value;
        }
    }

    public float? UmlaufzeitInTagen {
        get {
            if (Umlaufzeit.HasValue)
            {
                return (float)(Umlaufzeit.Value * 365.25);
            }
            return null;
        }
    }

    public string VollstaendigerTyp {
        get {
            if (Typ == HimmelskoerperTyp.Stern)
            {
                return $"{Typ} ({SpektralKlasse}-Klasse)";
            }
            return Typ.ToString();
        }
    }

    private static bool isCatalogueNumberNotValid(uint? number)
    {
        if (number != null)
        {
            return number < 10000 || number > 99999;
        }
        return false;
    }
    private static bool isDoubleSmallerZero(double? number)
    {
        return number != null && number <= 0;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Himmelskoerper stern = new Himmelskoerper();
        LeseDatenEin(stern, args);
        GibDatenAus(stern);
    }

    public static void GibDatenAus(Himmelskoerper koerper)
    {
        Console.WriteLine("Himmelskörper:");
        Console.WriteLine($"Name: {koerper.Name}, Katalog-Nummer: {koerper.KatalogNummer}, Typ: {koerper.VollstaendigerTyp}");
        if (koerper.Typ == HimmelskoerperTyp.Stern)
        {
            Console.WriteLine($"Scheinbare Helligkeit: {koerper.ScheinbareHelligkeit}");
        }
        else
        {
            Console.WriteLine($"Umlaufzeit: {koerper.Umlaufzeit} Erdjahre ({koerper.UmlaufzeitInTagen} Erdtage), Zentralkörper-Katalognummer: {koerper.ZentralkoerperKatalogNummer}");
        }
    }

    private static void WerteEingabe(Himmelskoerper koerper, string[] input){
        koerper.Name = input[0];
        koerper.KatalogNummer = uint.Parse(input[1]);
        koerper.Typ = (HimmelskoerperTyp)Enum.Parse(typeof(HimmelskoerperTyp), input[2]);

        if (koerper.Typ == HimmelskoerperTyp.Stern)
        {
            // SpektralKlasse
            koerper.SpektralKlasse = input[3][0]; //char.Parse(args[3])
            // ScheinbareHelligkeit
            koerper.ScheinbareHelligkeit = double.Parse(input[4]);
        }
        else
        {
            // Umlaufzeit
            koerper.Umlaufzeit = double.Parse(input[3]);
            // ZentralkoerperKatalogNummer
            koerper.ZentralkoerperKatalogNummer = uint.Parse(input[4]);
        }
    }
            
    private static void LoopDictionary(Dictionary<string, string> dict, string[] output, int offset = 0){
        foreach (var (key, values) in dict)
        {
            Console.WriteLine(values);
            int idx = Array.IndexOf([.. dict.Keys], key) + offset;
            output[idx] = Console.ReadLine();
        }
    }

    public static void LeseDatenEin(Himmelskoerper koerper, string[] args)
    {
        if (args.Length > 1)
        {
            WerteEingabe(koerper, args);
        }
        else
        {
            Dictionary<string, string> anfragen = new(){
                ["Name"] = "Namen des Himmelskörpers: ",
                ["KatalogNummer"] = "Katalognummer (5-Stellig): ",
                ["Typ"] = "Himmelskörpertyp (Stern, Planet, Mond): ",
            };
            Dictionary<string, string> anfragenStern = new(){
                ["Spektralklasse"] = "Spektralklasse",
                ["Helligkeit"] = "Scheinbare Helligkeit",
            };
            Dictionary<string, string> anfragenPlanet = new(){
                ["Umlauf"] = "Umlaufzeit in Jahren",
                ["KatNrZentral"] = "Katalognummer des Zentralgestirns: "
            };

            string[] output = new string[5];

            LoopDictionary(anfragen, output);
            if (output[2] == HimmelskoerperTyp.Stern.ToString()){
                LoopDictionary(anfragenStern, output, 3);
            }else
            {
                LoopDictionary(anfragenPlanet, output, 3);
            }

            WerteEingabe(koerper, output);
        }
    }

    //public static Himmelskoerper LeseDatenEin(string[] args){}
}