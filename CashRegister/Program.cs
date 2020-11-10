using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Program
    {
        static List<string> valueList = new List<string>();
        static List<double> amountList = new List<double>();
        static double prize = 0;
        static double newVal = 0;

        static void Main(string[] args)
        {
            setDefaultValue();
            while (true)
            {
                Console.WriteLine("1. Nadaj poczatkowe wartosci dla banknotow na kasie");
                Console.WriteLine("2. Pokaz ilosc banknotow");
                Console.WriteLine("3. Nowy Klient");
                int action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        setCashValue();
                        break;
                    case 2:
                        showCash();
                        break;
                    case 3:
                        ClientHandle();
                        break;
                    default:
                        Console.WriteLine("Koniec pracy");
                        break;
                }
            }
        }
        static void ClientHandle()
        {
            Console.WriteLine("Obsluga klienta...");
            Console.WriteLine("Podaj cene produktow");
            prize = Convert.ToDouble(Console.ReadLine());
            List<double> tmpValList = new List<double>() { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.50, 0.20, 0.10, 0.05, 0.02, 0.01 };
            if (prize != 0)
            {
                Console.WriteLine("Podaj ilosc banknotow, ktorymi placi klient");
                for (int i = 0; i < 15; i++)
                {
                    Console.WriteLine("(" + valueList[i] + ")Podaj ilosc:");
                    newVal = Convert.ToInt32(Console.ReadLine());
                    amountList[i] += newVal;
                    prize = prize - (tmpValList[i] * newVal);
                }
                if (prize < 0)
                {
                    List<int> amountOfValToReturnList = new List<int>();  // values to return to ammountList if there isn't possible to get back rest of money
                    for (int i = 0; i < 15; i++)
                    {
                        amountOfValToReturnList.Add(0);
                    }
                    double rest = Math.Abs(prize);
                    Console.WriteLine("Reszta wynosi: " + rest);
                    for (int i = 0; i < 14; i++)
                    {
                        rest = Math.Round(rest, 2);
                        if (rest >= tmpValList[i] && amountList[i] > 0)
                        {
                            amountOfValToReturnList[i]++;
                            rest = rest - tmpValList[i];
                            amountList[i]--;
                            i--;
                        }
                    }
                    if (rest > 0)
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            amountList[i] += amountOfValToReturnList[i];
                        }
                        Console.WriteLine("Blad, brak nominalow w kasie - niemozliwe wydanie reszty");
                    }
                }
            }
            else
            {
                Console.WriteLine("Koniec pracy");
            }
        }
        static void setDefaultValue()
        {
            valueList.Add("500");
            valueList.Add("200");
            valueList.Add("100");
            valueList.Add("50");
            valueList.Add("20");
            valueList.Add("10");
            valueList.Add("5");
            valueList.Add("2");
            valueList.Add("1");
            valueList.Add("0,50");
            valueList.Add("0,20");
            valueList.Add("0,10");
            valueList.Add("0,05");
            valueList.Add("0,02");
            valueList.Add("0,01");

            for (int i = 0; i < 15; i++)
                amountList.Add(0);
        }
        static void showCash()
        {
            Console.WriteLine("Nominal  ilosc");
            for (int i = 0; i < 15; i++)
                Console.WriteLine(valueList[i] + ":     " + amountList[i]);
        }

        static void setCashValue()
        {
            Console.WriteLine("Ustawianie wartosci poczatkowej kasy");
            Console.WriteLine("Podaj wartosci nominalow");
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("(" + valueList[i] + ")Podaj ilosc:");
                amountList[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
