﻿using System;
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

            // Ange summan som ska betalas
            Console.Write("Ange totalt belopp: ");
            string TotalText = Console.ReadLine();

            try
            {
                total = double.Parse(TotalText);
            }


            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Felaktigt belopp angivet!");
                Console.ResetColor();
            }

            // Ange erhållen summa
            Console.Write("Ange erhållen summa: ");
            string recievedSumText = Console.ReadLine();

            try
            {
                recievedSum = uint.Parse(recievedSumText);
            }


            catch
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Felaktigt belopp angivet!");
                Console.ResetColor();
            }

            // Avrunda ören
            total = double.Parse(TotalText);
            subTotal = (uint)Math.Round(total);
            roundingOffAmount = total - subTotal;

            // Räkna ut summa att få tillbaka
            recievedSum = uint.Parse(recievedSumText);
            sumBack = recievedSum - subTotal;

            // Skriv ut kvitto
            Console.WriteLine("");
            Console.WriteLine("KVITTO");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Total summa: {0, 15}" , total);
            Console.WriteLine("Öresavrundning: {0:f2}", roundingOffAmount);

            //if (roundingOffAmount > 0.5)
            //{
            //    Console.WriteLine("Öresavrundning: +{0:f2}", roundingOffAmount);
            //}
            //else
            //{
            //    Console.WriteLine("Öresavrundning: -{0:f2}", roundingOffAmount);
            //}
            Console.WriteLine("Att betala: {0, 15}", subTotal);
            Console.WriteLine("Kontant: {0, 15}", recievedSum);
            Console.WriteLine("Tillbaka: {0, 15}", sumBack);
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");

            // Ange vilka valörer som ska ges tillbaka
            uint rest = (uint)sumBack % 500;

            Console.WriteLine("500-lappar: " + (uint)sumBack / 500);
            Console.WriteLine("100-lappar: " + rest / 100);
            Console.WriteLine("20-lappar: " + (rest % 100) / 20);
            Console.WriteLine("10-kronor: " + ((rest % 100) % 20) / 10);
            Console.WriteLine("5-kronor: " + (((rest % 100) % 20) % 10) / 5);
            Console.WriteLine("1-kronor: " + ((((rest % 100) % 20) % 10) % 5) / 1);
        }
    }
}