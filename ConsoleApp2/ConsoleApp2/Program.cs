using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new String[] {"one", "two", "three", "four" };
            string ans = words[2];
            Console.WriteLine(words[2]);

            List<int> buttons = new List<int>();
            buttons.Add(1);
            buttons.Add(2);
            buttons.Add(3);
            buttons.Add(4);

            buttons.RemoveAt(buttons.Count - 1);

            for (int i = 0; i < buttons.Count; i++)
            {
                Console.WriteLine(buttons[i]);
            }

        }
    }
}
