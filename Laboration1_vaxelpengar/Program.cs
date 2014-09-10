using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration1_vaxelpengar
{
    class Program
    {

        static void Main(string[] args)
        {
            // Definera variabler
            double  total, roundingOffAmount, subTotal, sumBack;
            uint recievedSum;
            string TotalText, recievedSumText, equals;

            // Ange summan som ska betalas
            while (true)
                try
                {
                    Console.Write("Ange totalt belopp: ");
                    TotalText = Console.ReadLine();
                    total = double.Parse(TotalText);
                    break;
                }
                catch(FormatException) // Visa felmeddelande om något annat än ett tal skrivs in
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Felaktigt belopp angivet!");
                    Console.ResetColor();
                }

            // Visa felmeddelande om totalt belopp är under 1kr efter avrundning
            if ((uint)Math.Round(total) < 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Summan är för låg, köpet kunde inte genomföras");
                Console.ResetColor();
                return;
            }


            // Ange erhållen summa
            while (true)
                try
                {
                    Console.Write("Ange erhållen summa: ");
                    recievedSumText = Console.ReadLine();
                    recievedSum = uint.Parse(recievedSumText);
                    break;
                }


                catch(FormatException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Felaktigt belopp angivet!");
                    Console.ResetColor();
                }

            if ((uint)Math.Round(total) > recievedSum)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Erhållen summa är för låg, köpet kunde inte genomföras");
                Console.ResetColor();
                return;
            }

            // Avrunda ören
            total = double.Parse(TotalText);
            subTotal = (uint)Math.Round(total);
            roundingOffAmount = total - subTotal;

            // Räkna ut summa att få tillbaka
            recievedSum = uint.Parse(recievedSumText);
            sumBack = recievedSum - subTotal;

            // Skriv ut kvitto
            equals = "=";
            Console.WriteLine("");
            Console.WriteLine("KVITTO");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Total summa: {0, 5} {1, 15}", equals, total);
            Console.WriteLine("Öresavrundning: {0, 2} {1, 15:f2}", equals, roundingOffAmount);
            Console.WriteLine("Att betala: {0, 6} {1, 15}", equals, subTotal);
            Console.WriteLine("Kontant: {0, 9} {1, 15}", equals, recievedSum);
            Console.WriteLine("Tillbaka: {0, 8} {1, 15}", equals, sumBack);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");


            // Ange vilka valörer som ska ges tillbaka, ENDAST
            uint rest = (uint)sumBack % 500;
            if (sumBack > 0)
            { 
                if ((uint)sumBack / 500 > 0)
                {
                    Console.WriteLine("500-lappar: " + (uint)sumBack / 500);
                }

                if (rest / 100 > 0)
                {
                    Console.WriteLine("100-lappar: " + rest / 100);
                }
                rest = (rest % 100);

                if (rest / 50 > 0)
                {
                    Console.WriteLine("50-lappar: " + rest / 50);
                }
                rest = (rest % 50);

                if (rest / 20 > 0)
                {
                    Console.WriteLine("20-lappar: " + rest / 20);
                }
                rest = (rest % 20);

                if (rest / 10 > 0)
                {
                    Console.WriteLine("10-kronor: " + rest / 10);
                }
                rest = (rest % 10);

                if (rest / 5 > 0)
                {
                    Console.WriteLine("5-kronor: " + rest / 5);
                }
                rest = (rest % 5);

                if (rest / 1 > 0)
                {
                    Console.WriteLine("1-kronor: " + rest / 1);
                }
            }

        }
    }
}
