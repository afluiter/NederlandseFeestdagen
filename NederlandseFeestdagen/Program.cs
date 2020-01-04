using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Voorbeeld hoe Nederlandse datums custom te formatteren
            Console.WriteLine($"Voorbeeld formatering nederlandse datum: {DateTime.Now.ToString("dddd d MMMM yyyy", new CultureInfo("nl-NL", false))}");

            // Voorbeeld voor bepalen of dag een werkdag is.
            string Nieuwjaar = "1 Januari 2020";
            string GoedeVrijdag = "10 April 2020";
            string Pasen = "12 April 2020";
            string Paasmaandag = "13 April 2020";
            string Koningsdag = "27 April 2020";
            string Bevrijdingsdag = "5 Mei 2020";
            string Hemelvaart = "21 Mei 2020";
            string Pinksteren = "31 Mei 2020";
            string Pinkstermaandag = "1 Juni 2020";
            string Kerstmis = "25 December 2020";
            string TweedeKerstdag = "26 December 2020";

            DateTime NieuwJaarDateTime = DateTime.Parse(Nieuwjaar, new CultureInfo("nl-NL", false));
            DateTime PasenDateTime = DateTime.Parse(Pasen, new CultureInfo("nl-NL", false));
            DateTime PaasmaandagDateTime = DateTime.Parse(Paasmaandag, new CultureInfo("nl-NL", false));
            DateTime KoningsdagDateTime = DateTime.Parse(Koningsdag, new CultureInfo("nl-NL", false));
            DateTime BevrijdingsdagDateTime = DateTime.Parse(Bevrijdingsdag, new CultureInfo("nl-NL", false));
            DateTime HemelvaartDateTime = DateTime.Parse(Hemelvaart, new CultureInfo("nl-NL", false));
            DateTime PinksterenDateTime = DateTime.Parse(Pinksteren, new CultureInfo("nl-NL", false));
            DateTime PinkstermaandagDateTime = DateTime.Parse(Pinkstermaandag, new CultureInfo("nl-NL", false));
            DateTime GoedeVrijdagDateTime = DateTime.Parse(GoedeVrijdag, new CultureInfo("nl-NL", false));
            DateTime KerstmisDateTime = DateTime.Parse(Kerstmis, new CultureInfo("nl-NL", false));
            DateTime TweedeKerstdagDateTime = DateTime.Parse(TweedeKerstdag, new CultureInfo("nl-NL", false));

            Console.WriteLine($"NieuwjaarDateTime = IsWerkdag({WerkDag.IsWerkdag(NieuwJaarDateTime)})");
            Console.WriteLine($"GoedeVrijdagDateTime = IsWerkdag({WerkDag.IsWerkdag(GoedeVrijdagDateTime)})");
            Console.WriteLine($"PasenDateTime = IsWerkdag({WerkDag.IsWerkdag(PasenDateTime)})");
            Console.WriteLine($"PaasmaandagDateTime = IsWerkdag({WerkDag.IsWerkdag(PaasmaandagDateTime)})");
            Console.WriteLine($"KoningsdagDateTime = IsWerkdag({WerkDag.IsWerkdag(KoningsdagDateTime)})");
            Console.WriteLine($"BevrijdingsdagDateTime = IsWerkdag({WerkDag.IsWerkdag(BevrijdingsdagDateTime)})");
            Console.WriteLine($"HemelvaartDateTime = IsWerkdag({WerkDag.IsWerkdag(HemelvaartDateTime)})");
            Console.WriteLine($"PinksterenDateTime = IsWerkdag({WerkDag.IsWerkdag(PinksterenDateTime)})");
            Console.WriteLine($"PinkstermaandagDateTime = IsWerkdag({WerkDag.IsWerkdag(PinkstermaandagDateTime)})");
            Console.WriteLine($"KerstmisDateTime = IsWerkdag({WerkDag.IsWerkdag(KerstmisDateTime)})");
            Console.WriteLine($"TweedeKerstdagDateTime = IsWerkdag({WerkDag.IsWerkdag(TweedeKerstdagDateTime)})");

            DateTime berekendeDatum = WerkDag.BerekenDatumPlusWerkdagen(new DateTime(2019, 12, 20), 10); // vanaf 12 dec 2019 over kerst en nieuwjaar heen datum berekenen.
            Console.WriteLine($"12-12-2019 + 10 Werkdagen geeft: {berekendeDatum.ToString("ddd dd MMMM yyyy", new CultureInfo("nl-NL", false))}");

            Console.ReadLine();

        }

    }
}
