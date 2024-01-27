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

class CakeOrder
{
    public string Form { get; set; }
    public string Size { get; set; }
    public string Flavor { get; set; }
    public int Quantity { get; set; }
    public string Glaze { get; set; }
    public string Decor { get; set; }
    public decimal Price { get; private set; }

    public void MakeOrder()
    {
        Console.WriteLine("=== Cake Order Menu ===");
        Form = GetMenuChoice("Select cake form", new List<string> { "Round", "Square", "Heart" });
        Size = GetMenuChoice("Select cake size", new List<string> { "Small", "Medium", "Large" });
        Flavor = GetMenuChoice("Select cake flavor", new List<string> { "Chocolate", "Vanilla", "Strawberry" });
        Console.Write("Enter quantity: ");
        Quantity = int.Parse(Console.ReadLine());
        Glaze = GetMenuChoice("Select glaze", new List<string> { "Chocolate", "Caramel", "Fruit" });
        Decor = GetMenuChoice("Select decor", new List<string> { "Sprinkles", "Fruits", "Candles" });
        Price = CalculatePrice();
    }

    private string GetMenuChoice(string title, List<string> options)
    {
        int choice = MeNu.Show(title, options);

        if (choice > 0)
        {
            return options[choice - 1];
        }
        else
        {
            Console.WriteLine("Operation canceled.");
            return null;
        }
    }

    public int CalculatePrice()
    {
        int basePrice = 100;
        int flavorPrice = 50;
        int glazePrice = 105;
        int decorPrice = 102;

        switch (Flavor)
        {
            case "Chocolate":
                flavorPrice = 200;
                break;
            case "Vanilla":
                flavorPrice = 230;
                break;
            case "Strawberry":
                flavorPrice = 300;
                break;
        }

        switch (Glaze)
        {
            case "Chocolate":
                glazePrice = 100;
                break;
            case "Caramel":
                glazePrice = 90;
                break;
            case "Fruit":
                glazePrice = 110;
                break;
        }

        switch (Decor)
        {
            case "Sprinkles":
                decorPrice = 40;
                break;
            case "Fruits":
                decorPrice = 30;
                break;
            case "Candles":
                decorPrice = 20;
                break;
        }

        return basePrice + flavorPrice + glazePrice + decorPrice;
    }

    public void SaveOrder()
    {
        var orderData = new
        {
            Form,
            Size,
            Flavor,
            Quantity,
            Glaze,
            Decor,
            Price
        };

        var json = JsonSerializer.Serialize(orderData);

        string filePath = "order_history.json";

        if (!File.Exists(filePath))
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(json);
            }
        }
        else
        {
            File.AppendAllText(filePath, json + Environment.NewLine);
        }
    }
}