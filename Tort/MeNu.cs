using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Tort
{
    internal class MeNu
    {
        public static int Show(string title, List<string> options)
        {
            int selectedIndex = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                Console.WriteLine(title);

                for (int i = 0; i < options.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.WriteLine("-> " + options[i]);
                    }
                    else
                    {
                        Console.WriteLine("   " + options[i]);
                    }
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow && selectedIndex > 0)
                {
                    selectedIndex--;
                }
                else if (key.Key == ConsoleKey.DownArrow && selectedIndex < options.Count - 1)
                {
                    selectedIndex++;
                }

            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

            if (key.Key == ConsoleKey.Enter)
            {
                return selectedIndex + 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
