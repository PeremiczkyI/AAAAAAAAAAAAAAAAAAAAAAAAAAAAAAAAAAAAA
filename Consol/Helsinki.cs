using Helsinki1952;

namespace helsinki1952
{
    public class Helsinki
    {
        static List<Versenyzo> versenyzoList = new List<Versenyzo>();
        static void Main(string[] args)
        {
            string path = @"C:\Users\szabolcs\Desktop\Új mappa (2)\helsinki.txt";

            feladat2(path);

            feladat3();

            int pont = feladat4(int.Parse(Console.ReadLine()));

            if (pont == 0)
            {
                Console.WriteLine("nincs ilyen helyezes (0 pont)");
            }
            else 
            {
                Console.WriteLine($"{pont} pont");
            }

            feladat5();

            feladat7();
        }

        static void feladat2(string path)
        {
            string[] allomany = File.ReadAllLines(path);

            foreach (var item in allomany)
            {
                versenyzoList.Add(new Versenyzo(item));
            }
        }
        static void feladat3()
        {
            int szum = 0;
            foreach (var item in versenyzoList)
            {
                if (item.Helyezes <= 6)
                {
                    szum++;
                }
            }
            Console.WriteLine("3. feladat");
            Console.WriteLine(szum);
        }
        public static int feladat4(int hely)
        {
            switch (hely)
            {
                default:
                    return 0;
                    break;

                case 1:
                    return 7;
                    break;

                case 2:
                    return 5;
                    break;

                case 3:
                    return 4;
                    break;

                case 4:
                    return 3;
                    break;

                case 5:
                    return 2;
                    break;

                case 6:
                    return 1;
                    break;
            }
        }
        static void feladat5()
        {
            int osszpont = 0;
            foreach (var item in versenyzoList)
            {
                if (item.Sportag.ToLower() == "torna" )
                {
                    osszpont += feladat4(item.Helyezes);
                }
            }
            Console.WriteLine(osszpont+" pont osszesen tornaban");
        }
        static void feladat7()
        {
            int szum = 0;

            foreach(var item in versenyzoList)
            {
                szum += item.VersenyzokSzama;
            }

            StreamWriter sw = new StreamWriter(@"C:\Users\szabolcs\Desktop\Új mappa (2)\foglalas.txt");
            sw.WriteLine($"Szeretnék asztalokat foglalni {szum} főre!");
            sw.Close();
        }
    }
}
