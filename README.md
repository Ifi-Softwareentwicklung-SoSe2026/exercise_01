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

### Aufgabe 1: Mission Vorbereitung – Entwicklungsumgebung einrichten

- Hast du **Visual Studio Code** mit der **C#-Dev-Erweiterung** installiert?
- Hast du die **.NET SDKs** für die Entwicklung von C#-Anwendungen installiert?
- Hast du ein **"Hello World"**-Projekt `ConsoleApp` erstellt, kompiliert und ausgeführt?
- Hast du den **Debug-Modus** ausprobiert?

### Aufgabe 2: Katalogisierung von Himmelskörpern für die interstellare Mission

1. **Dateninitialisierung** – Wurden alle Variablen (Name, Katalog-Nummer, Typ, Spektralklasse, Scheinbare Helligkeit, Umlaufzeit, Zentralkörper-Katalog-Nummer) in einer Datenklasse `Himmelskoerper` initialisiert?
2. **Daten von der Kommandozeile einlesen** – Wurde eine Methode `LeseDatenEin()` implementiert, die `args[]` verarbeitet und Strings in passende Datentypen konvertiert?
3. **Interaktive Dateneingabe** – Wurde `LeseDatenEin()` auch für die Tastatureingabe via `Console.ReadLine()` wiederverwendet?
4. **Datenausgabe** – Werden die Daten formatiert ausgegeben (z. B. *"Himmelskörper: Mars, Katalog-Nummer: 23456, Typ: Planet, ..."*)?
5. **Datenvalidierung** – Werden alle Eingaben validiert (5-stellige Katalog-Nummer, gültige Spektralklassen, positive Gleitkommazahlen, etc.)?

### Bonusaufgaben

- **Fehlerbehandlung** – Wurden `try-catch-finally`-Blöcke zur Behandlung ungültiger Eingaben implementiert?
- **Properties** – Wurden Properties mit integrierter Validierung in der Datenklasse verwendet?
