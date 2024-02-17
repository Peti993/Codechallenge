internal class Program
{
    static int szam2;
    static string tortbemenet;
    static string vizsgalat;
    private static void Main(string[] args)
    {
        long szam;
        long hossza;
        
        Console.Write("Kérem a számot  999.999.999.999 és -999.999.999.999 között: ");
        string bemenet = Console.ReadLine();

        //BEMENET VIZSGÁLAT

        if (bemenet.Contains("-"))
        {
            // Ha tartalmaz, akkor adjuk hozzá a "minusz" szót a szám elé
            bemenet = bemenet.Replace("-", "");
            hossza = bemenet.Length;
            Console.Write("mínusz ");
        }
        else
        {
            hossza = bemenet.Length;
        }
        // HA VAN BENNE ÜRES BEMENET
        if (bemenet.Contains(" "))
        {
            bemenet = bemenet.Replace(" ", "");
            hossza = bemenet.Length;
        }
        else
        {
            hossza = bemenet.Length;

        }

        //HA VAN PONT A BEMENETBE, AKKOR ELVÁGJA A BEMENETET

        if (bemenet.Contains("."))
        {
            string[] parts = bemenet.Split('.');
            szam = long.Parse(parts[0]);
            bemenet = szam.ToString();
            //MEGVIZSGÁLJA A PONT UTÁNI BEMENETET
            try
            {
                if (parts.Length > 1)
                {
                    szam2 = int.Parse(parts[1]);
                    vizsgalat = parts[1];
                    tortbemenet = szam2.ToString();
                }
                hossza = bemenet.Length;
            }
            catch (FormatException)
            {
                // Hibás bemenet esetén írj ki egy üzenetet
                Console.WriteLine("Hibás bemenet! Kérem adjon meg egy érvényes számot.");
                Environment.Exit(0);
            }
        }
        else
        {
            hossza = bemenet.Length;
        }

        //UGYAN AZ AZ ELV MINT AZ ELŐZŐNÉL, CSAK VESSZŐVEL
        if (bemenet.Contains(","))
        {
            string[] parts = bemenet.Split(',');
            szam = long.Parse(parts[0]);
            bemenet = szam.ToString();
            try
            {
                if (parts.Length > 1)
                {
                    szam2 = int.Parse(parts[1]);
                    vizsgalat = parts[1];
                    tortbemenet = szam2.ToString();
                }
                hossza = bemenet.Length;
            }
            catch (FormatException)
            {
                // Hibás bemenet esetén írj ki egy üzenetet
                Console.WriteLine("Hibás bemenet! Kérem adjon meg egy érvényes számot.");
                Environment.Exit(0);
            }

        }
        else
        {
            hossza = bemenet.Length;
        }

        // SZÁMOK FELIRÁSA:
        string[] szazasok = new string[] { "száz", "kétszáz", "háromszáz", "négyszáz", "ötszáz", "hatszáz", "hétszáz", "nyocszáz", "kilencszáz"};
        string[] tizesek = new string[] { "tizen", "huszon", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven" };
        string[] egyesek = new string[] { "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc", "tíz" };
        string[] egesz = new string[] { "tíz", "húsz", "harminc", "negyven", "ötven", "hatvan", "hetven", "nyolcvan", "kilencven"};

        //DEKLARÁLÁS:
        long milliard;
        long maradekmilliard;
        long millio;
        long maradekmillio;
        long ezresek;
        long maradekezres;
        long szazas;
        long maradekszazasok;
        long maradek;
        long elsoszam;
        long masodikszam;
        long harmadikszam;

        //BEMENET VIZSGÁLATA
        if (long.TryParse(bemenet, out szam))
        {
            //Console.WriteLine("Az egész rész: " + szam);
            //Console.WriteLine("A tört rész: " + szam2);
            //SZÁMOLÁS
            milliard = szam / 1000000000;
            maradekmilliard = szam % 1000000000;
            millio = maradekmilliard / 1000000;
            maradekmillio = maradekmilliard % 1000000;
            ezresek = maradekmillio / 1000;
            maradekezres = maradekmillio % 1000;
            szazas = maradekezres / 100;
            maradekszazasok = maradekezres % 100;
            maradek = maradekszazasok;

       
            if (szam2 > 999 || szam > 999999999999)

            {
                Console.Write("Hibás bemenet! Kérem adjon meg egy érvényes számot.");
                Environment.Exit(0);
            }
         
            ////////////////////////////////////////////////////////////MILLIÁRD SZÁMOLÁS//////////////////////////////////////////////////////////////////////

            if (milliard > 0)
            {
                elsoszam = milliard / 100;
                maradekmilliard = milliard % 100;
                masodikszam = maradekmilliard / 10;
                harmadikszam = maradekmilliard % 10;

                if (elsoszam != 0 && masodikszam != 0 && harmadikszam != 0) //1 1 1
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{tizesek[masodikszam - 1]}{egyesek[harmadikszam - 1]}milliárd");
                }
                else if (elsoszam == 0 && masodikszam != 0 && harmadikszam != 0) // 0 1 1
                {
                    Console.Write($"{tizesek[masodikszam - 1]}{egyesek[harmadikszam - 1]}milliárd");
                }
                else if (elsoszam != 0 && masodikszam == 0 && harmadikszam != 0) // 1 0 1
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{egyesek[harmadikszam - 1]}milliárd");
                }
                else if (elsoszam == 0 && masodikszam != 0 && harmadikszam == 0) // 0 1 0
                {
                    Console.Write($"{egesz[masodikszam - 1]}milliárd");
                }
                else if (elsoszam == 0 && masodikszam == 0 && harmadikszam != 0) // 0 0 1
                {
                    Console.Write($"{egyesek[harmadikszam - 1]}milliárd");
                }
                else if (elsoszam != 0 && masodikszam != 0 && harmadikszam == 0) // 1 1 0
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{egesz[masodikszam - 1]}milliárd");
                }
                else if (elsoszam != 0 && masodikszam == 0 && harmadikszam == 0) // 1 0 0
                {
                    Console.Write($"{szazasok[elsoszam - 1]}milliárd");
                }

            }

            ////////////////////////////////////////////////////////////MILLIÓ SZÁMOLÁS//////////////////////////////////////////////////////////////////////

            if (millio > 0)
            {
                if (milliard == 0)
                {
                    Console.Write($"");
                }
                else
                {
                    Console.Write($"-");
                }


                elsoszam = millio / 100;
                maradekmillio = millio % 100;
                masodikszam = maradekmillio / 10;
                harmadikszam = maradekmillio % 10; ;

                if (elsoszam != 0 && masodikszam != 0 && harmadikszam != 0) //1 1 1
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{tizesek[masodikszam - 1]}{egyesek[harmadikszam - 1]}millió");
                }
                else if (elsoszam == 0 && masodikszam != 0 && harmadikszam != 0) // 0 1 1
                {
                    Console.Write($"{tizesek[masodikszam - 1]}{egyesek[harmadikszam - 1]}millió");
                }
                else if (elsoszam != 0 && masodikszam == 0 && harmadikszam != 0) // 1 0 1
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{egyesek[harmadikszam - 1]}millió");
                }
                else if (elsoszam == 0 && masodikszam != 0 && harmadikszam == 0) // 0 1 0
                {
                    Console.Write($"{egesz[masodikszam - 1]}millió");
                }
                else if (elsoszam == 0 && masodikszam == 0 && harmadikszam != 0) // 0 0 1
                {
                    Console.Write($"{egyesek[harmadikszam - 1]}millió");
                }
                else if (elsoszam != 0 && masodikszam != 0 && harmadikszam == 0) // 1 1 0
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{egesz[masodikszam - 1]}millió");
                }
                else if (elsoszam != 0 && masodikszam == 0 && harmadikszam == 0) // 1 0 0
                {
                    Console.Write($"{szazasok[elsoszam - 1]}millió");
                }

            }
            ////////////////////////////////////////////////////////////EZRES SZÁMOLÁS////////////////////////////////////////////////////////////////////// 

            if (ezresek > 0)
            {
                if (millio == 0 && milliard == 0)
                {
                    Console.Write($"");
                }
                else
                {
                    Console.Write($"-");
                }


                elsoszam = ezresek / 100;
                maradekezres = ezresek % 100;
                masodikszam = maradekezres / 10;
                harmadikszam = maradekezres % 10;

                if (elsoszam != 0 && masodikszam != 0 && harmadikszam != 0) //1 1 1
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{tizesek[masodikszam - 1]}{egyesek[harmadikszam - 1]}ezer");
                }
                else if (elsoszam == 0 && masodikszam != 0 && harmadikszam != 0) // 0 1 1
                {
                    Console.Write($"{tizesek[masodikszam - 1]}{egyesek[harmadikszam - 1]}ezer");
                }
                else if (elsoszam != 0 && masodikszam == 0 && harmadikszam != 0) // 1 0 1
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{egyesek[harmadikszam - 1]}ezer");
                }
                else if (elsoszam == 0 && masodikszam != 0 && harmadikszam == 0) // 0 1 0
                {
                    Console.Write($"{egesz[masodikszam - 1]}ezer");
                }
                else if (elsoszam == 0 && masodikszam == 0 && harmadikszam != 0) // 0 0 1
                {
                    Console.Write($"{egyesek[harmadikszam - 1]}ezer");
                }
                else if (elsoszam != 0 && masodikszam != 0 && harmadikszam == 0) // 1 1 0
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{egesz[masodikszam - 1]}ezer");
                }
                else if (elsoszam != 0 && masodikszam == 0 && harmadikszam == 0) // 1 0 0
                {
                    Console.Write($"{szazasok[elsoszam - 1]}ezer");
                }

            }
            ////////////////////////////////////////////////////////////HELYESIRAS////////////////////////////////////////////////////////////////////////// 

            if (ezresek > 1 && milliard == 0 && millio == 0 && szazas == 0 && maradek == 0)
            {
                Console.Write("");

            }
            if (szam == 0)
            {
                Console.Write("nulla");
            }
            if ((ezresek == 1) && ((szazas != 0 && maradek != 0) || (szazas == 0 && maradek != 0)))
            {
                Console.Write("");

            }
            if ((szazas != 0) && ((milliard == 0 && millio == 0 && ezresek == 0)))
            {
                Console.Write("");

            }
            else if ((szazas != 0) && ((milliard == 0 && millio == 0 && ezresek != 0)))
            {
                Console.Write("");

            }
            else if (maradek != 0 && milliard == 0 && millio == 0 & ezresek == 0 && szazas == 0)
            {
                Console.Write("");

            }
            else if (millio != 0 && milliard == 0 && ezresek == 0 && szazas == 0 && maradek == 0)
            {
                Console.Write("");

            }
            else if (milliard != 0 && millio == 0 && ezresek == 0 && szazas == 0 && maradek == 0)
            {
                Console.Write("");

            }
            else if (millio == 0 && milliard == 0 && ezresek == 0 && szazas != 0 && maradek != 0)
            {
                Console.Write("");

            }
            else if (millio == 0 && milliard == 0 && ezresek == 0 && szazas == 0 && maradek == 0)
            {
                Console.Write("");

            }
            else
            {
                Console.Write("-");

            }
            ////////////////////////////////////////////////////////////SZÁZAS SZÁMOLÁS////////////////////////////////////////////////////////////////////// 

            if (szazas > 0)
            {
                if (millio == 0 && milliard == 0 && ezresek == 0 && szazas != 0 && maradek != 0)
                {
                    Console.Write("");

                }
                else if (ezresek != 1 && milliard == 0 && millio == 0 && szazas != 0 && maradek != 0)
                {
                    Console.Write("-");

                }
                elsoszam = szazas / 100;
                maradekszazasok = szazas % 100;
                masodikszam = maradekszazasok / 10;
                harmadikszam = maradekszazasok % 10;

                if (elsoszam != 0 && masodikszam != 0 && harmadikszam != 0) //1 1 1
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{tizesek[masodikszam - 1]}{egyesek[harmadikszam - 1]}száz");
                }
                else if (elsoszam == 0 && masodikszam != 0 && harmadikszam != 0) // 0 1 1
                {
                    Console.Write($"{tizesek[masodikszam - 1]}{egyesek[harmadikszam - 1]}száz");
                }
                else if (elsoszam != 0 && masodikszam == 0 && harmadikszam != 0) // 1 0 1
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{egyesek[harmadikszam - 1]}száz");
                }
                else if (elsoszam == 0 && masodikszam != 0 && harmadikszam == 0) // 0 1 0
                {
                    Console.Write($"{egesz[masodikszam - 1]}száz");
                }
                else if (elsoszam == 0 && masodikszam == 0 && harmadikszam != 0) // 0 0 1
                {
                    Console.Write($"{egyesek[harmadikszam - 1]}száz");
                }
                else if (elsoszam != 0 && masodikszam != 0 && harmadikszam == 0) // 1 1 0
                {
                    Console.Write($"{szazasok[elsoszam - 1]}{egesz[masodikszam - 1]}száz");
                }
                else if (elsoszam != 0 && masodikszam == 0 && harmadikszam == 0) // 1 0 0
                {
                    Console.Write($"{szazasok[elsoszam - 1]}száz");
                }

            }

            ////////////////////////////////////////////////////////////MARADÉK SZÁMOLÁS////////////////////////////////////////////////////////////////////// 

            if (maradek > 0)
            {

                if (maradek <= 99)
                {
                    elsoszam = maradek / 10;
                    masodikszam = maradek % 10;

                    if (elsoszam != 0 && masodikszam != 0)
                    {
                        Console.Write($"{tizesek[elsoszam - 1]}{egyesek[masodikszam - 1]}");
                    }
                    if (elsoszam != 0 && masodikszam == 0)
                    {
                        Console.Write($"{egesz[elsoszam - 1]}");
                    }
                }
                ////HA EGY SZÁMJEGY
                if (maradek < 10)
                {
                    elsoszam = maradek;
                    Console.Write($"{egyesek[elsoszam - 1]}");
                }
            }

        }
        else
        {
            Console.WriteLine("Hibás bemenet"); Environment.Exit(0);
        }

        ////////////////////////////////////////////////////////////////////////////////////"." UTÁNI RÉSZ HA VAN////////////////////////////////////////////////////////////

        if (szam2 > 0)
        {
            elsoszam = szam2 / 100;
            maradekszazasok = szam2 % 100;
            masodikszam = maradekszazasok / 10;
            harmadikszam = maradekszazasok % 10;
            Console.Write(" egész ");

            hossza = vizsgalat.Length;

            if (elsoszam != 0 && masodikszam != 0 && harmadikszam != 0) //1 1 1
            {
                Console.Write($"{szazasok[elsoszam - 1]}{tizesek[masodikszam - 1]}{egyesek[harmadikszam - 1]} ");
            }
            else if (elsoszam == 0 && masodikszam != 0 && harmadikszam != 0) // 0 1 1
            {
                Console.Write($"{tizesek[masodikszam - 1]}{egyesek[harmadikszam - 1]} ");
            }
            else if (elsoszam != 0 && masodikszam == 0 && harmadikszam != 0) // 1 0 1
            {
                Console.Write($"{szazasok[elsoszam - 1]}{egyesek[harmadikszam - 1]} ");
            }
            if (elsoszam == 0 && masodikszam != 0 && harmadikszam == 0) // 0 1 0
            {
                Console.Write($"{egyesek[masodikszam - 1]} ");
            }
            if (elsoszam == 0 && masodikszam == 0 && harmadikszam != 0) // 0 0 1
            {
                Console.Write($"{egyesek[harmadikszam - 1]} ");
            }
            else if (elsoszam != 0 && masodikszam != 0 && harmadikszam == 0) // 1 1 0
            {
                Console.Write($"{tizesek[elsoszam - 1]}{egesz[masodikszam - 1]} ");
            }
            else if (elsoszam != 0 && masodikszam == 0 && harmadikszam == 0) // 1 0 0
            {
                Console.Write($"{egyesek[elsoszam - 1]}");
            }

            if (hossza == 1)
            {
                Console.Write("tized");
            }
            if (hossza == 2)
            {
                Console.Write("század");
            }
            if (hossza == 3)
            {
                Console.Write("ezred");
            }

        }
    }
}