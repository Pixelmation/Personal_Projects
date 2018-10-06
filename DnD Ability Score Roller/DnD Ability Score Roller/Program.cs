using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Ability_Score_Roller
{
    class Program
    {
        static void Main(string[] args)
        {
            Random RNG = new Random();
            int rollNum = 0;

            List<int> results = new List<int>();

            int RandNum()
            {
                int number = RNG.Next(3, 7);
                return number;
            }


            void Roll()
            {
                int num1 = RandNum();
                int num2 = RandNum();
                int num3 = RandNum();
                int num4 = RandNum();
                int num5 = num1 + num2 + num3 + num4;
                results.Add(num5);
            }

            for (int i = 0; i < 6; i++)
            {
                Roll();
            }
            foreach (int item in results)
            {
                Console.Write("Roll {0}: ", (rollNum + 1));
                Console.WriteLine(results[rollNum]);
                rollNum++;
            }
        }
    }
}
