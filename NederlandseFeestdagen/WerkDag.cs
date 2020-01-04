using System;
namespace ConsoleApp1
{
    public static class WerkDag
    {
        private static int cacheYear = 0;
        private static DateTime cacheResponse;

        /// <summary>
        /// Auteur: A.F. de Fluiter
        /// Bereken aantal werkdagen vanaf gegeven startdatum
        /// </summary>
        /// <param name="startDatum">startDatum</param>
        /// <param name="aantalDagen">het aantal gewenste werkdagen, mag ook negatief zijn voor terugrekenen, sbyte voor zinvolle functionele beperking van -128 to + 127</param>
        /// <returns></returns>
        public static DateTime BerekenDatumPlusWerkdagen(DateTime startDatum, sbyte aantalDagen)
        {
            DateTime curDate = startDatum;
            int counter = 0;

            while (counter != aantalDagen)
            {
                if (aantalDagen < 0) { curDate = curDate.AddDays(-1); }
                if (aantalDagen > 0) { curDate = curDate.AddDays(1); }
                if (WerkDag.IsWerkdag(curDate))
                {
                    if (aantalDagen < 0) { counter--; }
                    if (aantalDagen > 0) { counter++; }
                }
            }
            return curDate;
        }

        /// <summary>
        /// Controleer of dag een werkdag is (uitgaande dat er op zaterdag en zondag en nationale feestdagen niet gewerkt wordt (lol)
        /// </summary>
        /// <param name="datum">te testen datum</param>
        /// <returns>bool</returns>
        public static bool IsWerkdag(DateTime datum)
        {
            // vrije dagen zaterdag zondag
            if (datum.DayOfWeek == DayOfWeek.Saturday) return false;
            if (datum.DayOfWeek == DayOfWeek.Sunday) return false;

            // vrije dagen datums volgens onze kalender
            if (datum.Day == 1 && datum.Month == 1) return false;       // NieuwJaar
            if (datum.Day == 25 && datum.Month == 12) return false;     // 1e kerstdag
            if (datum.Day == 26 && datum.Month == 12) return false;     // 2e kerstdag
            if (datum.Day == 27 && datum.Month == 4) return false;      // Koningsdag ( alleen als dit op zondag valt wordt het zaterdag maar dat zowiezo een vrije dag )
            if (datum.Day == 5 && datum.Month == 5 && ((datum.Year % 5) == 0)) return false; // Bevrijdingsdag, eens in de 5 jaar vrij 

            // christelijke vrije dagen, volgens Juliaans kalender. Berekening zie: Wikipedia
            DateTime DateTimePasen = Pasen(datum.Year);
            if (DateTimePasen == datum) return false;                    // Pasen
            if (DateTimePasen.AddDays(1) == datum) return false;         // PaasMaandag1
            if (DateTimePasen.AddDays(-2) == datum) return false;        // Goede vrijdag
            if (DateTimePasen.AddDays(39) == datum) return false;        // Hemelvaart
            if (DateTimePasen.AddDays(49) == datum) return false;        // Pinksteren
            if (DateTimePasen.AddDays(50) == datum) return false;        // Pinkstermaandag

            return true;
        }

        /// <summary>
        /// Berekend pasen volgens Juliaanse kalender, zie Wiki, paasdatum wordt voor een gegeven jaar gechached
        /// </summary>
        /// <param name="year">jaar</param>
        /// <returns>datum pasen</returns>
        private static DateTime Pasen(int year)
        {
            if (year == cacheYear) return cacheResponse;

            int a = year % 19;
            int b = year / 100;
            int c = (b - (b / 4) - ((8 * b + 13) / 25) + (19 * a) + 15) % 30;
            int d = c - (c / 28) * (1 - (c / 28) * (29 / (c + 1)) * ((21 - a) / 11));
            int e = d - ((year + (year / 4) + d + 2 - b + (b / 4)) % 7);
            int month = 3 + ((e + 40) / 44);
            int day = e + 28 - (31 * (month / 4));
            cacheResponse = new DateTime(year, month, day);
            cacheYear = year;
            return cacheResponse;
        }
    }
}
