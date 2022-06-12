﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Buchung_2.Zusammenhänge;

namespace Buchung_2
{
    internal class PrivatKunde : Kunde
    {
        protected char automobilclubMitglied;
        Methoden m = new Methoden();

        public char AutomobilclubMitglied { get => automobilclubMitglied; set => automobilclubMitglied = value; }

        public PrivatKunde() { }

        public override void KundeAufnehmen()
        {
            Console.WriteLine("\nPrivat Konto Erstellen:");
            Console.WriteLine("\nName:");
            name = Console.ReadLine();
            Console.WriteLine("\nVorname:");
            vorname = Console.ReadLine();
            Console.WriteLine("\nGeburtsjahr:");
            int jahr = Convert.ToInt32(m.validitationVonDoubles(1922, 2003));
            gebDatum = new DateTime(jahr, 1, 1, 6, 32, 0);
            Console.WriteLine("\nFührerschein (j/n):");
            fuehrerrschein = abfrage();
            Console.WriteLine("\nAutoClub mitgliedsschaft (j/n):");
            automobilclubMitglied = abfrage();
            using (StreamWriter sw = File.AppendText(@"C:\_IAH11\MustafaSataric\Benutzer.txt"))
            {
                sw.WriteLine("p;" + name + ";" + vorname + ";" + gebDatum + ";" + fuehrerrschein + ";" + automobilclubMitglied + ";");
            }
        }
        public override void KundeAusgeben()
        {
            Console.WriteLine("\n\n\tPrivat-Konto Daten:");
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Vorname : " + vorname);
            Console.WriteLine("Geburtsdatum : " + gebDatum);
            Console.WriteLine("Führerscheinstatus : " + fuehrerrschein);
            Console.WriteLine("Auromobliclub Mitgliedschafts Status : " + automobilclubMitglied);
        }

        public override double rabatt() 
        {
            if(automobilclubMitglied == Convert.ToChar("j"))
            {
                return 0.9;
            }
            return 1;
        }
    }
}
