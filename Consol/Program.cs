using System.Net.WebSockets;

namespace celloveszetCLI
{
    public class Program
    {
        static List<Cellovo> lovesek = new List<Cellovo>();
        static void Main(string[] args)
        {
            Feladat_5();
            Feladat_9();
            Feladat_10();
            Feladat_Bonus();
            Feladat_Bonus_1();
        }

        private static void Feladat_Bonus_1()
        {
            //statisztika ? lövések 
            int elso = 0, masodik = 0, harmdik = 0, negyedik = 0;
            foreach (var item in lovesek)
            {
                if (item.LegnagyobbIndex() == 1)
                {
                    elso++;
                }
                if (item.LegnagyobbIndex() == 2)
                {
                    masodik++;
                }
                if (item.LegnagyobbIndex() == 3)
                {
                    harmdik++;
                }
                if (item.LegnagyobbIndex() == 4)
                {
                    negyedik++;
                }
            }
            Console.WriteLine($"Első lövés darabszáma: {elso}");
            Console.WriteLine($"Második lövés darabszáma: {masodik}");
        }

        private static void Feladat_Bonus()
        {
            //kérjünk be egy nevet, van-e ilyen ember és mennyi a max?
            Console.WriteLine("Bonusz feladat: Kérek egy nevet");
            string beNev = Console.ReadLine();
            Cellovo be = lovesek.FirstOrDefault(l => l.Nev == beNev);
            if (be != null)
            {
                Console.WriteLine(be.Nev);
            }
            else
            {
                Console.WriteLine("nincs");
            }
            //if (lovesek.Any(l => l.Nev == beNev))
            //{
            //    Console.WriteLine(lovesek[i].Nev + " " + lovesek[i].Legnagyobb());
            //}

            int i = 0;
            while (i < lovesek.Count && lovesek[i].Nev != beNev)
            {
                i++;
            }
            if (i < lovesek.Count)
            {
                Console.WriteLine(lovesek[i].Nev + " " + lovesek[i].Legnagyobb());
            }
            else
            {
                Console.WriteLine("nics ilyen");
            }
        }

        private static void Feladat_10()
        {
            int maxi = 0;
            for (int i = 1; i < lovesek.Count; i++)
            {
                if (lovesek[i].Legnagyobb() > lovesek[maxi].Legnagyobb())
                {
                    maxi = i;
                }
            }
            Console.WriteLine($"A legnagyobb találatot lövő eredményei:\n{lovesek[maxi].Nev} {lovesek[maxi].EsloLoves} {lovesek[maxi].MasodikLoves} {lovesek[maxi].HarmadikLoves} {lovesek[maxi].NegyedikLoves}");
        }

        private static void Feladat_9()
        {
            foreach (var item in lovesek)
            {
                Console.WriteLine($"{item.Nev} {item.Legnagyobb()} hanyadik: {LegnagyobbIndex(item.EsloLoves, item.MasodikLoves, item.HarmadikLoves, item.NegyedikLoves)}");
            }
        }

        private static void Feladat_5()
        {
            StreamReader sr = new StreamReader("lovesek.csv");
            while (!sr.EndOfStream)
            {
                lovesek.Add(new Cellovo(sr.ReadLine()));
            }
            sr.Close();
        }

        static public int LegnagyobbIndex(int elso, int masodik, int harmadik, int negyedik)
        {
            int[] lovesek = { elso, masodik, harmadik, negyedik };
            return Array.IndexOf(lovesek, lovesek.Max()) + 1;
        }
    }
}