using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATAGY_CBRadio
{
    internal class Program
    {
        static List<Bejegyzes> bejegyzesek = new List<Bejegyzes>();
        static void Main(string[] args)
        {
            Beolvasas();
            F03();
            F04();
            F05();
            Kiiras();
            F0809();
        }

        private static void F0809()
        {
            var nevekSzerint = new Dictionary<string, int>();
            foreach (var bejegyzes in bejegyzesek)
            {
                if (!nevekSzerint.ContainsKey(bejegyzes.Nev))
                {
                    nevekSzerint.Add(bejegyzes.Nev, bejegyzes.InditottAdas);
                }
                else
                {
                    nevekSzerint[bejegyzes.Nev] += bejegyzes.InditottAdas;
                }
            }
            Console.WriteLine($"8. Feladat: Sofőrök száma: {nevekSzerint.Count} fő.");

            var legtobbAdastIndito = nevekSzerint.OrderBy(x => x.Value).Last();
            Console.WriteLine($"9. Feladat: Legtöbb adást indító sofőr: \n\tNév: {legtobbAdastIndito.Key}\n\tAdások száma: {legtobbAdastIndito.Value} alkalom");

        }

        private static void Kiiras()
        {
            var sw = new StreamWriter(@"../../RES/cb2.txt", false, Encoding.UTF8);
            sw.WriteLine($"Kezdes;Nev;AdasDb");
            foreach (var bejegyzes in bejegyzesek)
            {
                sw.WriteLine($"{bejegyzes.AtszamolPercre};{bejegyzes.Nev};{bejegyzes.InditottAdas}");
            }
        }

        private static void F05()
        {
            Console.Write("5. Feladat: Kérek egy nevet: ");
            var megadottNev = Console.ReadLine();

            var hasznalat = bejegyzesek.Where(x => x.Nev == megadottNev).Sum(y => y.InditottAdas);
            if (hasznalat != 0)
            {
                Console.WriteLine($"\t{megadottNev} {hasznalat}x használta a CB-rádiót.");
            }
            else
                Console.WriteLine("\tNincs ilyen nevű sofőr!");

        }

        private static void F04()
        {
            var talalat = false;
            if (talalat == false)
            {
                foreach (var bejegyzes in bejegyzesek)
                {
                    if (bejegyzes.InditottAdas == 4)
                    {
                        talalat = true;
                    }
                }
            }

            if (talalat)
                Console.WriteLine("4. Feladat: Volt négy adást indító söfőr.");
            else
                Console.WriteLine("4. Feladat: Nem volt négy adást indító söfőr");

        }

        private static void F03()
        {
            Console.WriteLine($"3. Feladat: Bejegyzések száma: {bejegyzesek.Count} db");
        }

        private static void Beolvasas()
        {
            using (var sr = new StreamReader(@"../../RES/cb.txt", Encoding.UTF8))
            {
                var mezonevek = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    bejegyzesek.Add(new Bejegyzes(sr.ReadLine()));
                }
            }
        }
    }
}
