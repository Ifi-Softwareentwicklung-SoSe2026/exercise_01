<!--

author:   Volker Göhler
email:    volker.goehler@informatik.tu-freiberg.de
version:  0.0.1
language: de
narrator: Deutsch Female

edit: true
date: 2026-04-23

icon: img/TUBAF_Logo_blau.svg
comment:  Übung Softwareentwicklung 01

link:   https://raw.githubusercontent.com/vgoehler/LiaScript_CSS_Provider/refs/heads/main/dist/university.css

tags: [ Sommersemester2026, Softwareentwicklung, Übung01]

-->

[![LiaScript Course](https://raw.githubusercontent.com/LiaScript/LiaScript/master/badges/course.svg)](https://liascript.github.io/course/?https://raw.githubusercontent.com/Ifi-Softwareentwicklung-SoSe2026/exercise_01/refs/heads/main/README.md)

#  Aufgabe 01

Softwareentwicklung SoSe2026
============================

Bearbeitungszeitraum
====================

*27. April - 03. Mai 2026*

## Offene Fragen aus Aufgabe 00

Die folgenden Aufgaben aus der letzten Einheit (Aufgabe 00) sollten bearbeitet worden sein:

Aufgabe 1: Mission Vorbereitung – Entwicklungsumgebung einrichten
--------------------

- Hast du **Visual Studio Code** mit der **C#-Dev-Erweiterung** installiert?
- Hast du die **.NET SDKs** für die Entwicklung von C#-Anwendungen installiert?
- Hast du ein **"Hello World"**-Projekt `ConsoleApp` erstellt, kompiliert und ausgeführt?
- Hast du den **Debug-Modus** ausprobiert?

Aufgabe 2: Katalogisierung von Himmelskörpern für die interstellare Mission
--------------------

1. **Dateninitialisierung** – Wurden alle Variablen (Name, Katalog-Nummer, Typ, Spektralklasse, Scheinbare Helligkeit, Umlaufzeit, Zentralkörper-Katalog-Nummer) in einer Datenklasse `Himmelskoerper` initialisiert?
2. **Daten von der Kommandozeile einlesen** – Wurde eine Methode `LeseDatenEin()` implementiert, die `args[]` verarbeitet und Strings in passende Datentypen konvertiert?
3. **Interaktive Dateneingabe** – Wurde `LeseDatenEin()` auch für die Tastatureingabe via `Console.ReadLine()` wiederverwendet?
4. **Datenausgabe** – Werden die Daten formatiert ausgegeben (z. B. *"Himmelskörper: Mars, Katalog-Nummer: 23456, Typ: Planet, ..."*)?
5. **Datenvalidierung** – Werden alle Eingaben validiert (5-stellige Katalog-Nummer, gültige Spektralklassen, positive Gleitkommazahlen, etc.)?

Bonusaufgaben
--------------------

- **Fehlerbehandlung** – Wurden `try-catch-finally`-Blöcke zur Behandlung ungültiger Eingaben implementiert?
- **Properties** – Wurden Properties mit integrierter Validierung in der Datenklasse verwendet?

## .NET Ausführungsmodi: Projektbasiert vs. dateibasiert

Argumentverarbeitung in .NET


| Befehl                     | Projekt aktiv? | `args[0]`       | `args[1]`       | `args[2]`       | Programmname in `args`? |
|----------------------------|----------------|-----------------|-----------------|-----------------|-------------------------|
| `dotnet run -- arg1 arg2`  | Nein        | `arg1`          | `arg2`          | –               | Nein                    |
| `dotnet Program.cs arg1 arg2` | Nein       | `arg1`          | `arg2`          | –               | Nein                    |
| `dotnet run Program.cs arg1 arg2` | **Ja**   | **`Program.cs`** | `arg1`          | `arg2`          | **Ja** (nur als CLI-Argument) |

### **Projektbasierte Ausführung**
- **Befehl:** `dotnet run -- arg1 arg2 `

- **Ergebnis:**

  - `args[0]` = `arg1`
  - `args[1]` = `arg2`
  - **Programmname erscheint nicht in `args`**

- **Wichtig:**

  - **Immer `--` verwenden**, um Argumente an dein Programm weiterzuleiten.
  - Ohne `--` werden Argumente als CLI-Argumente für `dotnet` interpretiert.

** `dotnet run Program.cs arg1 arg2`**

- **Ergebnis:**

   - `args[0]` = `Program.cs`
   - `args[1]` = `arg1`
   - `args[2]` = `arg2`

- **Lösung:**

  - Nutze stattdessen: `dotnet run -- arg1 arg2` oder `dotnet Program.cs arg1 arg2`

### **Dateibasierte Ausführung (ab .NET 10)**
- **Befehl:** ` dotnet Program.cs arg1 arg2`
- **Ergebnis:**

  - `args[0]` = `arg1`
  - `args[1]` = `arg2`
  - **Programmname erscheint nicht in `args`**

- **Hinweis:**

  - Keine `.csproj` erforderlich.


## Neue Aufgaben für diese Woche

### **Aufgabe 1: Refactoring der `LeseDatenEin`-Methode (Arrays)**

**Beschreibungstext:**
In der aktuellen Implementierung der `LeseDatenEin`-Methode gibt es zwei große `if`-Zweige: einer für die Verarbeitung von Kommandozeilenargumenten (`args[]`) und einer für die interaktive Eingabe über `Console.ReadLine()`. Beide Zweige führen ähnliche Schritte aus, was zu Code-Duplikation führt. Durch Refactoring soll die Methode so umgestaltet werden, dass beide Eingabearten (Kommandozeile und interaktive Eingabe) in einem einheitlichen `string[]`-Array verarbeitet werden. Dies verbessert die Wartbarkeit und reduziert Redundanz.

**Aufgabenbeschreibung:**

1. Passe die `LeseDatenEin`-Methode so an, dass sie ein `string[]`-Array als Parameter akzeptiert.
2. Ersetze die beiden `if`-Zweige durch eine gemeinsame Logik, die das `string[]`-Array verarbeitet.
3. Nutze die angepasste Methode sowohl für die Kommandozeilenargumente (`args`) als auch für die interaktive Eingabe, indem du die Nutzerinputs in ein `string[]`-Array einliest.
4. Stelle sicher, dass die Typ-Logik weiterhin funktioniert und alle Daten korrekt in ein `Himmelskoerper`-Objekt überführt werden.


### **Aufgabe 2: Erweiterung der Datenklasse um passive Eigenschaften**

**Beschreibungstext:**
Die Klasse `Himmelskoerper` soll um passive Eigenschaften erweitert werden, die abgeleitete oder berechnete Werte zurückgeben. Diese Eigenschaften sollen auf Basis der vorhandenen Daten berechnet werden und sind schreibgeschützt.

**Aufgabenbeschreibung:**

1. Füge der `Himmelskoerper`-Klasse die folgenden passiven Eigenschaften hinzu, die nur einen `get`-Zugriff haben:

   - **`UmlaufzeitInTagen`**: Berechnet die Umlaufzeit in Tagen (nur für Planeten/Monde).
     **Formel:** `UmlaufzeitInTagen = umlauf * 365.25f`
     *(Hinweis: 1 Erdjahr = 365,25 Tage, um Schaltjahre zu berücksichtigen.)*
   - **`VollstaendigerTyp`**: Gibt eine formatierte Zeichenkette zurück, die den Typ und, falls zutreffend, die Spektralklasse des Himmelskörpers enthält.
     **Beispiel:** Für einen Stern mit Spektralklasse `M` soll der Wert `"Stern (M-Klasse)"` zurückgegeben werden. Für Planeten/Monde reicht der Typ (z. B. `"Planet"`).

2. Implementiere die Logik für die Berechnung oder Formatierung dieser Eigenschaften.
3. Teste die neuen Eigenschaften, indem du sie in der `GibtDatenAus`-Methode ausgibst.

**HINWEIS**: Teste mit `.HasValue` für nullable Eigenschaften, um sicherzustellen, dass die Berechnung nur für gültige Typen (z. B. Planeten/Monde) durchgeführt wird.


### **Aufgabe 3: Verwendung von `StringBuilder` und Überschreiben von `ToString()`**

**Beschreibungstext:**
Die formatierte Ausgabe von Daten in der `Ausgabe`-Methode soll effizienter gestaltet werden. Statt String-Interpolation oder `String.Format` soll `StringBuilder` verwendet werden. Zudem soll die `ToString()`-Methode der `Himmelskoerper`-Klasse überschrieben werden, um die Daten direkt bei `Console.WriteLine(object)` ausgeben zu können.

**Aufgabenbeschreibung:**

1. Überschreibe die `ToString()`-Methode in der `Himmelskoerper`-Klasse, um eine formatierte Zeichenkette aller Eigenschaften zurückzugeben.

   - Verwende `StringBuilder`, um den Ausgabestring schrittweise aufzubauen.
   ```csharp
   StringBuilder sb = new StringBuilder();
   // fügt eine neue Zeile mit dem Namen des Himmelskörpers hinzu (mit Zeilenumbruch)
   sb.AppendLine($"Himmelskörper: {Name}");
   // fügt eine neue Zeile mit der Katalog-Nummer hinzu
   sb.Append($"Katalog-Nummer: {KatalogNummer}");
   return sb.ToString();
   ```

2. Passe die `Ausgabe`-Methode so an, dass sie `Console.WriteLine(koerper.ToString())` aufruft.
3. Achte darauf, dass die Ausgabe lesbar und korrekt formatiert ist.

### **Aufgabe 4: Factory-Klasse zur Erstellung von `Himmelskoerper`-Objekten**

**Beschreibungstext:**
Die Erstellung von `Himmelskoerper`-Objekten soll zentralisiert und gekapselt werden. Eine Factory-Klasse bietet eine klare Schnittstelle, um Objekte mit gültigen Daten zu erstellen und reduziert die Komplexität in der `Main`-Methode.

**Aufgabenbeschreibung:**

1. Erstelle eine statische Klasse `HimmelskoerperFactory` mit einer Methode `ErstelleHimmelskoerper`, die ein `string[]`-Array mit den Eingabedaten entgegennimmt.
2. Die Methode soll die Daten validieren und ein `Himmelskoerper`-Objekt zurückgeben.
3. Ersetze die direkte Objekterstellung in der `Main`-Methode durch den Aufruf der Factory-Methode.
4. Behandle mögliche Validierungsfehler in der Factory und wirf passende Ausnahmen.

### **Aufgabe 5: Himmelskörper-Gleichheit anhand der Namen**

**Beschreibungstext:**
Um die Gleichheit von `Himmelskoerper`-Objekten zu prüfen, sollen die `==` und `!=`-Operatoren überschrieben werden. Dabei sollen zwei Objekte als gleich betrachtet werden, wenn ihre `Name`-Eigenschaften übereinstimmen.

**Aufgabenbeschreibung:**

1. Überschreibe die `==` und `!=`-Operatoren in der `Himmelskoerper`-Klasse, um die Gleichheit basierend auf dem `Name`-Feld zu definieren.

```csharp
public static bool operator + (int? left, int? right)
{
    if (ReferenceEquals(left, right)) return true; // beide Referenzen sind gleich
    // teste auf null, um Nullreferenz-Ausnahmen zu vermeiden
    // teste den Namen auf Gleichheit
}
```

2. Teste die Implementierung, indem du zwei `Himmelskoerper`-Objekte mit demselben Namen erstellst und ihre Gleichheit prüfst. Teste auch die anderen Fälle (unterschiedliche Namen, null-Referenzen, Ungleichheit).

**Hinweis:** Die Implementierung von `Equals` und `GetHashCode` ist wichtig, um die korrekte Funktionalität von `==` und `!=` zu gewährleisten. D.h. in einem echten Szenario sollten diese Methoden entsprechend implementiert werden, um die Konsistenz zu gewährleisten.

