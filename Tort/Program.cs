using Tort;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        while (true)
        {
            var order = new CakeOrder();
            order.MakeOrder();
            order.SaveOrder();

            Console.Write("Would you like to place another order? (yes/no): ");
            string anotherOrder = Console.ReadLine();
            if (!string.Equals(anotherOrder, "yes", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        }
    }
}