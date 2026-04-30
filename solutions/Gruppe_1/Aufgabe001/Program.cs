public enum Typ
{
    Stern,
    Planet,
    Mond
}


public class Himmelskoerper
{
    private string _name;
    public string Name 
    { 
        get => _name;
        set => _name = value.Trim();
    }
    private uint _katnr;
    public uint KatalogNummer { 
        get => _katnr;
        set {
           if(!isAKatalogNummer(value))
           {
                throw new ArgumentOutOfRangeException(nameof(value), "Katalognummer muss 5-stellig sein.");
           }
           _katnr = value;
        }
    }
    // typ
    public Typ Himmelskoerpertyp { get; set;}
    // spectral
    private char? _spectralklasse;

    public char? Spectral { 
        get => _spectralklasse;
        set {
            if (value != null)
            {
                char[] gueltigeSpektralklassen = { 'O', 'B', 'A', 'F', 'G', 'K', 'M'};
                if (!gueltigeSpektralklassen.Contains(value.Value))
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Ungültige Spektralklasse."
                    );
                }
            }
            _spectralklasse = value;

        }
    }
    // helligkeit
    private float? _helligkeit;
    public float? helligkeit {
         get => _helligkeit;
         set {
            if (!isNullorSmaller(value)){
                _helligkeit = value;
            }else{
                throw new ArgumentOutOfRangeException(nameof(value), "Helligkeit muss positiv sein.");
            }
         }
    }
    // Umlauf
    private float? _umlauf;
    public float? umlauf {
        get => _umlauf;
        set {
            if (!isNullorSmaller(value)){
                _umlauf = value;
            }else{
                throw new ArgumentOutOfRangeException(nameof(value), "Umlaufzeit muss positiv sein.");
            }

        }
    }
    // KatNr von Elternobjekt
    private uint _katnrref;
    public uint KatalogNummerReferenz {
        get => _katnrref;
        set {
           if(isAKatalogNummer(value))
           {
                throw new ArgumentOutOfRangeException(nameof(value), "Katalognummer muss 5-stellig sein.");
           }
           _katnrref = value;
        }
    }    

    private static bool isAKatalogNummer(uint katnr)
    {
        return !(katnr < 10000 || katnr > 99999);
    }

    private static bool isNullorSmaller(float? zahl)
    {
        return !zahl.HasValue || zahl <= 0;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Himmelskoerper koerper = new Himmelskoerper();
        try
        {
            LeseEin(koerper, args);
        }
        catch (System.Exception)// speziellen Fehler behandeln
        {
            // hier die Behandlung der Fehler
            throw;
        }
        Ausgabe(koerper);
    }

    public static void Ausgabe(Himmelskoerper koerper)
    {
        string output = $"Himmelskörper: {koerper.Name}, Katalog-Nummer: {koerper.KatalogNummer}, Typ:{koerper.Himmelskoerpertyp}";
        if (koerper.Himmelskoerpertyp == Typ.Stern)
        {
            Console.WriteLine($"{output}, Spektralklasse: {koerper.Spectral}, scheinbare Helligkeit: {koerper.helligkeit}");
        }else{
            Console.WriteLine($"{output}, Umlaufzeit: {koerper.umlauf} Erdjahren, Zentralkörper-Katalog-Nummer: {koerper.KatalogNummerReferenz}");
        }
    }
                    
    public static void InteraktiveEingabe(Dictionary<string, string> dict, string[] output, int offset = 0)
    {
            foreach (var (key, values) in dict)
            {
                // ausgabe
                Console.WriteLine(values);
                // eingabe
                int idx = Array.IndexOf([.. dict.Keys], key) + offset;
                output[idx] = Console.ReadLine();
            }
    }

    public static void LeseEin(Himmelskoerper koerper, string[] args)
    {
        if (args.Length > 0)
        {
            SetKoerper(koerper, args);
        }else{
            Dictionary<string, string> anfragen = new()
            {
                ["Name"] = "Name des Himmelskörpers:",
                ["KatalogNummer"] = "KatalogNummer (5-stellig):",
                ["Typ"] = "Geben Sie den Typ ein (Stern, Planet, Mond):"
            };
            Dictionary<string, string> anfragenStern = new()
            {
                ["Spektralklasse"] = "Spektralklasse (O, B, A, F, G, K, M): ",
                ["ScheinbareHelligkeit"] = "scheinbare Helligkeit: "
            };
            Dictionary<string, string> anfragenPlanetMond = new()
            {
                ["Umlaufzeit"] = "Umlaufzeit in Erdjahren: ",
                ["ZentralkoerperKatalogNummer"] = "KatalogNummer des Zentralkörpers: "
            };

            string[] output = new string[5];
            InteraktiveEingabe(anfragen, output);

            if (output[2] == Typ.Stern.ToString()){
                // eingabe für Stern
                InteraktiveEingabe(anfragenStern, output, 3);
            } else {
                // eingabe für Planet/Mond
                InteraktiveEingabe(anfragenPlanetMond, output, 3);
            }
            SetKoerper(koerper, output);
        }

    }

    public static void SetKoerper(Himmelskoerper koerper, string[] input){
        koerper.Name = input[0];
        koerper.KatalogNummer = uint.Parse(input[1]);
        koerper.Himmelskoerpertyp = (Typ) Enum.Parse(typeof(Typ), input[2]);
        if (koerper.Himmelskoerpertyp == Typ.Stern)
        {
            koerper.Spectral = input[3][0];
            koerper.helligkeit = float.Parse(input[4]);
        }else{
            koerper.umlauf = float.Parse(input[3]);
            koerper.KatalogNummerReferenz = uint.Parse(input[4]);
        }
    }

}