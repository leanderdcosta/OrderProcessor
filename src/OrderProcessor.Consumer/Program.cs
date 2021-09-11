using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderProcessor.Services;
using System;
using System.Collections.Generic;

namespace OrderProcessor.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();
                OrderProcessingService svc = ActivatorUtilities.CreateInstance<OrderProcessingService>(host.Services);

                bool showMenu = true;
                while (showMenu)
                {
                    showMenu = MainMenu(svc);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nError: {e.Message}\n");
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((context, services) =>
               {
                   services.AddTransient<IOrderProcessingService, OrderProcessingService>();
               });

        private static void PrintDetails((List<string> Tasks, string Name) product)
        {
            Console.WriteLine();
            foreach (var task in product.Tasks)
            {
                Console.WriteLine("* " + task);
            }
            Console.WriteLine();
            Console.Write("Press any key for Menu");
            Console.ReadKey();
        }

        private static bool MainMenu(OrderProcessingService svc)
        {
            Console.Clear();
            Console.WriteLine("Choose product:");
            Console.WriteLine($"1. {ProductTypes.PhysicalProduct}");
            Console.WriteLine($"2. {ProductTypes.Book}");
            Console.WriteLine($"3. {ProductTypes.Membership}");
            Console.WriteLine($"4. {ProductTypes.Upgrade}");
            Console.WriteLine($"5. {ProductTypes.Video}");
            Console.WriteLine($"6. Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    PrintDetails(svc.ProcessOrder(ProductTypes.PhysicalProduct));
                    return true;
                case "2":
                    PrintDetails(svc.ProcessOrder(ProductTypes.Book));
                    return true;
                case "3":
                    PrintDetails(svc.ProcessOrder(ProductTypes.Membership));
                    return true;
                case "4":
                    PrintDetails(svc.ProcessOrder(ProductTypes.Upgrade));
                    return true;
                case "5":
                    Console.Write("Enter Video Name: ");
                    PrintDetails(svc.ProcessOrder(ProductTypes.Video, Console.ReadLine()));
                    return true;
                case "6":
                default:
                    return false;
            }
        }
    }
}