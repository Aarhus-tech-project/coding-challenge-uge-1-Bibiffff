using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numberguess;
class Dice
{

    public void DicePlay()
    {
        Console.WriteLine(" 1) Terning med 6 sider");
        Console.WriteLine(" 2) Terning med 20 sider");
        Console.WriteLine(" 3) Multi Player");
        Console.Write("\nDit valg: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                new DiceNormal().DicePlay();
                break;

            case "2":
                new DiceHigh().DicePlay();
                break;

            case "3":
                new DiceMulti().DicePlay();
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ugyldigt valg.");
                Console.ResetColor();
                break;
        }
    }

}
