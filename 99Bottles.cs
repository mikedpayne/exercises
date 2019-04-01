using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelearningConsole
{
    class _99Bottles
    {
        static void Main(string[] args)
        {
            for (int i = 99; i >= 0; i--)
            {
                if (i >= 3)
                    Console.WriteLine(i + " bottles of beer on the wall, " + i + " bottles of beer, take one down and pass it around, " + (i - 1) + " bottles of beer on the wall.");
                if (i == 2)
                    Console.WriteLine(i + " bottles of beer on the wall, " + i + " bottles of beer, take one down and pass it around, " + (i - 1) + " bottle of beer on the wall.");
                if (i == 1)
                    Console.WriteLine(i + " bottle of beer on the wall, " + i + " bottle of beer, take one down and pass it around, no more bottles of beer on the wall.");
                if (i == 0)
                    Console.WriteLine("No more bottles of beer on the wall, no more bottles of beer, go to the store and buy some more, 99 bottles of beer on the wall.");

                Console.WriteLine();
            }
        }
    }
}
