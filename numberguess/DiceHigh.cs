using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numberguess;
class DiceHigh
{
    public void DicePlay()
    {
        Console.Clear();

        Random DiceRandom = new Random();

        for (int i = 0; i < 3; i++)
        {
            int dice = DiceRandom.Next(1, 20);
            Console.WriteLine($"Dice {i + 1}) {dice}");

        }
    }

}
