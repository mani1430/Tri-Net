using System;
using System.Text.Json;

public static class GlobalHelpers
{
    public static void Dd(params object[] items)
    {
        Console.ResetColor();
        Console.WriteLine();

        foreach (var item in items)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            if (item == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine($"Type: {item.GetType().FullName}");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                string json = JsonSerializer.Serialize(item, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                Console.WriteLine(json);
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        Console.ResetColor();

        Environment.Exit(0);
    }
}
